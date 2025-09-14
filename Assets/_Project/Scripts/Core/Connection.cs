using UnityEngine;

namespace RoundsTextAdventure
{    
    public class Connection : MonoBehaviour
    {
        public string connectionName;

        [TextArea]
        public string description;
        public Location location;
        public bool isConnectionEnabled;
    }
}
