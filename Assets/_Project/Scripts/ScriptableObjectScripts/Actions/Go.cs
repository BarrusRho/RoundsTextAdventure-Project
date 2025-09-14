using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(menuName = "RoundsTextAdventure/Actions/Go")]
    public class Go : ActionSO
    {
        public override void RespondToInput(GameplayCoordinator gameplayCoordinator, string noun)
        {
            if (gameplayCoordinator.playerView.CanChangeLocation(gameplayCoordinator, noun))
            {
                gameplayCoordinator.DisplayLocation();
            }
            else
            {
                gameplayCoordinator.currentText.text = $"You cannot go that way";
            }
        }
    }
}
