using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play Damage Animation

        //Checks if enemy shall die
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Die animation
        Debug.Log("Enemy died");
        //Disable the enemy
        Destroy(gameObject);
    }
}
