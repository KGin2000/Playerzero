﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immigration : MonoBehaviour
{

    CheckAllAgent checkAllAgent;

    public GameObject prefabRabbit; // ใส่พรีแฟป
    public int rabbitNum;
    public GameObject prefabWildboar;
    public int boarNum;
    public GameObject prefabWolf;
    public int wolfNum;

    public GameObject rabbitImmigrationLocation;
    public GameObject boarImmigrationLocation;
    public GameObject wolfImmigrationLocation;


    [SerializeField] private float count;
    private float stableCount;

    void Start()
    {
        checkAllAgent = gameObject.GetComponent<CheckAllAgent>();
        stableCount = count;
        //Debug.Log("stableCount = "  + stableCount);

    }

    void Update()
    {
        if (checkAllAgent.Rabbit == 0)
        {
            rabbitImmi();
        }
         if (checkAllAgent.Wildboar == 0)
        {
            boartImmi();
        }
         if (checkAllAgent.Wolf == 0)
        {
            wolfImmi();
        }
    }

    void rabbitImmi()
    {
        count -= Time.deltaTime;
        if (count <= 0)
        {
            DebugScreenManager.Instance.CheckImmigration(1,0,0);
            DebugScreenManager.Instance.PrintTimeImmigration("Rabbit");

            float a = Random.Range(5,7);
            float x = checkAllAgent.Grass * (a / 100);
            rabbitNum = (int)x;

            for(int i = 0;i<rabbitNum;i++)
            {
                DebugScreenManager.Instance.GetNumAnimalImmigration("Rabbit", 1);

                GameObject instanceAgentA = (GameObject)Instantiate(prefabRabbit);
                instanceAgentA.transform.position = new Vector3(rabbitImmigrationLocation.transform.position.x, 0.0f , rabbitImmigrationLocation.transform.position.z);

                //instanceAgentA.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            }
            count = stableCount;
        }
        
    }
    void boartImmi()
    {
        count -= Time.deltaTime;
        if (count <= 0)
        {
            DebugScreenManager.Instance.CheckImmigration(0,1,0);
            DebugScreenManager.Instance.PrintTimeImmigration("Boar");

            float b = Random.Range(2,4);
            float y = (checkAllAgent.Grass + checkAllAgent.Rabbit) * (b / 100);
            boarNum = (int)y;

            
            for(int i = 0;i<boarNum;i++)
            {
                DebugScreenManager.Instance.GetNumAnimalImmigration("Boar", 1);

                GameObject instanceAgentB = (GameObject)Instantiate(prefabWildboar);
                instanceAgentB.transform.position = new Vector3(boarImmigrationLocation.transform.position.x, 0.0f , boarImmigrationLocation.transform.position.z);

                //instanceAgentA.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            }
            count = stableCount;
        }
        
    }
    void wolfImmi()
    {
        count -= Time.deltaTime;
        if (count <= 0)
        {
            DebugScreenManager.Instance.CheckImmigration(0,0,1);
            DebugScreenManager.Instance.PrintTimeImmigration("Wolf");
            
            float z = Random.Range(2,4);
            wolfNum = (int)z;

            for(int i = 0;i<wolfNum;i++)
            {
                DebugScreenManager.Instance.GetNumAnimalImmigration("Wolf", 1);

                GameObject instanceAgentC = (GameObject)Instantiate(prefabWolf);
                instanceAgentC.transform.position = new Vector3(wolfImmigrationLocation.transform.position.x, 0.0f , wolfImmigrationLocation.transform.position.z);

                //instanceAgentA.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            }
            count = stableCount;
        }        
    }
}
