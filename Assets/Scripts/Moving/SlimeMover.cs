using UnityEngine;

namespace Moving
{
    public class SlimeMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        
        private readonly int _maxJumps = 2;
        private readonly float _jumpForce = 20f;
        private readonly float _dropForce = 30f;
        private readonly float _moveSpeed = 3f;
        private bool _isGrounded;
        private int _jumpCount;

        private void Update()
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
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
                _jumpCount = 0;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isGrounded = false;
            }
        }

        private void Jump()
        {
            rb.velocity = new Vector3(rb.velocity.x, _jumpForce, rb.velocity.z);
            _jumpCount++;
        }
        
        private void Drop()
        {
            rb.velocity = new Vector3(rb.velocity.x, -_dropForce, rb.velocity.z);
        }
        
        private void Move(float direction)
        {
            var newPosition = transform.position + new Vector3(direction, 0, 0);
            rb.MovePosition(newPosition);
        }
    }
}