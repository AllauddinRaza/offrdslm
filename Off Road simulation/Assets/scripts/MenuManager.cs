using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public enum _pannels { Loading,MainMenu,GamePlay };
    public static MenuManager Instance;
    [SerializeField] Menu[] menus;
    public void Awake()
    {
        Instance = this;
    }
    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                OpenMenu(menus[i]);
            }else if (menus[i].open)
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
    } public void CloseMenu(Menu menu)
    {
        menu.Close();
    }

    public void Loading()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
}
