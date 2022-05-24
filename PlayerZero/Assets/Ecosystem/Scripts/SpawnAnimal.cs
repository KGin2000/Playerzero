using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimal : MonoBehaviour
{
    public int numberAnimal;
    public GameObject Animal;

    protected UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Start()
    {
        SpawnAgent();
    //    for (int i = 0; i < numberAnimal; i++)
    //     {
    //         GameObject instanceAgentA = (GameObject)Instantiate(Animal);
    //         instanceAgentA.transform.position = transform.position;
    //         instanceAgentA.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
    //     }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnAgent();
        }
    }
    void SpawnAgent()
    {
        for(int i = 0;i<numberAnimal;i++)
        {
             GameObject instanceAgentA = (GameObject)Instantiate(Animal);
            instanceAgentA.transform.position = transform.position;
            instanceAgentA.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        }
    }
}