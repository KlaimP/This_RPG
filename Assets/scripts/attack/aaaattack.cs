using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaaattack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPose;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int damage;

    private void Update()
    {
        if (timeBtwAttack <= 0 )
                {
                if(Input.GetKey(KeyCode.Space))
                    {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPose.position, attackRange, whatIsEnemy);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    }
                    }

                    timeBtwAttack = startTimeBtwAttack;
                }
                else
                {
                timeBtwAttack -= Time.deltaTime;
                }
    }
        void OnDrawGizmosSelected()
         {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(attackPose.position, attackRange);
         }

    
}