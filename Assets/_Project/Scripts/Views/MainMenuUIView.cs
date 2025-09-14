using System;
using UnityEngine;

namespace RoundsTextAdventure
{
    public class MainMenuUIView : UIViewBase, IUIView
    {
        [SerializeField] private ClickButtonView startGameButton;

        public event Action OnStartGameButtonClicked;
        
        protected override void OnShow()
        {
            Debug.Log($"Main menu shown.");
            startGameButton.OnClicked += OnStartGameButtonPressed;
        }

        protected override void OnHide()
        {
            Debug.Log($"Main menu hidden.");
            startGameButton.OnClicked -= OnStartGameButtonPressed;
        }

        private void OnStartGameButtonPressed()
        {
            Debug.Log($"Start game button pressed — firing event.");
            OnStartGameButtonClicked?.Invoke();
        }
    }
}
