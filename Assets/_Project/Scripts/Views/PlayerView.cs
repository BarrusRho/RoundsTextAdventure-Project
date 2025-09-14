using System.Collections.Generic;

namespace RoundsTextAdventure
{
    public class PlayerView : GameplayViewBase
    {
        public Location currentLocation;
        public List<Item> inventory = new List<Item>();

        public bool CanChangeLocation(GameplayCoordinator gameplayCoordinator, string connectionNoun)
        {
            var connection = currentLocation.GetConnection(connectionNoun);
            if (connection != null)
            {
                if (connection.isConnectionEnabled == true)
                {
                    currentLocation = connection.location;
                    return true;
                }
            }
            return false;
        }

        public void Teleport(GameplayCoordinator gameplayCoordinator, Location destination)
        {
            currentLocation = destination;
        }

        internal bool CanUseItem(GameplayCoordinator gameplayCoordinator, Item item)
        {
            if (item.targetItem == null)
            {
                return true;
            }
            if (HasItem(item.targetItem))
            {
                return true;
            }
            if (currentLocation.HasItem(item.targetItem))
            {
                return true;
            }

            return false;
        }

        private bool HasItem(Item itemToCheck)
        {
            foreach (var item in inventory)
            {
                if (item == itemToCheck && item.isItemEnabled)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasItemByName(string noun)
        {
            foreach (var item in inventory)
            {
                if (item.itemName.ToLower() == noun.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        internal bool CanTalkToItem(GameplayCoordinator gameplayCoordinator, Item item)
        {
            return item.canPlayerTalkTo;
        }

        internal bool CanGiveToItem(GameplayCoordinator gameplayCoordinator, Item item)
        {
            return item.canPlayerGiveTo;
        }
    }
}
