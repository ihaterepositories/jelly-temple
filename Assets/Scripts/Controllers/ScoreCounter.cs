using System;
using System.Collections;
using Models;
using UnityEngine;

namespace Controllers
{
    public class ScoreCounter : MonoBehaviour
    {
        private Coroutine _increaseScoreCoroutine;
        
        public int Score { get; private set; }
        public bool IsNewBestScore { get; private set; }

        private void Start()
        {
            _increaseScoreCoroutine = StartCoroutine(IncreaseScoreByRuntimeCoroutine());
        }

        private void OnEnable()
        {
            Slime.OnCollidedWithGreenObstacle += IncreaseScore;
            Slime.OnCollidedWithYellowObstacle += DecreaseScore;
        }
        
        private void OnDisable()
        {
            Slime.OnCollidedWithGreenObstacle -= IncreaseScore;
            Slime.OnCollidedWithYellowObstacle -= DecreaseScore;
        }

        private IEnumerator IncreaseScoreByRuntimeCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                Score++;
            }
        }

        private void IncreaseScore() => Score += 10;
        private void DecreaseScore() => Score -= 10;
        
        public void StopCounting()
        {
            if (_increaseScoreCoroutine != null)
                StopCoroutine(_increaseScoreCoroutine);
        }
        
        public void CalculateBestScore()
        {
            var bestScore = PlayerPrefs.GetInt("BestScore", 0);

            if (Score > bestScore)
            {
                PlayerPrefs.SetInt("BestScore", Score);
                IsNewBestScore = true;
            }
        }
    }
}