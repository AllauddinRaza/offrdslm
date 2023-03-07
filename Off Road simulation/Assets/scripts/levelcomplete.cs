using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcomplete : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Retry()
    {
        SceneManager.LoadScene("GamePlay");
        this.gameObject.SetActive(false);
    }
    public void Next()
    {
        PlayerPrefs.SetInt("loadlevel", PlayerPrefs.GetInt("loadlevel")+1);
        SceneManager.LoadScene("GamePlay");
      
        this.gameObject.SetActive(false);
    }
}
