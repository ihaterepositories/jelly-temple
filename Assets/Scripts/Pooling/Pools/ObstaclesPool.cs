using Models;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pooling.Pools
{
    public class ObstaclesPool : MonoBehaviour
    {
        [SerializeField] private RedObstacle redObstaclePrefab;
        [SerializeField] private YellowObstacle yellowObstaclePrefab;
        
        private ObjectPool<RedObstacle> _redObstaclePool;
        private ObjectPool<YellowObstacle> _yellowObstaclePool;
        
        private void Awake()
        {
            _redObstaclePool = new ObjectPool<RedObstacle>(redObstaclePrefab);
            _yellowObstaclePool = new ObjectPool<YellowObstacle>(yellowObstaclePrefab);
        }
        
        public RedObstacle GetRedObstacle()
        {
            var poolAble = _redObstaclePool.GetFreeObject();
            return poolAble as RedObstacle;
        }
        
        public YellowObstacle GetYellowObstacle()
        {
            var poolAble = _yellowObstaclePool.GetFreeObject();
            return poolAble as YellowObstacle;
        }
    }
}