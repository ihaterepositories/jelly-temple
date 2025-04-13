using Creatures;
using Creatures.Player;
using DG.Tweening;
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
                FinishGame();
        }

        private void OnEnable()
        {
            PlayerCore.OnKilled += FinishGame;
        }
        
        private void OnDisable()
        {
            PlayerCore.OnKilled -= FinishGame;
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