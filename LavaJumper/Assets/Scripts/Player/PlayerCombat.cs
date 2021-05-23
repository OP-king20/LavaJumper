using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   
    public LayerMask enemyLayers;
    public Transform AttackPoint;

    public float AttackRadius;
    public int damageAmount;

    private Animator anim;

    // Update is called once per frame
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Attack");

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
