using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weatherselection : MonoBehaviour
{
    public Text Coins;
    public GameObject _lockImage;
    private void Start()
    {
        Coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }
    public void winter()
    {
        if (PlayerPrefs.GetInt("CompletedLevels") > 12)
        {
            _lockImage.SetActive(false);
            PlayerPrefs.SetInt("Env", 2);
            MenuManager.Instance.OpenMenu("Day/night");
        }
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
