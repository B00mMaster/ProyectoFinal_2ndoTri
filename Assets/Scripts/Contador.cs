using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI  textoContador;

    private float tiempoRest=3000;

    private bool isCont = false;

    public GameObject contPanel;

    private void Update()
    {
        if(tiempoRest>0)
        {
            tiempoRest -= Time.deltaTime;
            MostrarTiempo();
        }
        else
        {
            textoContador.text = "GAME OVER";

            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (isCont)
                ResumeGame();
            else
                ContGame();
        }
    }

    void MostrarTiempo()
    {
        int min = Mathf.FloorToInt(tiempoRest / 60);
        int sec = Mathf.FloorToInt(tiempoRest % 60);

        textoContador.text = min.ToString("00") + ":" + sec.ToString("00");
    }

    void ResumeGame()
    {
        isCont = false;
        
        contPanel.SetActive(false);
    }
    void ContGame()
    {
        isCont = true;
        
        contPanel.SetActive(true);
    }
}
