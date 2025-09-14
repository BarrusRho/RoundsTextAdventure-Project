using UnityEngine;

namespace RoundsTextAdventure
{
    [CreateAssetMenu(menuName = "RoundsTextAdventure/Actions/Help")]
    public class Help : ActionSO
    {
        public override void RespondToInput(GameplayCoordinator gameplayCoordinator, string noun)
        {
            gameplayCoordinator.currentText.text = $"Type a Verb followed by a Noun (e.g. \"Go North\")";
            gameplayCoordinator.currentText.text += $"\nAllowed verbs: \nGo, Examine, Get, Give, Use, Inventory, TalkTo, Say, Help";
        }
    }

}
