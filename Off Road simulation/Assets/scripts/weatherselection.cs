using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weatherselection : MonoBehaviour
{
    public Text Coins;
    private void Awake()
    {
        PlayerPrefs.SetInt("Weather", 1);
    }
    private void Start()
    {
        Coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }
    public void winter()
    {
        PlayerPrefs.SetInt("Weather", 1);
        MenuManager.Instance.OpenMenu("Day/night");
    }
    public void atumun()
    {
        PlayerPrefs.SetInt("Weather", 2);
        MenuManager.Instance.OpenMenu("Day/night");
    }
    public void sammer()
    {
        PlayerPrefs.SetInt("Weather", 3);
        MenuManager.Instance.OpenMenu("Day/night");
    }
    public void selectedBTN()
    {

        PlayerPrefs.SetInt("Weather", PlayerPrefs.GetInt("Weather"));
        MenuManager.Instance.OpenMenu("Day/night");
    }
}
