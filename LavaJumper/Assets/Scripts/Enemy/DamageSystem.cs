using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public LayerMask PlayerLayers;
    public Transform AttackPoint;

    public float AttackRadius;
    public int damageAmount;
    

    void Attack()
    {
        //Play Attack Animation
        

        //Detect enemies in range of attack
        //Creates an array for the attack point
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRadius, PlayerLayers);
        //Damage Enemies inside of radius
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerHealth>().PlayerTakeDamage(damageAmount);
        }
    }


    private void OnDrawGizmosSelected()
    {
        //if (AttackPoint == null)
        //{
        //    return;
        //}
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Attack();
        Debug.Log("Player takes damage");
    }
}
