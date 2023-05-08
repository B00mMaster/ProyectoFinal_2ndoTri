using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    private Volume volume;
    private Vignette vignette;

    private void Awake()
    {
        volume = GetComponent<Volume>();
    }

    private void Start()
    {


        volume.profile.TryGet(out vignette); //encuentra y devuelve viñeta
        vignette.intensity.value = 0.5f;
        vignette.color.value = Color.red;
    }

    private IEnumerator Deactive()
    {
        yield return new WaitForSeconds(3);
        vignette.intensity.value = 1f;
        vignette.color.value = Color.red;

    }
}
