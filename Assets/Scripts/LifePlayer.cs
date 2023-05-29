using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    public int life =10;
    private int maxLife = 10;
    private Animator animator;
    public Image barraVida;

    public AudioSource audioSource2;


    private void Start()
    {
        animator = GetComponent<Animator>();

        audioSource2 = GetComponent<AudioSource>();
    }
    public void RestLife(int damage)
    {
        life-=damage;

        audioSource2.Play();

    }
    public void PlusLife(int heal)
    {
        life += heal;
        if (life >= maxLife)
        {
            life = maxLife;
        } 
    }
    private void Update()
    {
        barraVida.fillAmount =(float)life/maxLife;

        if(life==0)
        {
            animator.Play("");
        }
    }

    
    public void ResetAttack()
    {
        animator.SetBool(PlayerControl.attackHash, false);
    }

    public void ResetRoll()
    {
        animator.SetBool(PlayerControl.rollkHash, false);
    }



}
