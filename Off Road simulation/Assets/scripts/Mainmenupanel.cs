using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class Mainmenupanel : MonoBehaviour
{
    public Text Coins;
    private void Start()
    {
        Coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
