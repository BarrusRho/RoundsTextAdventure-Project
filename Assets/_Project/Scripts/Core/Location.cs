using System.Collections.Generic;
using UnityEngine;

namespace RoundsTextAdventure
{
    public class Location : MonoBehaviour
    {
        public string locationName;

        [TextArea]
        public string description;
        public Connection[] connections;
        public List<Item> items = new List<Item>();

        public string GetConnectionsText()
        {
            var result = $"";

            foreach (var connection in connections)
            {
                if (connection.isConnectionEnabled)
                {
                    result += $"{connection.description}\n";
                }
            }
            return result;
        }

        public Connection GetConnection(string connectionNoun)
        {
            foreach (var connection in connections)
            {
                if (connection.connectionName.ToLower() == connectionNoun.ToLower())
                {
                    return connection;
                }
            }
            return null;
        }


        public string GetItemsText()
        {
            if (items.Count == 0)
            {
                return $"";
            }
            var result = $"You see ";
            var first = true;
            foreach (var item in items)
            {
                if (item.isItemEnabled)
                {
                    if (first == false)
                    {
                        result += $" and ";
                    }
                    result += $"{item.itemDescription}";
                    first = false;
                }
            }
            result += $"\n";
            return result;
        }

        internal bool HasItem(Item itemToCheck)
        {
            foreach (var item in items)
            {
                if (item == itemToCheck && item.isItemEnabled)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

