using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusic : MonoBehaviour
{
    [SerializeField] Slider sliderSound;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volumes", 1);
            Play();
        }
        else
        {
            Play();
        }
    }

    public void MoveSLider()
    {
        AudioListener.volume = sliderSound.value;
        Save();
    }
    private void Play()
    {
        sliderSound.value = PlayerPrefs.GetFloat("volume", 1);
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("volume", sliderSound.value);
    }
}
