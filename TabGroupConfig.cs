using UnityEngine;

namespace JM9CrazyCode.TabSystem
{
    [CreateAssetMenu(menuName = "JM9CrazyCode/TapSystem/Create TabGroupConfig", fileName = "TabGroupConfig", order = 0)]
    public class TabGroupConfig : ScriptableObject
    {
        public Sprite tabIdle;
        public Sprite tabHover;
        public Sprite tabActive;
    }
}