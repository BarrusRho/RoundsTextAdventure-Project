using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(fileName = "GameVariables", menuName = "RoundsTextAdventure/GameVariables")]
    public class GameVariablesSO : ScriptableObject
    {
        [Header("Game Over")] 
        public float gameOverDelay = 1.5f;
    }
}
