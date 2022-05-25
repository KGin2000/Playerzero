using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : SingletonMonobehaviour<EnvironmentManager>
{
    public bool Hot;
    public bool Rain;
    public bool Rainsound;
    public int Drought = 0; 

    public int Rain_Probability;
    public int x;

    public int stackRain;

    Climate climate;

    [SerializeField] public GameObject Raining;

    void Start()
    {
        GameObject a = GameObject.FindGameObjectWithTag("InfomationManager");
        climate = a.GetComponent<Climate>();
    }

    public void StackRain()
    {
        if(TimeManager.Instance.gameHour == 12 && TimeManager.Instance.gameMinute == 0)
        {
            x = Random.Range(1,11);
        }

        if(climate.light >= 28f && TimeManager.Instance.gameHour == 12 && TimeManager.Instance.gameMinute == 0)
        {
            stackRain += 1;
            Debug.Log("stackRain = " + stackRain);
        }

        if(stackRain == 3)
        {
            Rain = true;
        }
        else
        {
            Rain = false;
        }

        if(climate.light < 28f && TimeManager.Instance.gameHour == 12 && TimeManager.Instance.gameMinute == 0)
        {
            stackRain = 0;
            Rain = false;
        }
        randomRain();
    }

    public void CheckRain()
    {
        if(Rain)
        {
            Raining.SetActive(true);
            Rainsound = true;
        }
        else
        {
            Raining.SetActive(false);
            Rainsound = false;
        }
    }
    void randomRain()
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

    
}
