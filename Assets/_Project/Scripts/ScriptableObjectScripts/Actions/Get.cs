using System.Linq;
using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(menuName = "RoundsTextAdventure/Actions/Get")]
    public class Get : ActionSO
    {
        public override void RespondToInput(GameplayCoordinator gameplayCoordinator, string noun)
        {
            foreach (var item in gameplayCoordinator.playerView.currentLocation.items.Where(item => item.isItemEnabled && item.itemName == noun).Where(item => item.canPlayerTakeItem))
            {
                gameplayCoordinator.playerView.inventory.Add(item);
                gameplayCoordinator.playerView.currentLocation.items.Remove(item);
                gameplayCoordinator.currentText.text = $"You take the {noun}";
                return;
            }

            gameplayCoordinator.currentText.text = $"You cannot get that";
        }
    }
}
