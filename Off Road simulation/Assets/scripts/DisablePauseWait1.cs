using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisablePauseWait : MonoBehaviour
{
    public bool pauseScreen;
    private int waitTime = 3;
    public Text waitText;
    public GameObject waitPanel, pausePanel;

    private void OnEnable ()
    {
        if (pauseScreen)
        {
            waitTime = 3;
            waitText.text = waitTime.ToString();
        }
        waitPanel.SetActive(true);
        pausePanel.SetActive(false);
        StartCoroutine (Delay ());
    }

    IEnumerator Delay ()
    {
        if (pauseScreen)
        {
            yield return new WaitForSecondsRealtime(0.8f);
            waitText.text = (waitTime - 1).ToString();
            yield return new WaitForSecondsRealtime(0.8f);
            waitText.text = (waitTime - 2).ToString();
            yield return new WaitForSecondsRealtime(0.8f);
            waitText.text = (waitTime - 3).ToString();
        }
        else
        {
            yield return new WaitForSecondsRealtime(3.0f);
        }
        ShowPausePanel ();
    }

    public void ShowPausePanel ()
    {
        if ( AdsManagerWrapper.Instance )
            AdsManagerWrapper.Instance.ShowGpInterstitial ();

        pausePanel.SetActive (true);
        waitPanel.SetActive (false);
    }
    //private void OnDisable()
    //{
    //   pausePanel.SetActive
    //}
}
