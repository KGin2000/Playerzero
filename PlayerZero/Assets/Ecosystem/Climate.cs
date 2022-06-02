using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climate : MonoBehaviour
{
    [SerializeField] CheckAllAgent checkAllAgent;
    public float totalTemperature;
    public float light;
    //private float lastTemperature; //ร้อนจัด
    private float firstTemperature;
    // private float SecondTemperature;
    [SerializeField] private float humidity;

    private int newRate;
    private int lastRate;
  
    private int Day;
    private int Hour;
    private int Minute;
   
    public float treeRatio;
    private float oldA;

    void Start()
    {
        firstTemperature = 25;
        oldA = 0;
        newRate = 0;
        lastRate = newRate;

        Humidity();
    }

    void Update() //temperature อิงตามความชื้อกับช่วงเวลา (กลางวันกลางคือน) ความชื้นอิงอามต้นไม้ layer Crop tag Tree
    {
        Hour = TimeManager.Instance.gameHour;

        Humidity();
        CalculateTemperature();
        
    }

    void Humidity() // ความชื้นในอากาส
    {    
        humidity = (checkAllAgent.Tree / 235);                   
    }
    void CalculateTemperature() 
    {
        //float X = Random.Range(21, 30);
        //firstTemperature = X;
        if((Hour >= 6) && (Hour <= 10))
        {
            // float A = Mathf.Abs(Hour - 12);
            // light = 5 - (A/2f);
            light = 2;
            //Debug.Log(light);
        }
        else if((Hour >= 11) && (Hour <= 16))
        {
            light = 5;
        }
        else if((Hour >= 17) && (Hour <= 18))
        {
            light = 3;
        }
        else light = 0;

        totalTemperature = (firstTemperature + light) - humidity;

        DebugScreenManager.Instance.GetDataTemp(totalTemperature);

    }
}

