using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    public Slider BGMSlider;
    public Slider SE_slider;

    public float initSound = 5.0f;

    public void Start()
    {
        BGMSlider = GameObject.Find("BGMSlider").GetComponent<Slider>();
        SE_slider = GameObject.Find("SE_slider").GetComponent<Slider>();

    }
    public void OnClickInit() 
    {
        BGMSlider.value = initSound;
        SE_slider.value = initSound;
    }
}
