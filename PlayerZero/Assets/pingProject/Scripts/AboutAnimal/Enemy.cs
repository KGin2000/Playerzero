using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System;
//using BehaviorDesigner.Runtime;



public class Enemy : MonoBehaviour
{
    [SerializeField] private string Name;
     public float maxHealth;
     public float currentHealth;
     public int maxHungryPoint;
     public int currentHungryPoint;
    [SerializeField] private int hungryRate;
    [SerializeField] private int hungryRateNormalMode;
    [SerializeField] private int hungryRateSleepMode;
    [SerializeField] private int hungryRateFastingMode;

    [SerializeField] private GameObject Meat = null;
    private int NumberOfMeat = 3;

    public float floatTime;

    public int countEat = 0; 


    void Start()
    {
        hungryRate = hungryRateNormalMode;
        gameObject.name = Name;
        currentHealth = maxHealth;
        currentHungryPoint = maxHungryPoint;    
    }

    void Update() 
    {
        Hungry();             
        if (currentHealth >= maxHealth) // check currentHealth dont over maxHealth
        {
            currentHealth = maxHealth;
        }
        if (currentHungryPoint >= maxHungryPoint) // check currentHungryPoint dont over maxHungryPoint
        {
            currentHungryPoint = maxHungryPoint;
        }

        if (currentHungryPoint < 0)
        {
            currentHungryPoint = 0;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
            DropMeat();
        }

    }

    public void TakeDamage(int damage) // damage from AgentCombat Script
    {
        currentHealth -= damage; //* Time.deltaTime;
    }

    public void Eat(int healPoint)
    {
        currentHealth += 5;
        currentHungryPoint += healPoint;
        countEat += 1;
    }

    void Hungry()
    {
        floatTime += Time.deltaTime;

        if(currentHungryPoint < (0.15)*maxHungryPoint)
        {
            hungryRate = hungryRateFastingMode;
        }
        else if(gameObject.tag == "ImmortalObject")
        {
            hungryRate = hungryRateSleepMode;
        }    
        else hungryRate = hungryRateNormalMode;

        if (floatTime >= hungryRate) // time for hungry
        {
            currentHungryPoint -= 1;
            floatTime = 0.0f;
        }
    }

    void DropMeat()
    {
        Vector3 thisPosition = transform.position;
        for (int i = 0; i < NumberOfMeat; i++)
        {
            GameObject rawMeat = (GameObject)Instantiate(Meat);
            rawMeat.transform.position = new Vector3(Random.Range(thisPosition.x + 2, thisPosition.x - 2), 0.5f, Random.Range(thisPosition.z + 2, thisPosition.z - 2));
        }
    }
  
    /*void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, colliderRange);
        Gizmos.DrawWireSphere(transform.position, spaceAnotherCave);
    }*/
}
