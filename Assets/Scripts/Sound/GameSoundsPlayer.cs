using UnityEngine;

namespace Sound
{
    public class GameSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        
        [SerializeField] private AudioClip jumpSound;
        [SerializeField] private AudioClip landingSound;
        [SerializeField] private AudioClip splashSound;
        [SerializeField] private AudioClip dropSound;

        public void PlayJumpSound() => audioSource.PlayOneShot(jumpSound);
        public void PlayLandingSound() => audioSource.PlayOneShot(landingSound);
        public void PlaySplashSound() => audioSource.PlayOneShot(splashSound);
        public void PlayDropSound() => audioSource.PlayOneShot(dropSound);
    }
}