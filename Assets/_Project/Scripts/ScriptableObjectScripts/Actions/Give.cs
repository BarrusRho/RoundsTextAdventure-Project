using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(menuName = "RoundsTextAdventure/Actions/Give")]
    public class Give : ActionSO
    {
        public override void RespondToInput(GameplayCoordinator gameplayCoordinator, string noun)
        {
            if (gameplayCoordinator.playerView.HasItemByName(noun))
            {
                if (GiveToItem(gameplayCoordinator, gameplayCoordinator.playerView.currentLocation.items, noun))
                {
                    return;
                }
                gameplayCoordinator.currentText.text = $"Nothing takes the {noun!}";
                return;
            }
            gameplayCoordinator.currentText.text = $"You do not have {noun} to give";
        }

        private bool GiveToItem(GameplayCoordinator gameplayCoordinator, List<Item> items, string noun)
        {
            {
                foreach (var item in items.Where(item => item.isItemEnabled))
                {
                    if (gameplayCoordinator.playerView.CanGiveToItem(gameplayCoordinator, item))
                    {
                        if (item.InteractWith(gameplayCoordinator, "give", noun))
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
