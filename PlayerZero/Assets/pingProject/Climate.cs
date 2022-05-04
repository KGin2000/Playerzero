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

    private float timePerMonth;
    private float timePerDay;
    private float second;


    private int x;
    private int newRate;
    private int lastRate;


    private int gamrMonth = 1;
    private int gameYear = 1;   
    private int gameDay = 1;
    public int gameHour = 7;
    private int gameMinute = 0;
    private int gameSecond = 0;
   

    private bool gameClockPaused = false;

    private float gameTick = 0f;
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
        //Rain();
        Humidity();

        if (!gameClockPaused)
        {
            GameTick();
        }

        if (gameMinute == 59)
        {
            TemperaturePerHour();
            //Debug.Log("TemperaturePerHour()");
        }

        if (gameHour == 23)
        {
            TemperaturePerDay();
            //Debug.Log("TemperaturePerDay()");
        }
        if (gameDay == 30)
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
        float B = Mathf.Abs(gameHour - 14); //ค่าสัมบูรณ์
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
    private void GameTick()
    {
        gameTick += Time.deltaTime;

        if (gameTick >= Settings.secondsPerGameSecond)
        {
            gameTick -= Settings.secondsPerGameSecond;

            UpdateGameSecond();

        }

    }
        

    private void UpdateGameSecond()
    {
        gameSecond = gameSecond + 1;

        if (gameSecond > 59)
        {
            gameSecond = 0;
            gameMinute++;

            if (gameMinute > 59)
            {
                gameMinute = 0;
                gameHour++;



                if (gameHour > 23)
                {
                    gameHour = 0;
                    gameDay++;


                    if (gameDay > 30)
                    {
                        gameDay = 1;
                        gamrMonth++;


                        if (gamrMonth > 12)
                        {
                            gamrMonth = 1;
                            gameYear++;

                            

                            if (gameYear > 9999)
                            {
                                gameYear = 1;
                            }
                        }                           
                    }
                }
            }
        }
    }
}

