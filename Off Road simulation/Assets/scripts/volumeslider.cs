using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeslider : MonoBehaviour
{
    [SerializeField] private Slider _slider;  
    [SerializeField] private Slider _slidersound;
    void Start()
    {
        _slider.onValueChanged.AddListener(val => Soundmanager.Instance.ChangeMastervloume(val)); 
       
    }

    
}
