using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPlants : MonoBehaviour
{
    Climate climate;

    public int numberAgent_;
    public GameObject prefabAgent_;
    public Transform Plane_;

    public LayerMask Layer;

    public int numOfGrassInMap; // check only
    public int maxGrassInPlane; // จำนวนหญ้าในแต่ละเพลน x จำนวนเพลน;

    public float tempToDay;
    public Collider[] hitColliders;

    public float coolDown;
    private float B;

    private float time;
    private float Hour;
    private int A;


    void Start()
    {
        B = coolDown;
        A = numberAgent_;
        GameObject a = GameObject.FindGameObjectWithTag("InfomationManager");
        climate = a.GetComponent<Climate>();
        //Spawn();

        Vector3 size = Plane_.transform.localScale;
        Vector3 Pos = Plane_.transform.position;
        for (int i = 1; i <= 180; i++)
        {
            GameObject instanceAgent_ = (GameObject)Instantiate(prefabAgent_);
            instanceAgent_.transform.position = new Vector3(Random.Range((Pos.x + (-size.x * 5f)), (Pos.x + (size.x * 5f))), instanceAgent_.transform.position.y, Random.Range((Pos.z + (-size.z * 5f)), (Pos.z + (size.z * 5f))));
        }
    }

    void Update()
    {
        Vector3 thisPosition = gameObject.transform.position;
        var scale = gameObject.transform.localScale;
        Hour = TimeManager.Instance.gameHour;

        hitColliders = Physics.OverlapBox(thisPosition, gameObject.transform.localScale*5, Quaternion.identity, Layer);

        if( TimeManager.Instance.gameHour == 12 && TimeManager.Instance.gameMinute == 0)
        {
            tempToDay = climate.totalTemperature;
            //Debug.Log("tempToDay = " + tempToDay);
            if(tempToDay > 28)
            {
                float x = tempToDay - 28;
                float y = A*x*0.1f;
                numberAgent_ = A - (int)y;
                //Debug.Log("numberAgent_ = " + numberAgent_);
            }
            else if(tempToDay <= 28)
            {
                numberAgent_ = A;
            }

            if(hitColliders.Length < maxGrassInPlane)
            {
                Spawn();
            }
        }

        // coolDown -= Time.deltaTime;
        // if(coolDown <0 )
        // {
        //     if(hitColliders.Length < numberAgent_)
        //     {
        //         Spawn();
        //         // coolDown = B;
        //     }
        //     coolDown = B;
        // }     
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
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gameObject.transform.position, gameObject.transform.localScale*5);
    }  
}