using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using BehaviorDesigner.Runtime;

public class Cave : MonoBehaviour
{
    public string Name;

    //public string Status;
    //private SharedString textStatus;

    public string orginTag;

    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {       
        if (collider.name.Contains(Name))
        {
            //GameObject a = collider.gameObject.GetComponent<GameObject>();
            //behaviorTree = collider.GetComponent<BehaviorTree>();
            //textStatus = (SharedString)behaviorTree.GetVariable("returnStatus");
           // Debug.Log(textStatus);

            //if ((SharedString)behaviorTree.GetVariable("returnStatus").Contains(Status)) //มีปัญห
            //{ 
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
            other.gameObject.tag = orginTag;
            other.gameObject.layer = 7;

            // สลับ layer ให้เท่าเดิม
            //Renderer otherRenderer = other.GetComponent<Renderer>();
            //otherRenderer.enabled = true;            
        }
    }


}
