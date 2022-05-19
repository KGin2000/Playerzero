using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimal : MonoBehaviour
{
    public int numberAnimal;
    public GameObject Animal;

    public Transform genPos;
    private Vector3 size;
    private  Vector3 Pos;

    void Start()
    {
        size = transform.localScale;
        // Debug.Log(size);
        Pos = transform.position;
        SpawnAgent();
    }

    void SpawnAgent()
    {
        for(int i = 0;i<numberAnimal;i++)
        {
             GameObject instanceAgentA = (GameObject)Instantiate(Animal);
            instanceAgentA.transform.position = transform.position;
        }

    }
}