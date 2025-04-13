using Controllers;
using Creatures;
using Creatures.Platform;
using Creatures.Player;
using Moving;
using Sound;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private GameFinisher gameFinisher;
        [SerializeField] private GameSoundsPlayer gameSoundsPlayer;
        
        [FormerlySerializedAs("slimeMover")] [SerializeField] private PlayerMover playerMover;
        [FormerlySerializedAs("player")] [FormerlySerializedAs("slime")] [SerializeField] private PlayerCore playerCore;
        
        public override void InstallBindings()
        {
            InstallSpawners();
            InstallControllers();
        }

        private void InstallSpawners()
        {
            Container
                .Bind<PlatformWidthChanger>()
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
                .Bind<PlayerMover>()
                .FromInstance(playerMover)
                .AsSingle();
            
            Container
                .Bind<PlayerCore>()
                .FromInstance(playerCore)
                .AsSingle();

            Container
                .Bind<GameSoundsPlayer>()
                .FromInstance(gameSoundsPlayer)
                .AsSingle();
        }
    }
}