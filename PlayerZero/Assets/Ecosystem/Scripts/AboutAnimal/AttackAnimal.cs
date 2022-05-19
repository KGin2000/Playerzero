using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class AttackAnimal : MonoBehaviour
{

    // public Animator animator;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] public int attack;
    //[SerializeField] private string targetTag;



    void Start()
    {
        //Attack();
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        // animator.SetTrigger("Attack");        
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            if (gameObject.tag == "ImmortalObject")
            {
                return;
            }
            else
            {
                string a = gameObject.tag; // this obj tag
                int x = Convert.ToInt32(a);

                string b = enemy.tag;
                int y = Convert.ToInt32(b);

                if (x > y)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(attack);
                    //enemy.gameObject.GetComponent<Enemy>().CounterAttack(gameObject);
                }
            }                      
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
