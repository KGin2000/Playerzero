using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBake : MonoBehaviour
{

    public NavMeshSurface[] surfaces;
    public string navObjName;
    public string navObjTag;
    private int numberNavObj;

    // Use this for initialization
    void Awake()
    {
        Bake();
    }
    void Start()
    {
        numberNavObj = GameObject.FindGameObjectsWithTag(navObjTag).Length;
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag(navObjTag).Length != numberNavObj)
        {
            numberNavObj = GameObject.FindGameObjectsWithTag(navObjTag).Length;
            Bake();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Contains(navObjName))
        {
            Debug.Log("hit " + navObjName);
            Bake();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains(navObjName))
        {
            Debug.Log("hit " + navObjName);
            Bake();
        }
    }

    void Bake()
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }
}