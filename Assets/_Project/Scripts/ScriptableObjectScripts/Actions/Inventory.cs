using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(menuName = "RoundsTextAdventure/Actions/Inventory")]
    public class Inventory : ActionSO
    {
        public override void RespondToInput(GameplayCoordinator gameplayCoordinator, string noun)
        {
            if (gameplayCoordinator.playerView.inventory.Count == 0)
            {
                gameplayCoordinator.currentText.text = $"You have no items in your inventory";
                return;
            }

            var result = $"You have ";
            var first = true;
            foreach (var item in gameplayCoordinator.playerView.inventory)
            {
                if (first)
                {
                    result += $"a {item.itemName}";
                }
                else
                {
                    result += $" and a {item.itemName}.";
                }
                first = false;
            }
            gameplayCoordinator.currentText.text = $"{result}";
        }
    }
}
