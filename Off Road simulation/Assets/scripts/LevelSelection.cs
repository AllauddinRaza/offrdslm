using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Text Coins;
    public GameObject[] _lockLevel;
    public GameObject[] _level;
   
  private  void Start()
    {
            PlayerPrefs.SetInt("SelectedLevels", PlayerPrefs.GetInt("CompletedLevels"));
        
      
        for (int i = 1; i < 15; i++)
        {
            _level[PlayerPrefs.GetInt("SelectedLevels")+i].transform.GetComponent<Button>().interactable = false;
            _lockLevel[PlayerPrefs.GetInt("SelectedLevels")+i].SetActive(true);
            
            DOTween.Play(_level[PlayerPrefs.GetInt("SelectedLevels")]);

        }

        Coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }

  public void load_TruckScene(int select)
    {
        PlayerPrefs.SetInt("loadlevel",select);
        SceneManager.LoadScene("TruckSelection");
    }
   
}
