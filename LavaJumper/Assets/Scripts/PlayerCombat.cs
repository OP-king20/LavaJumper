using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   
    public LayerMask enemyLayers;
    public Transform AttackPoint;

    public float AttackRadius;
    public int damageAmount;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }


    void Attack()
    {
        //Play Attack Animation
        //Detect enemies in range of attack
        //Creates an array for the attack point
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRadius, enemyLayers);
        //Damage Enemies inside of radius
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damageAmount);
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
}
