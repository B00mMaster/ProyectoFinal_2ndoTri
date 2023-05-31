using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScript : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void ResumeGame()
    {
        isPaused = false;
        
        pausePanel.SetActive(false);
    }
    void PauseGame()
    {
        isPaused = true;
        
        pausePanel.SetActive(true);
    }
}
