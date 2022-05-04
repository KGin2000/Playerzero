using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPlants : MonoBehaviour
{

    public int numberAgent_;
    public GameObject prefabAgent_;
    public Transform Plane_;
    public int timeToSpawn;

    private float time;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        time += Time.deltaTime;
        int y = Mathf.RoundToInt(time);
        if ( y % timeToSpawn == 0)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector3 size = Plane_.transform.localScale;
        Vector3 Pos = Plane_.transform.position;       

        for (int i = 0; i < numberAgent_; i++)
        {
            GameObject instanceAgent_ = (GameObject)Instantiate(prefabAgent_);
            instanceAgent_.transform.position = new Vector3(Random.Range((Pos.x + (-size.x * 5f)), (Pos.x + (size.x * 5f))), instanceAgent_.transform.position.y, Random.Range((Pos.z + (-size.z * 5f)), (Pos.z + (size.z * 5f))));

        }

        time = 1;
    }
    
}