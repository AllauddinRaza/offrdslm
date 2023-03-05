using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayNight : MonoBehaviour
{
    public Material[] _skybox;
    public Text Coins;
    public static Material _sky;
    private void Awake()
    {
        PlayerPrefs.SetInt("day/night", 1);
    }
    private void Start()
    {
        Coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }
    public void day()
    {
        PlayerPrefs.SetInt("day/night", 1);
        MenuManager.Instance.OpenMenu("LevelSelection");
        RenderSettings.skybox = _skybox[0];
        _sky = RenderSettings.skybox;
    }
    public void night()
    {
        PlayerPrefs.SetInt("Weather", 2);
        MenuManager.Instance.OpenMenu("LevelSelection");
        RenderSettings.skybox = _skybox[1];
        _sky = RenderSettings.skybox;
    }
  
    public void selectedBTN()
    {

        PlayerPrefs.SetInt("day/night", PlayerPrefs.GetInt("day/night"));
        MenuManager.Instance.OpenMenu("LevelSelection");
    }
}
