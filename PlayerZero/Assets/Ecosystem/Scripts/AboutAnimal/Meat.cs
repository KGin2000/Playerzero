using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour  // meat can heal obj that collider;
{
    public int heal = 20;
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 7)
        {   
            collider.GetComponent<Enemy>().Eat(heal);
            Destroy(gameObject);
        }
    }
}
