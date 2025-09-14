using UnityEngine;

namespace RoundsTextAdventure
{
    public class Item : MonoBehaviour
    {
        public string itemName;

        [TextArea]
        public string itemDescription;
        public bool canPlayerTakeItem;
        public bool isItemEnabled = true;
        public bool canPlayerTalkTo = false;
        public bool canPlayerGiveTo = false;
        public Item targetItem = null;
        public Interaction[] interactions;

        public bool InteractWith(GameplayCoordinator gameplayCoordinator, string actionKeyword, string noun = "")
        {
            foreach (Interaction interaction in interactions)
            {
                if (interaction.action.keyword == actionKeyword)
                {
                    if (noun != "" && noun.ToLower() != interaction.textToMatch.ToLower())
                    {
                        continue;
                    }
                    foreach (Item disableItem in interaction.itemsToDisable)
                    {
                        disableItem.isItemEnabled = false;
                    }
                    foreach (Item enableItem in interaction.itemsToEnable)
                    {
                        enableItem.isItemEnabled = true;
                    }

                    foreach (Connection disableConnection in interaction.connectionsToDisable)
                    {
                        disableConnection.isConnectionEnabled = false;
                    }
                    foreach (Connection enableConnection in interaction.connectionsToEnable)
                    {
                        enableConnection.isConnectionEnabled = true;
                    }

                    if ( interaction.teleportLocation != null)
                    {
                        gameplayCoordinator.playerView.Teleport(gameplayCoordinator, interaction.teleportLocation);
                    }
                    
                    gameplayCoordinator.currentText.text = $"{interaction.response}";
                    gameplayCoordinator.DisplayLocation(true);

                    return true;
                }
            }
            return false;
        }
    }
}

