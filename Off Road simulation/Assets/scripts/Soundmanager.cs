using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public static Soundmanager Instance;
    [SerializeField] private AudioSource  _effectssource;
    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void playSound(AudioClip clip)
    {
        _effectssource.PlayOneShot(clip);
    }
    public void ChangeMastervloume(float value)
    {
        AudioListener.volume = value;
    } 
}
