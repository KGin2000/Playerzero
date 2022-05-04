using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtesttest : MonoBehaviour
{
    float lastXVal;
    

    void Start()
    {

        lastXVal = transform.position.x;
  
    }


    void Update() // 
    {
        if (transform.hasChanged)
        {
            if (transform.position.x < lastXVal)
            {
                Debug.Log("Decreased!");
                //Update lastXVal
                lastXVal = transform.position.x;
            }

            else if (transform.position.x > lastXVal)
            {
                Debug.Log("Increased");

                //Update lastXVal
                lastXVal = transform.position.x;
            }

            transform.hasChanged = false;
        }


    }

    

   

   


    void OnDrawGizmosSelected()
    {


        Gizmos.DrawWireSphere(transform.position, 20);
    }

    
}
