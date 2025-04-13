using System;
using Effects;
using Sound;
using UnityEngine;
using Zenject;

namespace Creatures.Player
{
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] private OneHitEffectPlayer explosionEffect;
        [SerializeField] private OneHitEffectPlayer greenFrictionEffect;
        [SerializeField] private OneHitEffectPlayer yellowFrictionEffect;
        [SerializeField] private OneHitEffectPlayer redFrictionEffect;

        private GameSoundsPlayer _gameSoundsPlayer;
        
        public static event Action OnKilled;
        public static event Action OnCollidedWithYellowObstacle;
        public static event Action OnCollidedWithGreenObstacle;
        
        [Inject]
        private void Construct(GameSoundsPlayer gameSoundsPlayer)
        {
            _gameSoundsPlayer = gameSoundsPlayer;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("RedObstacle"))
            {
                Kill();
                ShowFriction(redFrictionEffect);
            }
            else if (other.gameObject.CompareTag("YellowObstacle"))
            {
                OnCollidedWithYellowObstacle?.Invoke();
                ShowFriction(yellowFrictionEffect);
            }
            else if (other.gameObject.CompareTag("GreenObstacle"))
            {
                OnCollidedWithGreenObstacle?.Invoke();
                ShowFriction(greenFrictionEffect);
            }
        }

        public void Kill()
        {
            OnKilled?.Invoke();
            _gameSoundsPlayer.PlaySplashSound();
            ShowExplosion();
            Destroy(gameObject);
        }

        private void ShowExplosion()
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity)
                .PlayEffect();
        }
        
        private void ShowFriction(OneHitEffectPlayer frictionEffect)
        {
            Instantiate(frictionEffect, transform.position, Quaternion.identity)
                .PlayEffect();
        }
    }
}