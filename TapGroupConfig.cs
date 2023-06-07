using UnityEngine;

namespace JM9CrazyCode.TapSystem
{
    [CreateAssetMenu(menuName = "JM9CrazyCode/TapSystem/Create TapGroupConfig", fileName = "TapGroupConfig", order = 0)]
    public class TapGroupConfig : ScriptableObject
    {
        public Sprite tabIdle;
        public Sprite tabHover;
        public Sprite tabActive;
    }
}