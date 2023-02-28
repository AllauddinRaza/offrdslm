using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public GameObject[] _lockLevel;
    public GameObject[] _level;
    //public GameObject[] _selectedLevel;
    // Start is called before the first frame update
    void Start()
    {if(PlayerPrefs.GetInt("CompletedLevels") == null)
        {
            PlayerPrefs.SetInt("SelectedLevels", 0);
          
        }
        else
        {
            PlayerPrefs.SetInt("SelectedLevels", PlayerPrefs.GetInt("CompletedLevels"));
        }
        int index = PlayerPrefs.GetInt("CompletedLevels")+1 ;
        for (int i = index; i < 15; i++)
        {
            _level[i].transform.GetComponent<Button>().interactable = false;
            _lockLevel[i].SetActive(true);
            DOTween.Play(_level[PlayerPrefs.GetInt("SelectedLevels")]);
        }
    }

  public void load_TruckScene()
    {
        SceneManager.LoadScene("TruckSelection");
    }
   
}
