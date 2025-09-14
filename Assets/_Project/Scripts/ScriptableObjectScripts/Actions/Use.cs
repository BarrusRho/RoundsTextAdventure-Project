using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(menuName = "RoundsTextAdventure/Actions/Use")]
    public class Use : ActionSO
    {
        public override void RespondToInput(GameplayCoordinator gameplayCoordinator, string noun)
        {
            if (UseItems(gameplayCoordinator, gameplayCoordinator.playerView.currentLocation.items, noun))
            {
                return;
            }
            if (UseItems(gameplayCoordinator, gameplayCoordinator.playerView.inventory, noun))
            {
                return;
            }

            gameplayCoordinator.currentText.text = $"There is no {noun}.";
        }

        private bool UseItems(GameplayCoordinator gameplayCoordinator, List<Item> items, string noun)
        {
            foreach (var item in items.Where(item => item.itemName == noun))
            {
                if (gameplayCoordinator.playerView.CanUseItem(gameplayCoordinator, item))
                {
                    if (item.InteractWith(gameplayCoordinator, "use"))
                    {
                        return true;
                    }
                }
                gameplayCoordinator.currentText.text = $"The {noun} does nothing.";
                return true;
            }

            return false;
        }
    }
}
