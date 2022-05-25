using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValueDaily : SingletonMonobehaviour<GetValueDaily>
{
    public bool Hot;
    public bool Rain;
    public bool Rainsound;

    [SerializeField] public GameObject Raining;

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

    public int Drought = 0; 
}
