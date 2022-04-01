using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGetCoin : MonoBehaviour
{
    float x = 1.0f;
    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.H))
         {
            GameManager.instance.ShopManagerScript.GetCoins(x);
         }
    }
}
