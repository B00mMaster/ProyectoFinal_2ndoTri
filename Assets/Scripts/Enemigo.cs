using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    public int rutina;
    public float crono;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public int damage;

    public GameObject target;
    public bool atacando;

    public AudioSource audioSource;


    private void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
    }

    public void EnemigoPatruya()
    {
       
        if (Vector3.Distance(transform.position, target.transform.position) > 30)
        {
            ani.SetBool("run", false);
            crono += 1 * Time.deltaTime;
            if (crono >= 4)
            {
                rutina = Random.Range(0, 2);
                crono = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    audioSource.Play();
                    break;
            }
        }
        else
        {

            if (Vector3.Distance(transform.position, target.transform.position) > 4 && !atacando)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                ani.SetBool("walk", false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 5 * Time.deltaTime);

                ani.SetBool("attack", false);
            }
            else
            {
                if (Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)
                {
                    var lookPos = target.transform.position - transform.position;
                    lookPos.y = 0;
                    var rotation = Quaternion.LookRotation(lookPos);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                    ani.SetBool("walk", false);

                    ani.SetBool("run", false);
                    transform.Translate(Vector3.forward * 4 * Time.deltaTime);

                    ani.SetBool("attack", true);



                }


            }

        }


    }

    private void isDead()
    {
        if (life <= 0)//if is death
        {
        }
        else //if is alive
        {
            EnemigoPatruya();
        }
    }

    public int life = 10;
    private int maxLife = 10;



    public void RestLife(int damage)
    {
        life -= damage;

    }
    public void PlusLife(int heal)
    {
        life += heal;
        if (life >= maxLife)
        {
            life = maxLife;
        }
    }
    void Update()
    {
        isDead();

        if (life <= 0)
        {
            ani.SetBool("die", true);
            ani.SetBool("attack", false);
            ani.SetBool("walk", false);
            ani.SetBool("run", false);


        }


    }
    public void Destroy()
    {
        Destroy(gameObject);



    }

    
}

