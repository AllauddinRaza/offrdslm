using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weatherselection : MonoBehaviour
{
    public Text Coins;
    public GameObject _lockImage;
    public void Start()
    {
        
            _lockImage.SetActive(false);
           
        
        Coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }
    public void winter()
    {
        
            PlayerPrefs.SetInt("Env", 2);
            MenuManager.Instance.OpenMenu("Day/night");
        
    }
    public void atumun()
    {
        PlayerPrefs.SetInt("Env", 1);
        MenuManager.Instance.OpenMenu("Day/night");
    }
    public void sammer()
    {
        PlayerPrefs.SetInt("Env", 1);
        MenuManager.Instance.OpenMenu("Day/night");
    }
    public void selectedBTN()
    {

        PlayerPrefs.SetInt("Env", PlayerPrefs.GetInt("Env"));
        MenuManager.Instance.OpenMenu("Day/night");
    }
}
