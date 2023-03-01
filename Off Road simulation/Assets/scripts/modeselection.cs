using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modeselection : MonoBehaviour
{
    public Text Coins;
    private void Awake()
    {
        PlayerPrefs.SetInt("Mode", 1);
    }
    private void Start()
    {
        Coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }
    public void freeMode()
    {
        PlayerPrefs.SetInt("Mode", 1);
      MenuManager.Instance.OpenMenu("Weather");
    }
    public void TimeMode()
    {
        PlayerPrefs.SetInt("Mode", 2);
        MenuManager.Instance.OpenMenu("Weather");
    }
 public void selectedBTN()
    { 

        PlayerPrefs.SetInt("Mode", PlayerPrefs.GetInt("Mode"));
        MenuManager.Instance.OpenMenu("Weather");
    }
}
