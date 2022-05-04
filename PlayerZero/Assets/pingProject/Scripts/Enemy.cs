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
    [SerializeField] private int hungryTime;

    [SerializeField] private GameObject Meat = null;
    private int NumberOfMeat = 3;

    private float time; // ใช้นับเวลาเฉยๆ
    private float floatTime;

    public int countEat = 0; 
    public bool functionCounterAttack = false;


    void Start()
    {

        gameObject.name = Name;
        currentHealth = maxHealth;
        currentHungryPoint = maxHungryPoint;    
    }

    void Update() 
    {
        time += Time.deltaTime;

        floatTime += Time.deltaTime;
        int intTime = Convert.ToInt32(floatTime);
        if (intTime / hungryTime == 1) // time for hungry
        {
            Hungry();
            floatTime = 0.0f;
        }
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
        currentHealth -= damage * Time.deltaTime;
    }

    public void Eat(int healPoint)
    {
        currentHealth += 5;
        currentHungryPoint += healPoint;
        countEat += 1;
    }

    void Hungry()
    {
        currentHungryPoint -= 1;
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

    public void CounterAttack(GameObject Attacker)
    {
        if (functionCounterAttack == true)
        {
            int random = Random.Range(0, 2);
            if (random == 1)
            {
                Attacker.GetComponent<Enemy>().TakeDamage(20);
                //Debug.Log("Hit " + Attacker);
            }
        }
        else return;
    }


    /*void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, colliderRange);
        Gizmos.DrawWireSphere(transform.position, spaceAnotherCave);
    }*/
}
