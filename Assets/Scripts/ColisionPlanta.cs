using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionPlanta : MonoBehaviour
{
    public int heal;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            other.GetComponent<LifePlayer>().PlusLife(heal);
            

        }
    }
}
