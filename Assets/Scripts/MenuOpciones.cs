using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{

    public GameObject optionsPanel;

    [SerializeField] private AudioMixer audioMixer;
    
    
    public void Volume(float volume)
    {
        audioMixer.SetFloat("Volume",volume);
    }


    private bool activeOpt = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (activeOpt)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void ResumeGame()
    {
        activeOpt = false;
        
        optionsPanel.SetActive(false);
    }
    void PauseGame()
    {
        activeOpt = true;
        
       optionsPanel.SetActive(true);
    }
}
