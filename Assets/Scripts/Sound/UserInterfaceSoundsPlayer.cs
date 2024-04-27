using UnityEngine;
using UserInterface.ButtonControllers;
using UserInterface.TextControllers;

namespace Sound
{
    public class UserInterfaceSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        
        [SerializeField] private AudioClip buttonClickSound;
        
        private UserInterfaceSoundsPlayer _instance;

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
        }

        private void OnEnable()
        {
            SceneLoadingButton.OnClicked += PlayButtonClickSound;
            PressKeyToContinueText.OnClicked += PlayButtonClickSound;
        }

        private void OnDisable()
        {
            SceneLoadingButton.OnClicked -= PlayButtonClickSound;
            PressKeyToContinueText.OnClicked -= PlayButtonClickSound;
        }

        private void PlayButtonClickSound()
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}