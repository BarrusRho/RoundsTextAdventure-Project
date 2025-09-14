using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(menuName = "RoundsTextAdventure/Actions/Examine")]
    public class Examine : ActionSO
    {
        public override void RespondToInput(GameplayCoordinator gameplayCoordinator, string noun)
        {
            if (CheckItems(gameplayCoordinator, gameplayCoordinator.playerView.currentLocation.items, noun))
            {
                return;
            }
            if (CheckItems(gameplayCoordinator, gameplayCoordinator.playerView.inventory, noun))
            {
                return;
            }

            gameplayCoordinator.currentText.text = $"You cannot see a {noun}";
        }

        private bool CheckItems(GameplayCoordinator gameplayCoordinator, List<Item> items, string noun)
        {
            foreach (var item in items.Where(item => item.itemName == noun))
            {
                if (item.InteractWith(gameplayCoordinator, "examine"))
                {
                    return true;
                }
                gameplayCoordinator.currentText.text = $"You see {item.itemDescription}";
                return true;
            }

            return false;
        }
    }
}
