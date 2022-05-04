using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGrass : MonoBehaviour  // meat can heal obj that collider;
{
    [SerializeField] public int heal = 20;
    [SerializeField] Transform eatenPoint;
    [SerializeField] float colliderRange = 0.5f;
    [SerializeField] LayerMask enemyLayers;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject)
        {
            IsEaten();
            Destroy(gameObject);
        }
    }

    void IsEaten()
    {
        Collider[] hitObj = Physics.OverlapSphere(eatenPoint.position, colliderRange, enemyLayers);

        foreach (Collider enemy in hitObj)
        {
            enemy.GetComponent<Enemy>().Eat(heal);
            Debug.Log("we heal " + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (eatenPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(eatenPoint.position, colliderRange);
    }
}
