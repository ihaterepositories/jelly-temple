using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.TextControllers
{
    public class BestScoreText : MonoBehaviour
    {
        [SerializeField] private Text bestScoreText;
        
        private void Start()
        {
            bestScoreText.text = "best score: " + PlayerPrefs.GetInt("BestScore", 0);
        }
    }
}