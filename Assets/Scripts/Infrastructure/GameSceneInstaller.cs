using Pooling.Pools;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [FormerlySerializedAs("environmentPool")] [SerializeField] private GroundPool groundPool;
        
        public override void InstallBindings()
        {
            InstallPools();
        }
        
        private void InstallPools()
        {
            Container
                .Bind<GroundPool>()
                .FromInstance(groundPool)
                .AsSingle();
        }
    }
}