using Models;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pooling.Pools
{
    public class GroundPool : MonoBehaviour
    {
        [FormerlySerializedAs("environmentPrefab")] [SerializeField] private Ground groundPrefab;
        
        private ObjectPool<Ground> _pointDeathEffectPool;

        private void Awake()
        {
            _pointDeathEffectPool = new ObjectPool<Ground>(groundPrefab);
        }
        
        public Ground GetObject()
        {
            var poolAble = _pointDeathEffectPool.GetFreeObject();
            return poolAble as Ground;
        }
    }
}