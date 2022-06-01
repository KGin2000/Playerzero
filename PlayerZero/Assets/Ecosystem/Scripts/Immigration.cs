using System.Collections;
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

    public List<Transform> RabbitImmigrationPosition = new List<Transform>(); // ลิส ตำแหน่งที่กระต่ายจะเกิดเมื่อย้ายถิ่น
    public List<Transform> WildboarImmigrationPosition = new List<Transform>();
    public List<Transform> WolfImmigrationPosition = new List<Transform>();

    public GameObject rabbitImmigrationLocation;
    public GameObject boarImmigrationLocation;
    public GameObject wolfImmigrationLocation;


    [SerializeField] private float count;
    private float stableCount;

    void Start()
    {
        checkAllAgent = gameObject.GetComponent<CheckAllAgent>();
        stableCount = count;
        Debug.Log("stableCount = "  + stableCount);

    }

    void Update()
    {
        if (checkAllAgent.Rabbit == 0)
        {
            rabbitImmi();
            //checkRabbit();
        }
         if (checkAllAgent.Wildboar == 0)
        {
            boartImmi();
            //checkWildboar();
        }
         if (checkAllAgent.Wolf == 0)
        {
            wolfImmi();
            //checkWolf();
        }


        // checkRabbit();
        // checkWildboar();
        // checkWolf();
    }

    void checkRabbit()
    {
        count -= Time.deltaTime;
        if (count <= 0)
        {
            count = 10.0f;
            for (int i = 0; i < rabbitNum; i++)
            {
                Debug.Log("checkRabbit checkRabbit");
                GameObject R = (GameObject)Instantiate(prefabRabbit);
                R.transform.position = RabbitImmigrationPosition[Random.Range(0, RabbitImmigrationPosition.Count)].position;
            }
        }
        
    }
    void checkWildboar()
    {        
        count -= Time.deltaTime;
        if (count <= 0)
        {
            count = 10.0f;
            for (int i = 0; i < boarNum; i++)
            {
                Debug.Log("checkWildboar checkWildboar");
                GameObject WB = (GameObject)Instantiate(prefabWildboar);
                WB.transform.position = WildboarImmigrationPosition[Random.Range(0, WildboarImmigrationPosition.Count)].position;
            }
        }
    }
    void checkWolf()
    {
        count -= Time.deltaTime;
        if (count <= 0)
        {
            count = 10.0f;
            for (int i = 0; i < wolfNum; i++)
            {
                Debug.Log("checkWolf checkWolf");
                GameObject W = (GameObject)Instantiate(prefabWolf);
                W.transform.position = WolfImmigrationPosition[Random.Range(0, WolfImmigrationPosition.Count)].position;
            }
        }             
    }

    void rabbitImmi()
    {
        count -= Time.deltaTime;
        if (count <= 0)
        {
            for(int i = 0;i<rabbitNum;i++)
            {
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
            for(int i = 0;i<boarNum;i++)
            {
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
            for(int i = 0;i<wolfNum;i++)
            {
                GameObject instanceAgentC = (GameObject)Instantiate(prefabWolf);
                instanceAgentC.transform.position = new Vector3(wolfImmigrationLocation.transform.position.x, 0.0f , wolfImmigrationLocation.transform.position.z);

                //instanceAgentA.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            }
            count = stableCount;
        }        
    }
}
