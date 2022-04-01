using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    Vector3 PlayerPosition;
    public GameObject PrefabItem1 = null;
    public int[,] shopItems = new int[5,5];
    public float coins;
    public Text CoinsTXT;
    public Text CoinsTXT2;

    void Start()
    {
        CoinsTXT.text = "Coin: " + coins.ToString();
        CoinsTXT2.text = CoinsTXT.text;

        //ID
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
    }

    public void Update()
    {
        PlayerPosition =  GameManager.instance.playerPosition.Position;
    }

    public void GetCoins(float getcoins)
    {
        Debug.Log("GetDoin");
        coins += getcoins;
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
                Debug.Log("ITem 1");
                GameObject Item1 = Instantiate(PrefabItem1, transform.position,Quaternion.identity);
                Item1.transform.Rotate(90.0f,0.0f,0.0f,Space.Self);
                PlayerPosition.z -= 1f;
                Item1.transform.position = PlayerPosition;
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 2)
            {
                Debug.Log("ITem 2");
            }
        }
    }
}
