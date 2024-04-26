using DG.Tweening;
using Loaders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Animations
{
    public class SceneTransitionAnimation : MonoBehaviour
    {
        [SerializeField] private Image transitionImage;
        
        private SceneTransitionAnimation _instance;
        private ScenesLoader _scenesLoader;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
            DoFadeOut();
        }

        [Inject]
        private void Construct(ScenesLoader scenesLoader)
        {
            _scenesLoader = scenesLoader;
        }
        
        private void OnEnable()
        {
            _scenesLoader.OnSceneLoaded += DoFadeOut;
        }
        
        private void OnDisable()
        {
            _scenesLoader.OnSceneLoaded -= DoFadeOut;
        }
        
        public void DoFadeIn()
        {
            transitionImage.DOFade(1f, 1f);
        }
        
        private void DoFadeOut()
        {
            transitionImage.DOFade(0f, 1f);
        }
    }
}