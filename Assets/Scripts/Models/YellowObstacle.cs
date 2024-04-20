using System;
using Pooling.Interfaces;
using UnityEngine;

namespace Models
{
    public class YellowObstacle : MonoBehaviour, IPoolAble
    {
        public GameObject GameObject => gameObject;
        public event Action<IPoolAble> OnDestroyed;
        
        private void Update()
        {
            if(transform.position.z < -20)
                Reset();
        }
        
        public void Reset()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}