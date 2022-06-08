using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climate : SingletonMonobehaviour<Climate>
{
    [SerializeField] CheckAllAgent checkAllAgent;
    public float totalTemperature;
    public float HighestTemp;
    public float LowestTemp;
    public float light;
    private float firstTemperature;
    [SerializeField] private float humidity;
    [SerializeField] private float humidityfromRain;

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

        HighestTemp = firstTemperature;
        LowestTemp = firstTemperature;

        Humidity();
    }

    void Update() //temperature อิงตามความชื้อกับช่วงเวลา (กลางวันกลางคือน) ความชื้นอิงอามต้นไม้ layer Crop tag Tree
    {
        Hour = TimeManager.Instance.gameHour;

        Humidity();
        CalculateTemperature();

        if(totalTemperature > HighestTemp)
        {
            HighestTemp = totalTemperature;
        }

        if(totalTemperature < LowestTemp)
        {
            LowestTemp = totalTemperature;
        }
    }

    public void GethumidityfromRain(float x)
    {
        humidityfromRain = x;
    }

    void Humidity() // ความชื้นในอากาส
    {    
        humidity = (checkAllAgent.Tree*0.004f);                   
    }
    void CalculateTemperature() 
    {
        
        if((Hour >= 6) && (Hour <= 10))
        {
            light = 2;
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

        totalTemperature = (firstTemperature + light) - humidity - humidityfromRain;

        DebugScreenManager.Instance.GetDataTemp(totalTemperature);

    }
}

