using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsIn : MonoBehaviour
{
    [Header("RccCamera")]
    public GameObject RCC_Camera;
    [Header("Canvas")]
    public GameObject Rcccanvas;
    [Header("FPS")]
    public  GameObject FPS;
    [Header("UISVehicle")]
    public GameObject UisInVehicle;
    void Start()
    {
        if (PlayerPrefs.GetInt("loadlevel") == 0 && PlayerPrefs.GetInt("Env")==1)
        {
            FPS.SetActive(true);
            Rcccanvas.SetActive(false);
            RCC_Camera.SetActive(false);
        }
        else
        {
            FPS.SetActive(false);
            Rcccanvas.SetActive(true);
            RCC_Camera.SetActive(true);
        }
    }

    public void EnterCar()
    {
        if (!UisInVehicle.activeInHierarchy)
        {
            Rcccanvas.SetActive(true);
            RCC_Camera.SetActive(true);
        }
    }
}
