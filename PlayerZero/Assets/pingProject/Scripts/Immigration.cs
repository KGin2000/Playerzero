using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immigration : MonoBehaviour
{

    CheckAllAgent checkAllAgent;

    public GameObject prefabRabbit; // ใส่พรีแฟป
    public GameObject prefabWildboar;
    public GameObject prefabWolf;

    public List<Transform> RabbitImmigrationPosition = new List<Transform>(); // ลิส ตำแหน่งที่กระต่ายจะเกิดเมื่อย้ายถิ่น
    public List<Transform> WildboarImmigrationPosition = new List<Transform>();
    public List<Transform> WolfImmigrationPosition = new List<Transform>();

    private int r;
    private int wb;
    private int w;

    [SerializeField] private float count = 10.0f;

    void Start()
    {
        checkAllAgent = gameObject.GetComponent<CheckAllAgent>();
    }


    void Update()
    {
        //checkAllAgent = gameObject.GetComponent<CheckAllAgent>();
        checkRabbit();
        checkWildboar();
        checkWolf();
    }

    void checkRabbit()
    {
        if (checkAllAgent.Rabbit == 0)
        {
            count -= Time.deltaTime;
            int m = checkAllAgent.Grass;
            int n = (20 * m) / 100;

            if (count <= 0)
            {
                count = 10.0f;
                for (int i = 0; i < n; i++)
                {
                    Debug.Log("checkRabbit checkRabbit");
                    GameObject R = (GameObject)Instantiate(prefabRabbit);
                    R.transform.position = RabbitImmigrationPosition[Random.Range(0, RabbitImmigrationPosition.Count)].position;
                }
            }           
        }
    }
    void checkWildboar()
    {
        if (checkAllAgent.Wildboar == 0)
        {
            count -= Time.deltaTime;
            int m = checkAllAgent.Grass + checkAllAgent.Rabbit;
            int n = (20 *m) / 100;

            if (count <= 0)
            {
                count = 10.0f;
                for (int i = 0; i < n; i++)
                {
                    Debug.Log("checkWildboar checkWildboar");
                    GameObject WB = (GameObject)Instantiate(prefabWildboar);
                    WB.transform.position = WildboarImmigrationPosition[Random.Range(0, WildboarImmigrationPosition.Count)].position;
                }
            }               
        }
    }
    void checkWolf()
    {
        if (checkAllAgent.Wolf == 0)
        {
            //float count = 10.0f;
            count -= Time.deltaTime;
            int m = checkAllAgent.Rabbit + checkAllAgent.Wildboar;
            int n = (20 * m) / 100;

            if (count <= 0)
            {
                count = 10.0f;
                for (int i = 0; i < n; i++)
                {
                    Debug.Log("checkWolf checkWolf");
                    GameObject W = (GameObject)Instantiate(prefabWolf);
                    W.transform.position = WolfImmigrationPosition[Random.Range(0, WolfImmigrationPosition.Count)].position;
                }
            }
        }                      
    }
}
