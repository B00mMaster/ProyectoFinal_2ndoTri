using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenGame : MonoBehaviour
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
