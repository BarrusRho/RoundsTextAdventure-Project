namespace RoundsTextAdventure
{
    public class GameConfigService
    {
        public float GameOverDelay { get; }

        public GameConfigService(GameVariablesSO gameVariablesSO)
        {
            GameOverDelay = gameVariablesSO.gameOverDelay;
        }

        public void Initialise() { }
    }
}
