using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public Slider slider2;

    void Start()
    {
        slider.value = PlayerPrefs.GetInt("mV");
        slider2.value = PlayerPrefs.GetInt("sfxV");
    }
    
}
