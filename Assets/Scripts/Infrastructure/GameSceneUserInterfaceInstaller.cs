using UnityEngine;
using UserInterface.TextControllers;
using Zenject;

namespace Infrastructure
{
    public class GameSceneUserInterfaceInstaller : MonoInstaller
    {
        [SerializeField] private ScoreText scoreText;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ScoreText>()
                .FromInstance(scoreText)
                .AsSingle();
        }
    }
}