using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Concent : MonoBehaviour
{
    public GameObject _splash;
    public GameObject _concentPanel;
    public void Awake()
    {
        if (PlayerPrefs.GetInt("concent") == 1)
        {
            _splash.SetActive(true);
            StartCoroutine(SplashScreen());
        }
        else
        {
            _concentPanel.SetActive(true);
          
        }
    }
    public void Accept()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("concent", 1);
    }
    public void Reject()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("concent", 1);
    }
    IEnumerator  SplashScreen()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }

}
