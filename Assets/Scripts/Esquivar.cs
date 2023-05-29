using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esquivar : MonoBehaviour
{
    Animator ani;
    private bool shift;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && shift) 
        {
            ani.SetBool("Roll", true);
            shift = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StartCoroutine(Shift());
            shift = true;
        }
    }

    IEnumerator Shift()
    {
        yield return new WaitForSeconds(1);

        shift = false;
    }

}
