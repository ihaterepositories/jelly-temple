using System;
using Loaders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.ButtonControllers
{
    public class SceneLoadingButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private string nextSceneAddress;
        
        private ScenesLoader _scenesLoader;

        public static event Action OnClicked;
        
        [Inject]
        private void Construct(ScenesLoader scenesLoader)
        {
            _scenesLoader = scenesLoader;
        }
        
        private void Start()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            OnClicked?.Invoke();
            StartCoroutine(_scenesLoader.LoadSceneCoroutine(nextSceneAddress));
        }
    }
}