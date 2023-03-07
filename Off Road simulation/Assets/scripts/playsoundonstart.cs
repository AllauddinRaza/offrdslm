using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsoundonstart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    void Start()
    {
        
        Soundmanager.Instance.playSound(_clip);
    }

    
}
