using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCombat : MonoBehaviour
{

    // public Animator animator;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] public int attack;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
       // animator.SetTrigger("Attack");        
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider a in hitEnemies)
        {
            a.GetComponent<Enemy>().TakeDamage(attack);
            //Debug.Log("we hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
