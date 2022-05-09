using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climate : MonoBehaviour
{
    [SerializeField] CheckAllAgent checkAllAgent;
     public float lastTemperature; //ร้อนจัด
     private float firstTemperature;
     private float SecondTemperature;
    [SerializeField] private float humidity;

    private int newRate;
    private int lastRate;
  
    private int Day;
    private int Hour;
    private int Minute;
   
    private float treeRatio;
    private float oldA;

    void Start()
    {
        //rainRate = new string[10];
        oldA = 0;
        newRate = 0;
        lastRate = newRate;
        humidity = 0.0f;

        Humidity();
        TemperaturePerMonth();
        TemperaturePerDay();
        TemperaturePerHour();
    }

    void Update() //temperature อิงตามความชื้อกับช่วงเวลา (กลางวันกลางคือน) ความชื้นอิงอามต้นไม้ layer Crop tag Tree
    {
        Day = TimeManager.Instance.gameDay;
        Hour = TimeManager.Instance.gameHour;
        Minute = TimeManager.Instance.gameMinute;

        Debug.Log("Day = " + Day);
        //Debug.Log("Hour = " + Hour);
        //Debug.Log("Minute " + Minute);
        Debug.Log("lastTemperature = " + lastTemperature);

        //Rain();
        Humidity();


        if (Minute == 59) // ของเดิม 59
        {
            TemperaturePerHour();
            //Debug.Log("TemperaturePerHour()");
        }

        if (Hour == 23) // ของเดิม 23
        {
            TemperaturePerDay();
            //Debug.Log("TemperaturePerDay()");
        }
        if (Day == 30) // ของเดิม 30
        {
            TemperaturePerMonth();
            Debug.Log("TemperaturePerMonth()");
        }

        if (lastTemperature > 30f)
        {
            Debug.Log("weather so hot");
            if (humidity < 4)
            {              
                // function rainning;
            }
        }


    }

    void Humidity() // ความชื้นในอากาส
    {   
        if (checkAllAgent.Tree != 0)
        {
            treeRatio = (float)(checkAllAgent.Tree / checkAllAgent.maxTree) * 100f;
            humidity = treeRatio * 0.1f; // ค่าความชื้นในอากาศ 1 - 10
        }
        else if (checkAllAgent.Tree != 0)
        {
            treeRatio = 1;
            humidity = treeRatio * 0.1f;
        }
            
        
    }
    void TemperaturePerMonth() 
    {
        float X = Random.Range(21, 30);
        firstTemperature = X;
    }

    void TemperaturePerDay()
    {
        SecondTemperature = firstTemperature - oldA; //29
        float A = Random.Range(0, humidity/2f);
        SecondTemperature = firstTemperature + A; // 30
        oldA = A;

    }

    void TemperaturePerHour()
    {
        float B = Mathf.Abs(Hour - 14); //ค่าสัมบูรณ์
        float Y = (SecondTemperature - (B / 3f));
        lastTemperature = Y;
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.0f);
    }


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

