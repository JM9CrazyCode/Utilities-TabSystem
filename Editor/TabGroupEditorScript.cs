#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace JM9CrazyCode.TabSystem
{
    [CustomEditor(typeof(TabGroup))]
    public class TabGroupEditorScript : Editor
    {
        private TabGroup _target;
        private void OnEnable()
        {
            _target = (TabGroup)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Find TabButton in Child"))
            {
                _target.GetTapButtonsFromChild();
            }
            if (GUILayout.Button("Clear Subscribed TabButtons"))
            {
                _target.ClearSubscribedTabButtons();
            }
        }
    }
}
#endif