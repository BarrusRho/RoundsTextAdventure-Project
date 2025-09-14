using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoundsTextAdventure
{
    public class GameHUDUIController : UIControllerBase<GameHUDUIView>, IUIController
    {
        protected override void OnInit()
        {
            View.OnSubmitButtonClicked += OnSubmitButtonSelected;
            View.OnBackButtonClicked += OnBackButtonSelected;
            View.OnRestartButtonClicked += OnRestartButtonClicked;
        }

        protected override void OnDispose()
        {
            View.OnSubmitButtonClicked -= OnSubmitButtonSelected;
            View.OnBackButtonClicked -= OnBackButtonSelected;
            View.OnRestartButtonClicked -= OnRestartButtonClicked;
        }

        private void OnSubmitButtonSelected()
        {
            Debug.Log($"Submit button clicked — event handled.");
            AudioPlayer.ButtonPress();
            EventBus.Fire(new SubmitButtonClickedEvent());
        }

        private void OnBackButtonSelected()
        {
            Debug.Log($"Back button clicked — event handled.");
            AudioPlayer.Click();
            AudioPlayer.Confirm();
            EventBus.Fire(new BackButtonClickedEvent ());
        }

        private void OnRestartButtonClicked()
        {
            Debug.Log($"Restart button clicked — event handled.");
            AudioPlayer.Click();
            AudioPlayer.Confirm();

            var activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.buildIndex);
        }
    }
}
