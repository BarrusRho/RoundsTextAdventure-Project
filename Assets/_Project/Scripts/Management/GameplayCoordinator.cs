using TMPro;
using UnityEngine;

namespace RoundsTextAdventure
{
    public class GameplayCoordinator : MonoBehaviourServiceUser
    {
        [Header("References")]
        public PlayerView playerView;
        public TMP_InputField textEntryField;
        public TMP_Text historyText;
        public TMP_Text currentText;
        public ActionSO[] actions;
        
        [TextArea]
        public string introText;
        
        private GameConfigService gameConfigService;
        private GameplayControllerService gameplayControllerService;
        private PlayerController playerController;
        
        public void Initialise()
        {
            gameConfigService = ResolveServiceDependency<GameConfigService>();
            gameplayControllerService = ResolveServiceDependency<GameplayControllerService>();

            playerController = (PlayerController)GameplayControllerFactory.Create(GameplayControllerType.PlayerController, playerView);
            gameplayControllerService.Register(playerController);
        }

        private void OnEnable()
        {
            EventBus.Subscribe<GameBeginEvent>(OnGameBegin);
            EventBus.Subscribe<SubmitButtonClickedEvent>(OnSubmitButtonClicked);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<GameBeginEvent>(OnGameBegin);
            EventBus.Unsubscribe<SubmitButtonClickedEvent>(OnSubmitButtonClicked);
        }

        private void OnGameBegin(GameBeginEvent gameBeginEvent)
        {
            InitialiseGameplay();
        }

        private void OnSubmitButtonClicked(SubmitButtonClickedEvent submitButtonClickedEvent)
        {
            TextEntered();
        }

        private void InitialiseGameplay()
        {
            historyText.text = $"{introText}";
            DisplayLocation();
        }
        
        public void DisplayLocation(bool additive = false)
        {
            string description = $"{playerView.currentLocation.description}\n\n";
            description += $"{playerView.currentLocation.GetConnectionsText()}";
            description += $"{playerView.currentLocation.GetItemsText()}";

            if (additive == true)
            {
                currentText.text = $"{currentText.text} \n{description}";
            }
            else
            {
                currentText.text = $"{description}";
            }
        }
        
        public void TextEntered()
        {
            Debug.Log($"Text entered");
            LogCurrentText();
            ProcessInput(textEntryField.text);
            textEntryField.text = $"";
        }
        
        public void LogCurrentText()
        {
            historyText.text += $"\n\n";
            historyText.text += $"{currentText.text}";
            historyText.text += $"\n\n";
            historyText.text += $"{textEntryField.text}";
        }
        
        public void ProcessInput(string input)
        {
            input = input.ToLower();
            char[] delimiter = { ' ' };
            string[] separatedWords = input.Split(delimiter);

            foreach (ActionSO action in actions)
            {
                if (action.keyword.ToLower() == separatedWords[0])
                {
                    if (separatedWords.Length > 1)
                    {
                        action.RespondToInput(this, separatedWords[1]);
                    }
                    else
                    {
                        action.RespondToInput(this, "");
                    }
                    return;
                }
            }
            currentText.text = $"Nothing happens! Having trouble? Type Help";
        }
    }
}
