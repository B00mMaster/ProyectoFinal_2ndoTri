using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public int damage;
    public int heal;

     private void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.name.Contains("Flower"))
        {//si se detecta un objeto con dicho nombre, se detectar� como falso por lo que se dejar� de ver
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.name.Contains("Grass"))
        {
           
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.name.Contains("Player"))
        {
            other.GetComponent<LifePlayer>().RestLife(damage);
            other.GetComponent<LifePlayer>().PlusLife(heal);
        }

    

     }
}

