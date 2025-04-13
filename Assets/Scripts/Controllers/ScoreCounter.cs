using System.Collections;
using Creatures.Player;
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
            PlayerCore.OnCollidedWithGreenObstacle += IncreaseScore;
            PlayerCore.OnCollidedWithYellowObstacle += DecreaseScore;
        }
        
        private void OnDisable()
        {
            PlayerCore.OnCollidedWithGreenObstacle -= IncreaseScore;
            PlayerCore.OnCollidedWithYellowObstacle -= DecreaseScore;
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