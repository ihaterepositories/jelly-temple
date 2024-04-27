using Controllers;
using Models;
using Moving;
using Pooling.Pools;
using Sound;
using Spawners;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private ObstaclesPool obstaclesPool;
        
        [SerializeField] private ObstaclesSpawner obstaclesSpawner;

        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private GameFinisher gameFinisher;
        [SerializeField] private GameSoundsPlayer gameSoundsPlayer;
        
        [SerializeField] private SlimeMover slimeMover;
        [SerializeField] private Slime slime;
        
        public override void InstallBindings()
        {
            InstallPools();
            InstallSpawners();
            InstallControllers();
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

        private void InstallControllers()
        {
            Container
                .Bind<ScoreCounter>()
                .FromInstance(scoreCounter)
                .AsSingle();
            
            Container
                .Bind<GameFinisher>()
                .FromInstance(gameFinisher)
                .AsSingle();
            
            Container
                .Bind<SlimeMover>()
                .FromInstance(slimeMover)
                .AsSingle();
            
            Container
                .Bind<Slime>()
                .FromInstance(slime)
                .AsSingle();

            Container
                .Bind<GameSoundsPlayer>()
                .FromInstance(gameSoundsPlayer)
                .AsSingle();
        }
    }
}