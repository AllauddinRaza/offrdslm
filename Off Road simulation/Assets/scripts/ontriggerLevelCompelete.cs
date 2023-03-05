using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontriggerLevelCompelete : MonoBehaviour
{
    public GameObject _confati;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { gamemanager.Gm.LevelCompelet();

            _confati.SetActive(true);
        }
    }
}
