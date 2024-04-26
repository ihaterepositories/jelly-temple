using DG.Tweening;
using Models;
using Moving;
using UnityEngine;
using UnityEngine.UI;
using UserInterface.TextControllers;
using Zenject;

namespace Controllers
{
    public class GameFinisher : MonoBehaviour
    {
        [SerializeField] private PressKeyToContinueText pressKeyToContinueText;
        
        private ScoreCounter _scoreCounter;
        
        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }
        
        private void Start()
        {
            pressKeyToContinueText.enabled = false;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                ShowMenu();
        }

        private void OnEnable()
        {
            Slime.OnKilled += FinishGame;
        }
        
        private void OnDisable()
        {
            Slime.OnKilled -= FinishGame;
        }

        private void FinishGame()
        {
            _scoreCounter.StopCounting();
            _scoreCounter.CalculateBestScore();
            ShowMenu();
        }
        
        private void ShowMenu()
        {
            pressKeyToContinueText.enabled = true;
            pressKeyToContinueText.text.DOFade(1f, 1.5f);
        }
    }
}