using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iapmainmenu : MonoBehaviour
{
    public static iapmainmenu Instance;
    [SerializeField] Menu[] menus;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
           
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                OpenMenu(menus[i]);
            }
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }
    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }
    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }

    private void Start()
    {
        StartCoroutine(Iap_Show());
    }
    IEnumerator Iap_Show()
    {
        yield return new WaitForSeconds(5f);
        OpenMenu("iapeverything");
    }

    public void IAPUnlockEverything()
    {

    }
    public void IAPUnlockAllLevels()
    {

    } public void IAPUnlockAllTrucks()
    {

    }
}
