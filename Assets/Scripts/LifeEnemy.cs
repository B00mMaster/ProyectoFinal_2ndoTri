using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
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
}
