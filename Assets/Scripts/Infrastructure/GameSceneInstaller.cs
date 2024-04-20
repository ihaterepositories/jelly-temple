using Pooling.Pools;
using Spawners;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private ObstaclesPool obstaclesPool;
        
        [SerializeField] private ObstaclesSpawner obstaclesSpawner;
        
        public override void InstallBindings()
        {
            InstallPools();
            InstallSpawners();
        }
        
        private void InstallPools()
        {
            Container
                .Bind<ObstaclesPool>()
                .FromInstance(obstaclesPool)
                .AsSingle();
        }

        private void InstallSpawners()
        {
            Container
                .Bind<ObstaclesSpawner>()
                .FromInstance(obstaclesSpawner)
                .AsSingle();

            Container
                .Bind<GroundReSpawner>()
                .FromComponentInHierarchy()
                .AsTransient();
        }
    }
}