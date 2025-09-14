using UnityEngine;

namespace RoundsTextAdventure
{
    public class Bootstrapper : MonoBehaviour
    {
        private GameConfigService gameConfigService;
        private AudioService audioService;
        private UIControllerService uiControllerService;
        private GameplayControllerService gameplayControllerService;
        private GameStateService gameStateService;
        
        [SerializeField] private GameVariablesSO gameVariablesSO;
        [SerializeField] private GameCamera gameCamera;
        [SerializeField] private GameplayCoordinator gameplayCoordinator;
        [SerializeField] private AudioClipsSO audioClips;
        [SerializeField] private AudioSource[] audioSources;
        [SerializeField] private UIViewRegistry uiViewRegistry;
        
        private void Awake()
        {
            CreateServices();
            RegisterServices();
            InitialiseServices();
            InitialiseCoordinators();
        }

        private void CreateServices()
        {
            gameConfigService = new GameConfigService(gameVariablesSO);
            uiControllerService = new UIControllerService(uiViewRegistry);
            gameplayControllerService = new GameplayControllerService();
            audioService = new AudioService();
            gameStateService = new GameStateService();
        }

        private void RegisterServices()
        {
            ServiceLocator.RegisterOnce(gameConfigService);
            ServiceLocator.RegisterOnce(gameCamera);
            ServiceLocator.RegisterOnce(uiControllerService);
            ServiceLocator.RegisterOnce(gameplayControllerService);
            ServiceLocator.RegisterOnce(audioService);
            ServiceLocator.RegisterOnce(gameStateService);
        }

        private void InitialiseServices()
        {
            gameConfigService.Initialise();
            gameCamera.Initialise();
            uiControllerService.Initialise();
            gameplayControllerService.Initialise();
            audioService.Initialise(audioClips, audioSources);
            gameStateService.Initialise();
        }

        private void InitialiseCoordinators()
        {
            gameplayCoordinator.Initialise();
        }

        private void OnDestroy()
        {
            gameStateService?.Dispose();
            uiControllerService?.Dispose();
            
            ServiceLocator.Unregister<GameStateService>();
            ServiceLocator.Unregister<UIControllerService>();
            ServiceLocator.Unregister<GameplayControllerService>();
            ServiceLocator.Unregister<GameConfigService>();
            ServiceLocator.Unregister<GameCamera>();
            ServiceLocator.Unregister<AudioService>();
        }
    }
}
