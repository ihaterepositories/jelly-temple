using Animations;
using Loaders;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameObject sceneTransitionAnimation;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ScenesLoader>()
                .AsSingle();
            
            Container
                .Bind<SceneTransitionAnimation>()
                .FromComponentInNewPrefab(sceneTransitionAnimation)
                .AsSingle();
        }
    }
}