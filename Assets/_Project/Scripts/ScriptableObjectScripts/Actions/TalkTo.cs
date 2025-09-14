using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(menuName = "RoundsTextAdventure/Actions/TalkTo")]
    public class TalkTo : ActionSO
    {
        public override void RespondToInput(GameplayCoordinator gameplayCoordinator, string noun)
        {
            if (TalkToItem(gameplayCoordinator, gameplayCoordinator.playerView.currentLocation.items, noun))
            {
                return;
            }
            gameplayCoordinator.currentText.text = $"There is no {noun} here!";
        }

        private bool TalkToItem(GameplayCoordinator gameplayCoordinator, List<Item> items, string noun)
        {
            {
                foreach (var item in items.Where(item => item.itemName == noun && item.isItemEnabled))
                {
                    if (gameplayCoordinator.playerView.CanTalkToItem(gameplayCoordinator, item))
                    {
                        if (item.InteractWith(gameplayCoordinator, "talkto"))
                        {
                            return true;
                        }
                    }
                    gameplayCoordinator.currentText.text = $"The {noun} does not respond to you.";
                    return true;
                }

                return false;
            }
        }
    }
}
