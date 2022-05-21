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
        //rainRate = new string[10];
        firstTemperature = 25;
        oldA = 0;
        newRate = 0;
        lastRate = newRate;

        Humidity();
        // TemperaturePerMonth();
        // TemperaturePerDay();
        // TemperaturePerHour();
    }

    void Update() //temperature อิงตามความชื้อกับช่วงเวลา (กลางวันกลางคือน) ความชื้นอิงอามต้นไม้ layer Crop tag Tree
    {
        //Day = TimeManager.Instance.gameDay;
        Hour = TimeManager.Instance.gameHour;
        //Minute = TimeManager.Instance.gameMinute;

        //Rain();
        Humidity();
        CalculateTemperature();
        


        // if (Minute == 59) //
        // {
        //     TemperaturePerHour();
        // }

        // if (Hour == 23) // 
        // {
        //     TemperaturePerDay();
        // }
        // if (Day == 30) //
        // {
        //     TemperaturePerMonth();
        // }

        // if (lastTemperature > 30f)
        // {
        //     Debug.Log("weather so hot");
        //     if (humidity < 4)
        //     {              
        //         // function rainning;
        //     }
        // }


    }

    void Humidity() // ความชื้นในอากาส
    {    
        if (checkAllAgent.maxTree != 0)
        {
            treeRatio = (checkAllAgent.Tree / checkAllAgent.maxTree);
            humidity = treeRatio * 2f; 
        }
        // else if (checkAllAgent.maxTree == 0)
        // {
        //     treeRatio = 1;
        //     humidity = treeRatio * 2f;
        // }
            
        
    }
    void CalculateTemperature() 
    {
        //float X = Random.Range(21, 30);
        //firstTemperature = X;
        if((Hour >= 6) && (Hour <= 18))
        {
            float A = Mathf.Abs(Hour - 12);
            light = 5 - (A/2f);
            //Debug.Log(light);
        }
        else light = 0;

        totalTemperature = (firstTemperature + light) - humidity;

    }

    // void TemperaturePerDay()
    // {
    //     SecondTemperature = firstTemperature - oldA; //29
    //     float A = Random.Range(0, humidity/2f);
    //     SecondTemperature = firstTemperature + A; // 30
    //     oldA = A;
    // }

    // void TemperaturePerHour()
    // {
    //     float B = Mathf.Abs(Hour - 14); //ค่าสัมบูรณ์
    //     float Y = (SecondTemperature - (B / 3f));
    //     lastTemperature = Y;
    // }




    /*void Rain()
    {
        if (lastRate != newRate)
        {
            Debug.Log(" if ");
            Debug.Log(newRate);
            for (int i = 0; i < newRate; i++)
            {
                Debug.Log(" for");
                rainRate[i] = "rainning";
                Debug.Log(" rainRate[i] " + i + " = " + rainRate[i]);

                randomNum = Random.Range(0, 10);

                if (rainRate[randomNum] == "rainning")
                {
                    Debug.Log("rainning");
                    lastRate = newRate;
                }
                else lastRate = newRate;
            }

            lastRate = newRate;
        }          
    }*/   
}

