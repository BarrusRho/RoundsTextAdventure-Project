using System.Collections.Generic;
using UnityEngine;

namespace RoundsTextAdventure
{
    public class UIViewRegistry : MonoBehaviour
    {
        public List<UIViewEntry> views;

        [System.Serializable]
        public struct UIViewEntry
        {
            public UIViewType uiViewType;
            public UIViewBase uiView;
        }
    }
}
