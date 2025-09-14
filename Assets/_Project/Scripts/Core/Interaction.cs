using System.Collections.Generic;
using UnityEngine;

namespace RoundsTextAdventure
{
    [System.Serializable]
    public class Interaction
    {
        public ActionSO action;

        [TextArea]
        public string response;
        public string textToMatch;

        public List<Item> itemsToDisable = new List<Item>();
        public List<Item> itemsToEnable = new List<Item>();
        public List<Connection> connectionsToDisable = new List<Connection>();
        public List<Connection> connectionsToEnable = new List<Connection>();
        public Location teleportLocation = null;
    }
}
