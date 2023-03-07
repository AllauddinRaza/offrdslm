using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
   
    public Slider _speed, _break, _suspention;
    public Text Coins;
    public GameObject _lockImage,_selected,_buyBTN;
    public GameObject[] _vehicles;
    public int[] _vehiclesPrice;
    public Text _vehiclespriceText;
    public Transform spawnPosition;    
    public static int selectedIndex = 0;
    private void Awake()
    {
        PlayerPrefs.SetInt("Coins",10000);
        RenderSettings.skybox = dayNight._sky;
    }
    void Start()
    {
      
        SpawnVehicle();
        Lock_check();
        Coins.text = PlayerPrefs.GetInt("Coins").ToString();
        _vehiclespriceText.text = _vehiclesPrice[selectedIndex].ToString();
       

    }


   
    public void NextVehicle()
    {

        selectedIndex++;

        // If index exceeds maximum, return to 0.
        if (selectedIndex > _vehicles.Length - 1)
            selectedIndex = 0;
        
        SpawnVehicle();
        Lock_check();
        _vehiclespriceText.text = _vehiclesPrice[selectedIndex].ToString();
    }

    // Decreasing selected index, disabling all other vehicles, enabling current selected vehicle.
    public void PreviousVehicle()
    {

        selectedIndex--;

        // If index is below 0, return to maximum.
        if (selectedIndex < 0)
            selectedIndex = _vehicles.Length - 1;
       
        SpawnVehicle();
        Lock_check();
        _vehiclespriceText.text = _vehiclesPrice[selectedIndex].ToString();
    }
    public void SpawnVehicle()
    {
       
        for (int i = 0; i < _vehicles.Length; i++)
        {
            _vehicles[i].SetActive(false);
         
        }
        _vehicles[selectedIndex].SetActive(true);
 

        float v = Random.Range(0f, 1f);float b = Random.Range(0f, 1f);float s = Random.Range(0f, 1f);
   
        _speed.value = v; _break.value = b; _suspention.value = s;
   
      
    } public void Lock_check()
    {
        for (int i = 0; i <_vehicles.Length; i++)
        {
            if (PlayerPrefs.GetInt("vehiclelock" + selectedIndex) == 1)
            {
                _lockImage.SetActive(false);
                _buyBTN.SetActive(false);
                _vehiclesPrice[selectedIndex] = 0;
            }
            else
            {
                _lockImage.SetActive(true);
                _buyBTN.SetActive(true);
            }
        }


    

        }


    
    public void VehicleBUy()
    {
        if(_vehiclesPrice[selectedIndex] <= PlayerPrefs.GetInt("Coins")){
            PlayerPrefs.SetInt("vehiclelock" + selectedIndex, 1);
            _vehiclesPrice[selectedIndex] = 0;
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins") - _vehiclesPrice[selectedIndex]);
            Lock_check();
        }
     
    }
    public void UnlockAllTrucks()
    {
        iapmainmenu.Instance.OpenMenu("iaptruck");
    }
    public void mainmenuload()
    {
        //PlayerPrefs.SetInt("CompletedLevels", PlayerPrefs.GetInt("CompletedLevels")+1);
        SceneManager.LoadScene("MainMenu");
        MenuManager.Instance.OpenMenu("LevelSelection");
    }
    public void Gameplayload()
    {
     
        SceneManager.LoadScene("LoadingScreen");
       
    }
}
