using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausescreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Retry()
    {
        SceneManager.LoadScene("GamePlay");
        this.gameObject.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
}
