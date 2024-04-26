using System.Collections;
using UnityEngine;

namespace Effects
{
    public class OneHitEffectPlayer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particles;
        
        public void PlayEffect()
        {
            particles.Play();
            StartCoroutine(LifetimeCoroutine());
        }
        
        private IEnumerator LifetimeCoroutine()
        {
            while (particles.IsAlive())
            {
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}