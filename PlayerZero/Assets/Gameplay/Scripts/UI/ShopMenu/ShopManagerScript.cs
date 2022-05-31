using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : SingletonMonobehaviour<ShopManagerScript>
{
    Vector3 GetPlayerPosition;
    public int[,] shopItems = new int[10,10];
    public float coins;
    public Text CoinsTXT;
    public Text CoinsTXT2;
    public int NumItem;

    void Start()
    {
        CoinsTXT.text = "Coin: " + coins.ToString();
        CoinsTXT2.text = CoinsTXT.text;

        //ID
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;
        shopItems[1, 6] = 6;
        shopItems[1, 7] = 7;
        shopItems[1, 8] = 8;
        shopItems[1, 9] = 9;

        //Price
        shopItems[2, 1] = 20;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 40;
        shopItems[2, 4] = 25;
        shopItems[2, 5] = 50;
        shopItems[2, 6] = 25;
        shopItems[2, 7] = 10;
        shopItems[2, 8] = 50;
        shopItems[2, 9] = 50;

        //Quantity
        shopItems[3, 1] = NumItem;
        shopItems[3, 2] = NumItem;
        shopItems[3, 3] = NumItem;
        shopItems[3, 4] = NumItem;
        shopItems[3, 5] = NumItem;
        shopItems[3, 6] = NumItem;
        shopItems[3, 7] = NumItem;
        shopItems[3, 8] = NumItem;
        shopItems[3, 9] = NumItem;
    }

    public void Update()
    {
            shopItems[2, 8] = 50+(LevelCrossbow.Instance.LevelRateofFire*20);
            shopItems[2, 9] = 50+(LevelCrossbow.Instance.LevelSpeedArrow*20);

            shopItems[3, 8] = LevelCrossbow.Instance.LevelRateofFire;
            shopItems[3, 9] = LevelCrossbow.Instance.LevelSpeedArrow;

            if (LevelCrossbow.Instance.LevelRateofFire == 10)
            {
                shopItems[2, 8] = 99999999;
            }
            if (LevelCrossbow.Instance.LevelSpeedArrow == 10)
            {
                shopItems[2, 9] = 99999999;
            }
    }

    public void GetCoins(float getcoins)
    {
        //Debug.Log("GetDoin");
        coins += getcoins;
        CoinsTXT.text = "Coin: " + coins.ToString();
        CoinsTXT2.text = CoinsTXT.text;
    }

    public void SetCoins()
    {
        //Debug.Log("SavedCoin");
        CoinsTXT.text = "Coin: " + coins.ToString();
        CoinsTXT2.text = CoinsTXT.text;
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = "Coins:" + coins.ToString();
            CoinsTXT2.text = CoinsTXT.text;
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 1)
            {
                
                InventoryManager.Instance.AddItem(InventoryLocation.player, 10009);
              
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 2)
            {
              
                InventoryManager.Instance.AddItem(InventoryLocation.player, 10010);
                
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 3)
            {
                
                InventoryManager.Instance.AddItem(InventoryLocation.player, 10021);
                
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 4)
            {
                
                InventoryManager.Instance.AddItem(InventoryLocation.player, 10016);
               
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 5)
            {
               
                InventoryManager.Instance.AddItem(InventoryLocation.player, 10022);
            }
             else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 7)
            {
               
                InventoryManager.Instance.AddItem(InventoryLocation.player, 10018);
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 8)      //อัตรายิง
            {
                if(LevelCrossbow.Instance.LevelRateofFire <= 9)
                {
                    LevelCrossbow.Instance.LevelRateofFire +=1;
                }
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 9)      //ความเร็ว
            {
                if(LevelCrossbow.Instance.LevelSpeedArrow <= 9)
                {
                    LevelCrossbow.Instance.LevelSpeedArrow +=1;
                }
            }
        }
    }
}
