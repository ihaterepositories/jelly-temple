using Models;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pooling.Pools
{
    public class ObstaclesPool : MonoBehaviour
    {
        [SerializeField] private Obstacle redObstaclePrefab;
        [SerializeField] private Obstacle yellowObstaclePrefab;
        [SerializeField] private Obstacle greenObstaclePrefab;
        
        private ObjectPool<Obstacle> _redObstaclePool;
        private ObjectPool<Obstacle> _yellowObstaclePool;
        private ObjectPool<Obstacle> _greenObstaclePool;
        
        private void Awake()
        {
            _redObstaclePool = new ObjectPool<Obstacle>(redObstaclePrefab);
            _yellowObstaclePool = new ObjectPool<Obstacle>(yellowObstaclePrefab);
            _greenObstaclePool = new ObjectPool<Obstacle>(greenObstaclePrefab);
        }
        
        public Obstacle GetRedObstacle()
        {
            var poolAble = _redObstaclePool.GetFreeObject();
            return poolAble as Obstacle;
        }
        
        public Obstacle GetYellowObstacle()
        {
            var poolAble = _yellowObstaclePool.GetFreeObject();
            return poolAble as Obstacle;
        }
        
        public Obstacle GetGreenObstacle()
        {
            var poolAble = _greenObstaclePool.GetFreeObject();
            return poolAble as Obstacle;
        }
    }
}