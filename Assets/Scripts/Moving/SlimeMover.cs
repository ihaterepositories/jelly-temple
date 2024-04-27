using System;
using Models;
using Sound;
using UnityEngine;
using Zenject;

namespace Moving
{
    public class SlimeMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Slime slime;
        
        private readonly int _maxJumps = 2;
        private readonly float _jumpForce = 20f;
        private readonly float _dropForce = 30f;
        private readonly int _moveSpeed = 3;
        private bool _isGrounded;
        private int _jumpCount;
        private int _xPosition;
        
        private GameSoundsPlayer _gameSoundsPlayer;
        
        private Vector3 Velocity => rb.velocity;
        
        public static event Action<int> OnXPositionChanged;
        
        [Inject]
        private void Construct(GameSoundsPlayer gameSoundsPlayer)
        {
            _gameSoundsPlayer = gameSoundsPlayer;
        }

        private void Update()
        {
            ConfigureMoveInput();
            SetBounds();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Ground")) return;
            _isGrounded = true;
            _jumpCount = 0;
            _gameSoundsPlayer.PlayLandingSound();
        }

        private void OnCollisionExit(Collision other)
        {
            if (!other.gameObject.CompareTag("Ground")) return;
            _isGrounded = false;
        }

        private void ConfigureMoveInput()
        {
            if (Input.GetKeyDown(KeyCode.W) && (_isGrounded || _jumpCount < _maxJumps))
            {
                Jump();
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                Drop();
            }
            
            if (Input.GetKeyUp(KeyCode.A))
            {
                Move(-_moveSpeed);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                Move(_moveSpeed);
            }
        }

        private void Jump()
        {
            rb.velocity = new Vector3(Velocity.x, _jumpForce, Velocity.z);
            _jumpCount++;
            _gameSoundsPlayer.PlayJumpSound();
        }
        
        private void Drop()
        {
            rb.velocity = new Vector3(Velocity.x, -_dropForce, Velocity.z);
            _gameSoundsPlayer.PlayDropSound();
        }
        
        private void Move(int direction)
        {
            var newPosition = transform.position + new Vector3(direction, 0, 0);
            rb.MovePosition(newPosition);
            HandlePositionChange(direction);
        }
        
        private void HandlePositionChange(int direction)
        {
            switch (direction)
            {
                case 3: _xPosition += 1; break;
                case -3: _xPosition -= 1; break;
            }
            
            OnXPositionChanged?.Invoke(_xPosition);
        }
        
        private void SetBounds()
        {
            if (transform.position.y < -15f)
            {
                slime.Kill();
            }
            
            if (transform.position.x is < -3.5f or > 3.5f)
            {
                slime.Kill();
            }
        }
    }
}