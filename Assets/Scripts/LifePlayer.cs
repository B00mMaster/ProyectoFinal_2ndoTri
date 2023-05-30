using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    public int life = 10;
    private int maxLife = 10;
    private Animator animator;
    public Image barraVida;

    public AudioSource hurtSource;


    private void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void RestLife(int damage)
    {
        life -= damage;

        hurtSource.Play();

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
        barraVida.fillAmount = (float)life / maxLife;

        IsGameOver("GAME OVER");

    }


    public void ResetAttack()
    {
        animator.SetBool(PlayerControl.attackHash, false);
    }


    public void IsGameOver(string name3)
    {
        if (life <= 0)
        {
            SceneManager.LoadScene(3);
        }



    }
}
