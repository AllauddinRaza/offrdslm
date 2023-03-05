using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public static gamemanager Gm;
    [Header("Players")]
    public GameObject[] _Player;
    [Header("Enviroment")]
    public GameObject _enviroSA,_enviroSnow,_enviromentReward; 
    public int _intENV ;
    [Header("SUMMER ANTUMN")]
    public GameObject[] _levelsSA, SpwanSA;
    [Header("SNOW")]
    public GameObject[] _levelsSnow, SpwanSnow; 
    [Header("Reward")]
    public GameObject SpwanReward; 
    [Header("GamePanels")]
    public GameObject _compelete,_failed,_pause;
    [Header("fordragforce")]
    private float dd;
    public void Awake()
    {
        Time.timeScale = 1f;
        RenderSettings.skybox = dayNight._sky;
        if (Gm == null)
        {
            Gm = this;
            //DontDestroyOnLoad(this.gameObject);

        }
        //else
        //{
        //    Destroy(this.gameObject);
        //}

    }
    void Start()
    {
        _intENV = PlayerPrefs.GetInt("Env");
        switch (_intENV)
        {
          
            case 3:
                _enviromentReward.SetActive(true);
                _Player[CarSelection.selectedIndex].SetActive(true);
                Instantiate(_Player[CarSelection.selectedIndex], SpwanReward.transform.position, SpwanReward.transform.rotation);
                break;
            case 2:
                _enviroSnow.SetActive(true);
                _levelsSnow[PlayerPrefs.GetInt("loadlevel")].SetActive(true);
                _Player[CarSelection.selectedIndex].SetActive(true);
                Instantiate(_Player[CarSelection.selectedIndex], SpwanSnow[PlayerPrefs.GetInt("loadlevel")].transform.position, SpwanSnow[PlayerPrefs.GetInt("loadlevel")].transform.rotation);
                break;
            case 1:
                _enviroSA.SetActive(true);
                _levelsSA[PlayerPrefs.GetInt("loadlevel")].SetActive(true);
                _Player[CarSelection.selectedIndex].SetActive(true);
                Instantiate(_Player[CarSelection.selectedIndex], SpwanSA[PlayerPrefs.GetInt("loadlevel")].transform.position, SpwanSA[PlayerPrefs.GetInt("loadlevel")].transform.rotation);
                break;
            default:
                _enviroSA.SetActive(true);
                _levelsSA[PlayerPrefs.GetInt("loadlevel")].SetActive(true);
                _Player[CarSelection.selectedIndex].SetActive(true);
                Instantiate(_Player[CarSelection.selectedIndex], SpwanSA[PlayerPrefs.GetInt("loadlevel")].transform.position, SpwanSA[PlayerPrefs.GetInt("loadlevel")].transform.rotation);
                break;
        }
     
        //_Player[CarSelection.selectedIndex].GetComponent<RCC_AICarController>().enabled = false;
  

    }

   public void LevelCompelet()
    {
        Time.timeScale = 0.2f;
        StartCoroutine(Levecomp());
       
    } 
    public void LevelFailed()
    {
        _failed.SetActive(true);
    }

    public void PauseGame()
    {
        _pause.SetActive(true);
    }

    IEnumerator Levecomp()
    {
        yield return new WaitForSeconds(3f);
        _compelete.SetActive(true);
        //Time.timeScale = 0.01f;
        Time.timeScale = 1f;
    }
}
