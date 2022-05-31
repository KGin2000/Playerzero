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
        else if (itemCode == 10011) {x = 25.0f;} //Carrot
        else if (itemCode == 10012) {x = 25.0f;} //Cabbage
        else if (itemCode == 10019) {x = 80.0f;} //Pumpkin
        else if (itemCode == 10020) {x = 50.0f;} //Sunflower
        
        else if (itemCode == 10013) {x = 5.0f;} //Oak Acorn
        else if (itemCode == 10014) {x = 10.0f;} //wood
        
        else if (itemCode == 10009) {x = 15.0f;} //Carrot Seed
        else if (itemCode == 10010) {x = 15.0f;} //Cabbage Seed
        else if (itemCode == 10021) {x = 30.0f;} //Sunflower Seed
        else if (itemCode == 10022) {x = 40.0f;} //Pumpkin Seed

        else if (itemCode == 10024) {x = 20.0f;} //Rabbit Meat
        else if (itemCode == 10025) {x = 40.0f;} //Boar meat
        else if (itemCode == 10026) {x = 100.0f;} //Wolf Meat

        else if (itemCode == 10016) {x = 15.0f;} //Pumpkin Torch
        
        GameManager.instance.ShopManagerScript.GetCoins(x);
    }
}
