using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.ButtonControllers
{
    public class ButtonsListController : MonoBehaviour
    {
        [SerializeField] private KeyCode upKey;
        [SerializeField] private KeyCode downKey;
        [SerializeField] private KeyCode clickKey;
        [SerializeField] private Transform buttonsParent;
        [SerializeField] private Color selectedButtonColor;
        [SerializeField] private Color defaultButtonColor;
        [SerializeField] private float selectionCooldown = 0.2f;

        private Button[] _buttons;
        private int _selectedIndex = 0;
        private float _lastSelectionTime;

        private void Start()
        {
            _buttons = buttonsParent.GetComponentsInChildren<Button>();
            SelectButton(_selectedIndex);
        }

        public void Update()
        {
            if (Input.GetKeyDown(upKey))
            {
                SelectButton(_selectedIndex - 1);
            }
            else if (Input.GetKeyDown(downKey))
            {
                SelectButton(_selectedIndex + 1);
            }
            
            if (Input.GetKeyDown(clickKey))
            {
                if (Time.time - _lastSelectionTime > selectionCooldown)
                {
                    Button selectedButton = _buttons[_selectedIndex];
                    
                    selectedButton.onClick.Invoke();
                    
                    _lastSelectionTime = Time.time;
                }
            }
        }

        private void SelectButton(int index)
        {
            index = Mathf.Clamp(index, 0, _buttons.Length - 1);

            _buttons[_selectedIndex].GetComponentInChildren<Text>().color = defaultButtonColor;
            _buttons[index].GetComponentInChildren<Text>().color = selectedButtonColor;

            _selectedIndex = index;
        }
    }
}