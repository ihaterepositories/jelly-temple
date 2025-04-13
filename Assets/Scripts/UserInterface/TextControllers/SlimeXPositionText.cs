using Creatures.Player;
using Moving;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.TextControllers
{
    public class SlimeXPositionText : MonoBehaviour
    {
        [SerializeField] private Text positionText;

        private void Start()
        {
            positionText.text = "* <color=#сссссс>*</color> *";
        }

        private void OnEnable()
        {
            PlayerMover.OnXPositionChanged += SetText;
        }
        
        private void OnDisable()
        {
            PlayerMover.OnXPositionChanged -= SetText;
        }

        private void SetText(int xPosition)
        {
            switch (xPosition)
            {
                case -1: positionText.text = "<color=#61BCAE>*</color> * *"; break;
                case 0: positionText.text = "* <color=#61BCAE>*</color> *"; break;
                case 1: positionText.text = "* * <color=#61BCAE>*</color>"; break;
                default: positionText.text = "* * *"; break;
            }
        }
    }
}