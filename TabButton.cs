using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace JM9CrazyCode.TabSystem
{
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        public TabGroup tabGroup { get; private set; }
        public Image background;
        public UnityEvent onTabSelected;
        public UnityEvent onTabDeselected;
        private Sprite m_Idle;
        private Sprite m_Active;
        private Sprite m_Hover;

        public void Init(TabGroup tabGroup, Sprite idle, Sprite active, Sprite hover)
        {
            this.tabGroup = tabGroup;
            m_Idle = idle;
            m_Active = active;
            m_Hover = hover;
        }

        public void SetSprite(TabButtonState tabButtonState)
        {
            switch (tabButtonState)
            {
                case TabButtonState.Idle:
                    background.sprite = m_Idle;
                    break;
                case TabButtonState.Active:
                    background.sprite = m_Active;
                    break;
                case TabButtonState.Hover:
                    background.sprite = m_Hover;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tabButtonState), tabButtonState, null);
            }
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            tabGroup.OnTabSelected(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tabGroup.OnTabEnter(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tabGroup.OnTabExit(this);
        }

        public void Select()
        {
            onTabSelected?.Invoke();
        }

        public void Deselect()
        {
            onTabDeselected?.Invoke();
        }

        // Start is called before the first frame update
        void Start()
        {
            background = GetComponent<Image>();
            Assert.IsNotNull(background);
        }
    }
}