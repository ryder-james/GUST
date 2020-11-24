using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabControler : MonoBehaviour
{
    [SerializeField] public List<Tab> tabs;
    [SerializeField] public List<GameObject> menus;
    [SerializeField] public Tab selectedTab;
    [SerializeField] public TMP_Text changedText;

    public void Subscribe(Tab tab)
    {
        if (tabs == null)
        {
            tabs = new List<Tab>();
        }

        tabs.Add(tab);

    }

    public void Enter(Tab tab)
    {
    }

    public void Exit(Tab tab)
    {
    }

    public void Clicked(Tab tab)
    {
        selectedTab = tab;
        changedText.text = tab.GetComponentInChildren<TMP_Text>().text;
        int index = tab.transform.GetSiblingIndex();
        for (int i = 0; i < menus.Count; i++)
        {
            if (i == index)
            {
                menus[i].SetActive(true);
            }
            else
            {
                menus[i].SetActive(false);
            }
        }
    }

}
