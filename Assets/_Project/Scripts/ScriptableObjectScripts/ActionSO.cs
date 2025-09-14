using UnityEngine;

namespace RoundsTextAdventure
{
    public abstract class ActionSO : ScriptableObject
    {
        public string keyword;
        public abstract void RespondToInput(GameplayCoordinator gameplayCoordinator, string noun);
    }
}
