using Pooling.Pools;
using UnityEngine;
using Zenject;

namespace Spawners
{
    public class ObstaclesSpawner : MonoBehaviour
    {
        private ObstaclesPool _obstaclesPool;
        private int _lastPosition;
        
        [Inject]
        private void Construct(ObstaclesPool obstaclesPool)
        {
            _obstaclesPool = obstaclesPool;
        }
        
        public void SpawnObstacle()
        {
            var randomObstacle = Random.Range(0, 2);
            var randomPosition = Random.Range(1, 4);
            
            while (randomPosition == _lastPosition)
            {
                randomPosition = Random.Range(1, 4);
            }
            
            _lastPosition = randomPosition;
            
            if(randomObstacle == 0)
            {
                var redObstacle = _obstaclesPool.GetRedObstacle();
                SetPosition(redObstacle.gameObject, randomPosition);
            }
            else
            {
                var yellowObstacle = _obstaclesPool.GetYellowObstacle();
                SetPosition(yellowObstacle.gameObject, randomPosition);
            }
        }
        
        private void SetPosition(GameObject obstacle, int randomPosition)
        {
            switch (randomPosition)
            {
                case 1: obstacle.transform.position = new Vector3(-3.5f, 30f, 48f); break;
                case 2: obstacle.transform.position = new Vector3(0f, 30f, 48f); break;
                case 3: obstacle.transform.position = new Vector3(3.5f, 30f, 48f); break;
            }
        }
    }
}