using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    public int life =10;
   
    public Image barraVida;

    public void RestLife(int damage)
    {
        life-=damage;

    }
    public void PlusLife(int heal)
    {
        if (life <= 9)
        { 
            life += heal;
        } 
    }
    private void Update()
    {
        barraVida.fillAmount =life;
    }






}
