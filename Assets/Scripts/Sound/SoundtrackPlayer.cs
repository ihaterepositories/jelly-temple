using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sound
{
    public class SoundtrackPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioReverbFilter audioReverbFilter;

        private readonly float _defaultVolume = 1f;
        private SoundtrackPlayer _instance;

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
            SceneManager.sceneLoaded += ManageVolume;
        }
        
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= ManageVolume;
        }

        private void ManageVolume(Scene scene, LoadSceneMode loadMode)
        {
            if (scene.name == "Game")
            {
                audioSource.DOFade(_defaultVolume/2f, 2f);
                AddReverb(true);
            }
            else
            {
                audioSource.DOFade(_defaultVolume, 2f);
                AddReverb(false);
            }
        }

        private bool AddReverb(bool enable)
        {
            return audioReverbFilter.enabled = enable;
        }
    }
}