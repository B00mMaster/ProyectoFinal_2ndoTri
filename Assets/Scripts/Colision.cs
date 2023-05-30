using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public int damage;
    public int heal;
    public bool haspowerUp;
    public GameObject[] powerupIndicator;

    public ParticleSystem ParFlower;

    



    private void Start()
    {
    }

    private IEnumerator PowerupCountDown()
    {
        for (int i = 0; i < powerupIndicator.Length; i++)
        {
            powerupIndicator[i].SetActive(true);
            damage = 10;
            yield return new WaitForSeconds(20);
            Debug.Log("FINAL_POWERUP");
            powerupIndicator[i].SetActive(false);
            damage = 1;
            haspowerUp = false;
        }
        
        
        
    }

    private void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.name.Contains("Flower"))
        {//si se detecta un objeto con dicho nombre, se detectará como falso por lo que se dejará de ver

            haspowerUp = true;
            StartCoroutine(PowerupCountDown());

            ParFlower.Play();

            other.gameObject.SetActive(false);
            Debug.Log("EMPIEZA_POWERUP");



        }
        if (other.gameObject.name.Contains("Grass"))
        {
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.name.Contains("Player"))
        {
            
           other.GetComponent<LifePlayer>().RestLife(damage);
            
        }

        if (other.gameObject.name.Contains("Dragon"))
        {

            other.GetComponent<Enemigo>().RestLife(damage);
            other.GetComponent<Enemigo>().PlusLife(heal);
        }



    }
}

