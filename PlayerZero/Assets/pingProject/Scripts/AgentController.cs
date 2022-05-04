using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public int number_ag1;
    public int number_ag2;
    public int number_ag3;


    public GameObject prefab_ag1;
    public GameObject prefab_ag2;
    public GameObject prefab_ag3;

    // Use this for initialization
    void Start()
    {
        Vector3 size = transform.localScale;
        // Debug.Log(size);
        Vector3 Pos = transform.position;

        for (int i = 0; i < number_ag1; i++)
        {
            GameObject A = (GameObject)Instantiate(prefab_ag1);
            A.transform.position = new Vector3
                (Random.Range(-size.x * 10f, size.x * 10f),
                size.y,
                Random.Range(-size.z * 10f, size.z * 10f));

        }

        for (int i = 0; i < number_ag2; i++)
        {
            GameObject B = (GameObject)Instantiate(prefab_ag2);
            B.transform.position = new Vector3(Random.Range(-size.x * 10f, size.x * 10f), size.y, Random.Range(-size.z * 10f, size.z * 10f));
        }

        for (int i = 0; i < number_ag3; i++)
        {
            GameObject C = (GameObject)Instantiate(prefab_ag3);
            C.transform.position = new Vector3(Random.Range(-size.x * 10f, size.x * 10f), size.y, Random.Range(-size.z * 10f, size.z * 10f));
        }

        // Update is called once per frame
    }
}