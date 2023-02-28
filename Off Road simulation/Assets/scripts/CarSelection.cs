using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    public GameObject[] _vehicles;
    public Transform spawnPosition;    
    public static int selectedIndex = 0;
    void Start()
    {
        SpawnVehicle();
      
    }


   
    public void NextVehicle()
    {

        selectedIndex++;

        // If index exceeds maximum, return to 0.
        if (selectedIndex > _vehicles.Length - 1)
            selectedIndex = 0;

        SpawnVehicle();

    }

    // Decreasing selected index, disabling all other vehicles, enabling current selected vehicle.
    public void PreviousVehicle()
    {

        selectedIndex--;

        // If index is below 0, return to maximum.
        if (selectedIndex < 0)
            selectedIndex = _vehicles.Length - 1;

        SpawnVehicle();

    }
    public void SpawnVehicle()
    {
       
        for (int i = 0; i < _vehicles.Length; i++)
        {
            _vehicles[i].SetActive(false);
             //_vehicles[i].gameObject.SetActive(false);
            //if (i == selectedIndex) { continue; }

        }
        _vehicles[selectedIndex].SetActive(true);
        //_vehicles[selectedIndex-1].SetActive(false);





        // And enabling only selected vehicle.


        //_vehicles[selectedIndex] =  Instantiate(_vehicles[selectedIndex], spawnPosition.position,spawnPosition.rotation);
        
    }
}
