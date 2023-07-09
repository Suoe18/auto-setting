using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class TabSystem
{
    public List<GameObject> tabPanels;
    [SerializeField] public List<Button> tabButtons;

    public Color selectedColor;
    public Color deselectedColor;

    private int activeTabIndex = 0;

    public void OnClick(int index)
    {
        if (index == activeTabIndex)
            return;
        tabButtons[activeTabIndex].interactable = true;
        tabButtons[activeTabIndex].GetComponent<Image>().color = deselectedColor;


        tabButtons[index].interactable = false;

        tabButtons[index].GetComponent<Image>().color = selectedColor;
        //tabButtons[index].colors. = selectedColor;

        tabPanels[activeTabIndex].SetActive(false);
        tabPanels[index].SetActive(true);

        activeTabIndex = index;
    }

    public void LogShow()
    {
        Debug.Log("show");
    }
}
