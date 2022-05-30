using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPlants : MonoBehaviour
{
    Climate climate;

    public int numberAgent_;
    public GameObject prefabAgent_;
    public Transform Plane_;

    private float time;

    public int numOfGrassInMap; // check only
    public int maxGrassInMap; // จำนวนหญ้าในแต่ละเพลน x จำนวนเพลน;

    public float tempToDay;
    private float Hour;
    private int A;

    void Start()
    {
        A = numberAgent_;
        GameObject a = GameObject.FindGameObjectWithTag("InfomationManager");
        climate = a.GetComponent<Climate>();
        Spawn();
    }

    void Update()
    {
        Hour = TimeManager.Instance.gameHour;
        numOfGrassInMap = GameObject.FindGameObjectsWithTag("0").Length;
        
        if( Hour == 12)
        {
            tempToDay = climate.totalTemperature;
            Debug.Log("tempToDay = " + tempToDay);
            if(tempToDay > 28)
            {
                float x = tempToDay - 28;
                float y = A*x*0.1f;
                numberAgent_ = A - (int)y;
                Debug.Log("numberAgent_ = " + numberAgent_);
            }
            else if(tempToDay <= 28)
            {
                 numberAgent_ = A;
            }
            if(numOfGrassInMap <= maxGrassInMap)
            {
                Spawn();
            }
        }       
    }    

    public void Spawn()
    {
        Vector3 size = Plane_.transform.localScale;
        Vector3 Pos = Plane_.transform.position;       

        for (int i = 1; i < numberAgent_; i++)
        {
            GameObject instanceAgent_ = (GameObject)Instantiate(prefabAgent_);
            instanceAgent_.transform.position = new Vector3(Random.Range((Pos.x + (-size.x * 5f)), (Pos.x + (size.x * 5f))), instanceAgent_.transform.position.y, Random.Range((Pos.z + (-size.z * 5f)), (Pos.z + (size.z * 5f))));
        }
    }   
}