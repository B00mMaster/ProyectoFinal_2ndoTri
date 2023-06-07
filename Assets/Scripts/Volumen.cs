using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public AudioSource audioSource;
        public Slider volumen;

    private void Start()
    {
        volumen.onValueChanged.AddListener(Volume);
    }

    public void Volume(float volume)
    {
        audioSource.volume = volume;
    }
}
