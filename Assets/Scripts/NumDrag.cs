using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumDrag : MonoBehaviour
{

    public GameObject[] dragones;




    void Update()
    {
        bool allDragDead = true;

        foreach (GameObject Dragon in dragones)
        {
            if (Dragon != null)
            {
                allDragDead = false;
                break;
            }
        }
        if(allDragDead)
        {
            SceneManager.LoadScene(1);
        }
    }


}
