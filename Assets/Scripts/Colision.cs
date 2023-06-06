using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public int damage;
    public int heal;
    public bool haspowerUp;
    public GameObject[] powerupIndicator;

    public ParticleSystem powerUp;



   

    private void Start()
    {
        powerUp.gameObject.SetActive(false);
    }

    private IEnumerator PowerupCountDown()
    {
        for (int i = 0; i < powerupIndicator.Length; i++)
        {
            powerupIndicator[i].SetActive(true);
            damage = 4;
            yield return new WaitForSeconds(20);
            Debug.Log("FINAL_POWERUP");
            powerupIndicator[i].SetActive(false);
            damage = 1;
            haspowerUp = false;
            powerUp.gameObject.SetActive(false);
            powerUp.Stop();
        }
        
        
        
    }

    private void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.name.Contains("Flower"))
        {//si se detecta un objeto con dicho nombre, se detectará como falso por lo que se dejará de ver

            haspowerUp = true;
            StartCoroutine(PowerupCountDown());



            Destroy(other.gameObject);
            Debug.Log("EMPIEZA_POWERUP");
            powerUp.gameObject.SetActive(true);
            powerUp.Play();

        }

        if (other.gameObject.name.Contains("Grass"))
        {
            
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.name.Contains("Player"))
        {
            other.GetComponent<LifePlayer>().PlusLife(heal);
            other.GetComponent<LifePlayer>().RestLife(damage);
            
        }

        


    }
}

