using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Creatures.Platform
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private Transform playerPosition;
     
        private Vector3 _moveVector;
        
        private float _playerZSpawnPosition;
        private float _defaultYPosition;
        private float _defaultXPosition;
        private List<float> _onePartPlatformXPositions;
        private List<float> _twoPartPlatformXPositions;

        public event Action OnHidingPositionReached;

        private void Awake()
        {
            _playerZSpawnPosition = playerPosition.position.z;
            _defaultYPosition = transform.position.y;
            _defaultXPosition = transform.position.x;
            
            SetSpeed(19f);
        }

        private void FixedUpdate()
        {
            Move();
            
            if (transform.position.z < _playerZSpawnPosition - 20f)
            {
                Hide();
            }
            
            if (transform.position.z < _playerZSpawnPosition - 24f)
            {
                OnHidingPositionReached?.Invoke();
                transform.DOKill();
                Show();
            }
        }
        
        private void SetSpeed(float speed)
        {
            _moveVector = new Vector3(0f, 0f, -speed);
        }
        
        private void Move()
        {
            transform.Translate(_moveVector * Time.deltaTime);
        }

        private void Hide()
        {
            transform.DOMoveY(_defaultYPosition - 50f, 0.3f).OnComplete(() =>
                transform.position = new Vector3(transform.position.x, _defaultYPosition, transform.position.z));
        }

        private void Show()
        {
            transform.position = new Vector3(_defaultXPosition, transform.position.y, 48f);
            transform.DOMoveY(_defaultYPosition, 0.3f).OnComplete(() =>
                transform.position = new Vector3(transform.position.x, _defaultYPosition, transform.position.z));
        }
    }
}