using Controllers;
using DG.Tweening;
using Models;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.TextControllers
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color yellowColor;
        [SerializeField] private Color greenColor;
        
        private ScoreCounter _scoreCounter;
        
        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }
        
        private void Update()
        {
            scoreText.text = _scoreCounter.Score.ToString();
        }

        private void OnEnable()
        {
            Slime.OnCollidedWithYellowObstacle += BlinkYellow;
            Slime.OnCollidedWithGreenObstacle += BlinkGreen;
        }
        
        private void OnDisable()
        {
            Slime.OnCollidedWithYellowObstacle -= BlinkYellow;
            Slime.OnCollidedWithGreenObstacle -= BlinkGreen;
        }

        private void BlinkYellow()
        {
            scoreText.DOColor(yellowColor, 0.5f).OnComplete(ReturnToDefaultColor);
        }
        
        private void BlinkGreen()
        {
            scoreText.DOColor(greenColor, 0.5f).OnComplete(ReturnToDefaultColor);
        }
        
        private void ReturnToDefaultColor()
        {
            scoreText.DOColor(defaultColor, 0.5f);
        }
    }
}