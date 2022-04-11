using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Stat
{
    public int maxVal;
    public int currVal;

    public Stat(int curr, int max)
    {
        maxVal = max;
        currVal = curr;
    }

    internal void Subtract(int amount)
    {
        currVal -= amount;
        
        if (currVal < 0)
        {
            currVal = 0;
        }
    }

    internal void Add(int amount)
    {
        currVal += amount;

        if (currVal > maxVal)
        {
            currVal = maxVal;
        }
    }

    internal void SetToMax()
    {
        currVal = maxVal;
    }
}

public class PlayerStatus : SingletonMonobehaviour<PlayerStatus>
{
    public Stat hp;
    [SerializeField] StatusBar hpBar;
    public Stat stamina;
    [SerializeField] StatusBar staminaBar;
    public bool isDead;
    public bool isExhausted;

    private void Start()
    {
        UpdateHPBar();
        UpdateStaminaBar();
    }

    private void UpdateHPBar()
    {
        hpBar.Set(hp.currVal, hp.maxVal);
    }

    private void UpdateStaminaBar()
    {
        staminaBar.Set(stamina.currVal, stamina.maxVal);
    }

    public void TakeDamage(int amount)
    {
        hp.Subtract(amount);
        if (hp.currVal < 0)
        {
            isDead = true;
        }
        UpdateHPBar();
    }

    public void Heal(int amount)
    {
        hp.Add(amount);
        UpdateHPBar();
    }

    public void FullHeal()
    {
        hp.SetToMax();
        UpdateHPBar();
    }

    public void GetTired(int amount)
    {
        stamina.Subtract(amount);

        if(stamina.currVal < 0)
        {
            isExhausted = true;
        }
        UpdateStaminaBar();
    }

    public void Rest(int amount)
    {
        stamina.Add(amount);
        UpdateStaminaBar();
    }

    public void FullRest()
    {
        stamina.SetToMax();
        UpdateStaminaBar();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(10);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            FullHeal();
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            GetTired(10);
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            FullRest();
        }
    }
}