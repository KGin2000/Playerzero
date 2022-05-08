using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawn : MonoBehaviour
{
    public int NumbersRabbit;
    public GameObject Rabbit;

    void Start()
    {
        Vector3 size = transform.localScale;
        Vector3 Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 size = transform.localScale;
        Vector3 Pos = transform.position;
        for (int i = 0; i < NumbersRabbit; i++)
        {
            GameObject instanceAgentA = (GameObject)Instantiate(Rabbit);
            instanceAgentA.transform.position = new Vector3
                (Random.Range(-size.x * 10f, size.x * 10f),
                size.y,
                Random.Range(-size.z * 10f, size.z * 10f));

        }
    }
}
