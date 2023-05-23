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

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void RestLife(int damage)
    {
        life-=damage;

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



}
