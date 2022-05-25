using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using BehaviorDesigner.Runtime;

public class Cave : MonoBehaviour
{
    public string Name;

    Collider rabbitCollider;
    Collider rabbitOtherCollider;
    BehaviorTree behaviorTree;
    public float colliderRange;
    public LayerMask enemyLayers;

    Renderer rend;
    //public string Status;
    //private SharedString textStatus;

    public string orginTag;


    void OnTriggerEnter(Collider collider)
    {   
        if (collider.name.Contains(Name))
        {
            //GameObject a = collider.gameObject.GetComponent<GameObject>();
            behaviorTree = collider.GetComponent<BehaviorTree>();
            SharedString textStatus = (SharedString)behaviorTree.GetVariable("returnStatus");

            if(textStatus.Value == null)
            {
                Debug.Log("textStatus = "   + textStatus.Value);
            }
           // Debug.Log(textStatus);

            //if ((SharedString)behaviorTree.GetVariable("returnStatus").Contains(Status)) //มีปัญห
            //{ 
                // rabbitCollider = collider.GetComponent<Collider>();
                // rabbitCollider.enabled = false;

                GameObject a = collider.gameObject.transform.GetChild(0).gameObject;
                rend = a.GetComponent<Renderer>();
                //rend = collider.GetComponent<Renderer>();
                rend.enabled = false;

                collider.gameObject.tag = "ImmortalObject";
                collider.gameObject.layer = 31;
            //}
            //else return;

            // สลับ layer ให้น้อยลง
            //Renderer colliRenderer = collider.GetComponent<Renderer>();
            //colliRenderer.enabled = false;            
        }


    }
    void OnTriggerExit(Collider other)
    {
        if (other.name.Contains(Name))
        {
            // rabbitOtherCollider = other.GetComponent<Collider>();
            // rabbitOtherCollider.enabled = true;

            GameObject b = other.gameObject.transform.GetChild(0).gameObject;
            rend = b.GetComponent<Renderer>();
            rend.enabled = true;

            other.gameObject.tag = orginTag;
            other.gameObject.layer = 7;

            // สลับ layer ให้เท่าเดิม
            //Renderer otherRenderer = other.GetComponent<Renderer>();
            //otherRenderer.enabled = true;            
        }
    }


}
