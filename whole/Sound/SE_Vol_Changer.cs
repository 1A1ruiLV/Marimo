using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SE_Vol_Changer : MonoBehaviour
{
    private AudioSource se_Source;
    // Start is called before the first frame update
    void Start()
    {
        se_Source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    public void SE_SoundChanger(float newSliderValue) 
    {
        se_Source.volume = newSliderValue;
    }
}
