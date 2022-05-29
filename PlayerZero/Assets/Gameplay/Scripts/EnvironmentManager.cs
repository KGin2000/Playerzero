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

    void Update()
    {
        RaindomRain();
        SetRain();
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

            AudioManager.Instance.RePlaySceneSounds();       //Check for Sound
        }
        else
        {
            Raining.SetActive(false);
            Rainsound = false;

            AudioManager.Instance.RePlaySceneSounds();       //Check for Sound
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
}
