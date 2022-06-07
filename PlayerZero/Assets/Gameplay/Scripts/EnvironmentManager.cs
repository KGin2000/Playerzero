using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : SingletonMonobehaviour<EnvironmentManager>
{
    public bool Hot;
    public bool Rain;
    public bool Rainsound;
    public int Drought = 0;
    public bool StatusRain; 

    public int Rain_Probability;
    public int x;

    public int stackRain;

    Climate climate;

    [SerializeField] public GameObject Raining;

    void Start()
    {
        GameObject a = GameObject.FindGameObjectWithTag("InfomationManager");
        climate = a.GetComponent<Climate>();
        StatusRain = false;
    }

    void Update()
    {
        RaindomRain();
        SetRain();
        GetTemp();
    }

    public void RaindomRain()
    {
        if(TimeManager.Instance.gameHour == 12 && TimeManager.Instance.gameMinute == 0)
        {
            Debug.Log("Random");
            x = Random.Range(1,11);
        }

       
    }

    public void GetRaindomRain()
    {
        
        x = Random.Range(1,11);
    }

    public void CheckRain()
    {
        if(Rain)
        {
            Raining.SetActive(true);
            Rainsound = true;
            StatusRain = true;

            AudioManager.Instance.RePlaySceneSounds();       //Check for Sound
            Climate.Instance.GethumidityfromRain(1f);

            
        }
        else
        {
            Raining.SetActive(false);
            Rainsound = false;
            StatusRain = false;

            AudioManager.Instance.RePlaySceneSounds();       //Check for Sound
            Climate.Instance.GethumidityfromRain(0f);
        }
    }

    void SetRain()
    {
         if(x <= Rain_Probability)
        {
            Rain = true;
        }
        else
        {
            Rain = false;
        }
    }

    void GetTemp()
    {
        if(TimeManager.Instance.gameHour == 12 && TimeManager.Instance.gameMinute == 30)
        {
            if(Climate.Instance.totalTemperature >= 29)
            {
                if(Drought < 7)
                {
                    if(Drought < 6)
                {
                    Drought++;
                }
                }
                
            }
            else if (Climate.Instance.totalTemperature < 29 && Climate.Instance.totalTemperature >= 28.5)
            {
                if(Drought < 3)
                {
                    Drought++;
                }
            }
            else if(Climate.Instance.totalTemperature < 28.5)
            {
                if(Drought < 0)
                {
                    Drought--;
                }
            }

            if(StatusRain)
            {
                if(Drought >= 3)
                {
                    Drought = 0;
                }
                else if(Drought < 3 && Drought > 0)
                { 
                    Drought = 0;
                }
            }
        }
    }
}
