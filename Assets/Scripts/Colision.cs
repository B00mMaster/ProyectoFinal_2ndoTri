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
        {//si se detecta un objeto con dicho nombre, se detectará como falso por lo que se dejará de ver
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

