using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        volumeSlider.value = audioSource.volume;
    }

    public void Volume(float volume)
    {
        audioSource.volume = volume;
    }
}
