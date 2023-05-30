using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{


    public LifePlayer life;


    private void Start()
    {
        life= FindObjectOfType<LifePlayer>();
    }

    public void Reiniciar(string name2)
    {
        SceneManager.LoadScene(name2);
    }


    public void Menu(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Start (string name4)
    {
        SceneManager.LoadScene(name4);
    }
    

}
