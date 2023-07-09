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

    public void OnClick(int index)
    {
        for (int i = 0; i < tabPanels.Count; i++)
        {
            if (i == index)
            {
                tabPanels[i].SetActive(true);
            }
            else
            {
                tabPanels[i].SetActive(false);
            }
        }
    }

    public void LogShow()
    {

        Debug.Log("show");
    }
}
