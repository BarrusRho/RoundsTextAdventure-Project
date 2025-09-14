using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(menuName = "RoundsTextAdventure/Actions/Say")]
    public class Say : ActionSO
    {
        public override void RespondToInput(GameplayCoordinator gameplayCoordinator, string noun)
        {
            if (SayToItem(gameplayCoordinator, gameplayCoordinator.playerView.currentLocation.items, noun))
            {
                return;
            }
            gameplayCoordinator.currentText.text = $"Nothing responds!";
        }

        private bool SayToItem(GameplayCoordinator gameplayCoordinator, List<Item> items, string noun)
        {
            {
                foreach (var item in items.Where(item => item.isItemEnabled))
                {
                    if (gameplayCoordinator.playerView.CanTalkToItem(gameplayCoordinator, item))
                    {
                        if (item.InteractWith(gameplayCoordinator, "say", noun))
                        {
                            return true;
                        }
                    }                        
                    return true;
                }

                return false;
            }
        }
    }
}
