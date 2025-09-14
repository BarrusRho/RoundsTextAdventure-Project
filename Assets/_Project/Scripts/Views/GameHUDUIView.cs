using System;
using UnityEngine;

namespace RoundsTextAdventure
{
    public class GameHUDUIView : UIViewBase, IUIView
    {
        [SerializeField] private ClickButtonView submitButton;
        [SerializeField] private ClickButtonView backButton;
        [SerializeField] private ClickButtonView restartButton;
        
        public event Action OnSubmitButtonClicked;
        public event Action OnBackButtonClicked;
        public event Action OnRestartButtonClicked;
        
        protected override void OnShow()
        {
            Debug.Log($"GameHUD Shown");

            submitButton.OnClicked += HandleSubmitClicked;
            backButton.OnClicked += HandleBackButtonClicked;
            restartButton.OnClicked += HandleRestartButtonClicked;
        }

        protected override void OnHide()
        {
            Debug.Log($"GameHUD Hidden");

            submitButton.OnClicked -= HandleSubmitClicked;
            backButton.OnClicked -= HandleBackButtonClicked;
            restartButton.OnClicked -= HandleRestartButtonClicked;
        }

        private void HandleSubmitClicked()
        {
            Debug.Log($"Submit button clicked.");
            OnSubmitButtonClicked?.Invoke();
        }

        private void HandleBackButtonClicked()
        {
            Debug.Log($"Back button clicked.");
            OnBackButtonClicked?.Invoke();
        }

        private void HandleRestartButtonClicked()
        {
            Debug.Log($"Restart button clicked.");
            OnRestartButtonClicked?.Invoke();
        }
    }
}
