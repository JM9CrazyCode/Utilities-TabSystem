using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;
    public void Subscribe(TabButton tabButton)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(tabButton);
    }
    public void OnTabEnter(TabButton tabButton)
    {
        ResetTabs();
        if(selectedTab == null || tabButton != selectedTab)
        {
        tabButton.background.sprite = tabHover;
        }
    }
    public void OnTabExit(TabButton tabButton)
    { 
        ResetTabs();
    }
    public void OnTabSelected(TabButton tabButton)
    {
        if(selectedTab != null)
        {
            selectedTab.Deselect();
        }
        selectedTab = tabButton;
        selectedTab.Select();
        ResetTabs();
        tabButton.background.sprite = tabActive;
        int index = tabButton.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if(i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }
    public void ResetTabs()
    {
        foreach(TabButton btns in tabButtons)
        {
            if(selectedTab != null && btns == selectedTab)
            {
                continue;
            }
            btns.background.sprite = tabIdle;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
