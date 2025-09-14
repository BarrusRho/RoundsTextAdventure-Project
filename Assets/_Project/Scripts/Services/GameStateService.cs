using System;
using UnityEngine;

namespace RoundsTextAdventure
{
    public class GameStateService
    {
        private GameState state = GameState.Init;

        public GameStateService() { }

        public void Initialise()
        {
            State = GameState.MainMenu;
            AudioPlayer.NewGameStart();

            EventBus.Subscribe<GameStartEvent>(OnStartGame);
            EventBus.Subscribe<BackButtonClickedEvent>(OnBackButton);
        }

        public void Dispose()
        {
            EventBus.Unsubscribe<GameStartEvent>(OnStartGame);
            EventBus.Unsubscribe<BackButtonClickedEvent>(OnBackButton);
        }
        
        private GameState State
        {
            get => state;
            set
            {
                if (value == GameState.Init)
                {
                    Debug.LogWarning("Attempted illegal transition to Init state.");
                    throw new ArgumentException("Cannot return to init state.");
                }

                state = value;

                switch (state)
                {
                    case GameState.MainMenu:
                        EventBus.Fire(new ViewTransitionEvent(UIViewType.MainMenu));
                        break;

                    case GameState.Game:
                        EventBus.Fire(new ViewTransitionEvent(UIViewType.GameHUD));
                        break;

                    case GameState.Init:
                    default:
                        Debug.LogWarning("Attempted illegal transition to Init state.");
                        throw new ArgumentOutOfRangeException($"State machine doesn't support state {state}.");
                }
            }
        }
        
        private void OnStartGame(GameStartEvent gameStartEvent)
        {
            Debug.Log("StartGameEvent received — changing state.");
            State = GameState.Game;
            
            EventBus.Fire(new GameBeginEvent());
        }

        private void OnBackButton(BackButtonClickedEvent backButtonClickedEvent)
        {
            Debug.Log("BackButtonClickedEvent received — changing state.");
            State = GameState.MainMenu;
        }
    }
}
