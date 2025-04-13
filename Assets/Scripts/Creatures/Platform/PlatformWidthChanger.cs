using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Creatures.Platform
{
    public class PlatformWidthChanger : MonoBehaviour
    {
        [SerializeField] private Transform playerPosition;
        [SerializeField] private PlatformMover platformMover;

        private float _defaultXPosition;

        private float _defaultXScale;
        private Vector3 _onePartScale;
        private Vector3 _twoPartScale;
        
        private List<float> _onePartPlatformXPositions;
        private List<float> _twoPartPlatformXPositions;
        
        private float _slicedWidthSpawnChance = 0.5f;
        private float _onePartSlicedWidthSpawnChance = 0.5f;

        private void Awake()
        {
            _defaultXPosition = transform.position.x;
            
            _defaultXScale = transform.localScale.x;
            _onePartScale = new Vector3(_defaultXScale / 3, transform.localScale.y, transform.localScale.z);
            _twoPartScale = new Vector3(transform.localScale.x - (transform.localScale.x / 3), transform.localScale.y, transform.localScale.z);
            
            _onePartPlatformXPositions = new List<float>
            {
                0,
                _defaultXScale/3,
                -(_defaultXScale/3)
            };

            _twoPartPlatformXPositions = new List<float>
            {
                _defaultXScale/3 + (_defaultXScale/3)/2,
                -(_defaultXScale/3 + (_defaultXScale/3)/2)
            };
        }

        private void OnEnable()
        {
            platformMover.OnHidingPositionReached += DecideWidthChange;
        }

        private void OnDisable()
        {
            platformMover.OnHidingPositionReached -= DecideWidthChange;
        }

        private void DecideWidthChange()
        {
            transform.localScale = new Vector3(_defaultXScale, transform.localScale.y, transform.localScale.z);
            if (Random.value < _slicedWidthSpawnChance) ChangeWidth();
        }

        private void ChangeWidth()
        {
            if (Random.value < _onePartSlicedWidthSpawnChance)
            {
                transform.localScale = _onePartScale;
                var index = Random.Range(0, _onePartPlatformXPositions.Count);
                transform.position = new Vector3(_defaultXPosition + _onePartPlatformXPositions[index], transform.position.y, transform.position.z);
            }
            else
            {
                transform.localScale = _twoPartScale;
                var index = Random.Range(0, _twoPartPlatformXPositions.Count);
                transform.position = new Vector3(_defaultXPosition + _twoPartPlatformXPositions[index], transform.position.y, transform.position.z);
            }
        }
    }
}