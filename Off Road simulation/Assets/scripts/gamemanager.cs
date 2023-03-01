using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject _environment;
    public GameObject[] _Player;
    public GameObject[] _spwanpoints;
    public void Awake()
    {
        _environment.SetActive(true);
    }
    void Start()
    {
        _Player[CarSelection.selectedIndex].SetActive(true);
        //_Player[CarSelection.selectedIndex].GetComponent<RCC_AICarController>().enabled = false;
        Instantiate(_Player[CarSelection.selectedIndex+1],_spwanpoints[CarSelection.selectedIndex].transform.position, _spwanpoints[CarSelection.selectedIndex].transform.rotation);

    }

   
}
