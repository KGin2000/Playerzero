using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCoinToWallet : SingletonMonobehaviour<SendCoinToWallet>
{
    float x;
    // Update is called once per frame
    float y = 50;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.instance.ShopManagerScript.GetCoins(y);
        }

    }

    public void CalculatePrice(int itemCode)
    {
        if (itemCode == 10001) {x = 10.0f;}     //Orange
        else if (itemCode == 10002) {x = 15.0f;} //Apple
        GameManager.instance.ShopManagerScript.GetCoins(x);
    }
}
