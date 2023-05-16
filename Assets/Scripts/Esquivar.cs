using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esquivar : MonoBehaviour
{
    private bool shift;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && shift) 
        {
            GetComponent<Animator>().SetTrigger("Esquive");
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
