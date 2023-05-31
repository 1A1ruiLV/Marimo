using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Mu_Vol_Changer : MonoBehaviour
{
    private AudioSource mu_Source;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
        mu_Source = GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    public void Play()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void Stop()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }
    public void M_SoundChanger(float newSliderValue) 
    {
        mu_Source.volume = newSliderValue;
    }

}
