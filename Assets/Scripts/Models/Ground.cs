using System;
using Pooling.Interfaces;
using UnityEngine;

namespace Models
{
    public class Ground : MonoBehaviour, IPoolAble
    {
        public GameObject GameObject => gameObject;
        public event Action<IPoolAble> OnDestroyed;
        
        public void Reset()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}