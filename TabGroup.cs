using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

namespace JM9CrazyCode.TabSystem
{
    public class TabGroup : MonoBehaviour
    {
        public List<TabButton> tabButtons;
        [FormerlySerializedAs("tapGroupConfig")] public TabGroupConfig tabGroupConfig;
        public TabButton selectedTab;
        public List<GameObject> toggleObjects;

        private void Start()
        {
            Assert.IsNotNull(tabGroupConfig);
            Assert.IsNotNull(tabButtons);
            foreach (var btn in tabButtons)
            {
                btn.Init(this, tabGroupConfig.tabIdle, tabGroupConfig.tabActive, tabGroupConfig.tabHover);
            }
        }

        public void GetTapButtonsFromChild()
        {
            tabButtons = GetComponentsInChildren<TabButton>(true).ToList();
        }

        public void ClearSubscribedTabButtons()
        {
            tabButtons = new List<TabButton>();
        }
        //TODO Pending One click find tabButton Function from a transform(?)


        public void OnTabEnter(TabButton tabButton)
        {
            ResetTabs();
            if (selectedTab == null || tabButton != selectedTab)
            {
                tabButton.SetSprite(TabButtonState.Hover);
            }
        }

        public void OnTabExit(TabButton tabButton)
        {
            ResetTabs();
        }

        public void OnTabSelected(TabButton tabButton)
        {
            if (selectedTab != null)
            {
                selectedTab.Deselect();
            }

            selectedTab = tabButton;
            selectedTab.Select();
            ResetTabs();
            tabButton.SetSprite(TabButtonState.Active);
            int index = tabButton.transform.GetSiblingIndex();
            for (int i = 0; i < toggleObjects.Count; i++)
            {
                if (i == index)
                {
                    toggleObjects[i].SetActive(true);
                }
                else
                {
                    toggleObjects[i].SetActive(false);
                }
            }
        }

        public void ResetTabs()
        {
            foreach (TabButton btns in tabButtons)
            {
                if (selectedTab != null && btns == selectedTab)
                    continue;

                btns.SetSprite(TabButtonState.Idle);
            }
        }
    }
}