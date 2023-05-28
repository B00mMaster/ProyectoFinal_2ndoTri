using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int rutina;
    public float crono;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    private void Start()
    {
        ani= GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void EnemigoPatruya()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 20)
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
                    break;
            }
        }
        else
        {
            
            if (Vector3.Distance(transform.position, target.transform.position)>4 && !atacando)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                ani.SetBool("walk", false);
               
                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 4 * Time.deltaTime);

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
    
    void Update()
    {
        EnemigoPatruya();
    }
}
