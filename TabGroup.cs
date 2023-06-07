using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

namespace JM9CrazyCode.TapSystem
{
    public class TabGroup : MonoBehaviour
    {
        public List<TabButton> tabButtons;
        public TapGroupConfig tapGroupConfig;
        public TabButton selectedTab;
        public List<GameObject> toggleObjects;

        private void Start()
        {
            Assert.IsNotNull(tapGroupConfig);
            Assert.IsNotNull(tabButtons);
            foreach (var btn in tabButtons)
            {
                btn.Init(this, tapGroupConfig.tabIdle, tapGroupConfig.tabActive, tapGroupConfig.tabHover);
            }
        }
        //TODO Pending One click find tabButton Function from a transform(?)


        public void OnTabEnter(TabButton tabButton)
        {
            ResetTabs();
            if (selectedTab == null || tabButton != selectedTab)
            {
                tabButton.SetSprite(TapButtonState.Hover);
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
            tabButton.SetSprite(TapButtonState.Active);
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

                btns.SetSprite(TapButtonState.Idle);
            }
        }
    }
}