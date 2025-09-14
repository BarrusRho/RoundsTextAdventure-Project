using UnityEngine;

namespace RoundsTextAdventure
{
    public class MainMenuUIController : UIControllerBase<MainMenuUIView>, IUIController
    {
        protected override void OnInit()
        {
            View.OnStartGameButtonClicked += OnStartGameSelected;
        }

        protected override void OnDispose()
        {
            View.OnStartGameButtonClicked -= OnStartGameSelected;
        }

        private void OnStartGameSelected()
        {
            Debug.Log($"Start button clicked (controller) — firing event.");
            AudioPlayer.Click();
            AudioPlayer.Confirm();
            EventBus.Fire(new GameStartEvent());
        }
    }
}
