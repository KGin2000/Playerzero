using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour
{
    public Text moneyText;
    public static int moneyAmount;
    int isRifleSold;
    public GameObject rifle;

    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt ("MoneyAmount");
        isRifleSold = PlayerPrefs.GetInt ("IsRifleSold");

        if (isRifleSold == 1)
        {
            rifle.SetActive(true);
        }
        else
        {
            rifle.SetActive(false);
        }
    }

    void Update()
    {
        moneyText.text = "Money : " + moneyAmount.ToString() + "$";
    }

    public void gotoShop()
    {
        PlayerPrefs.SetInt ("MoneyAmount", moneyAmount);
        SceneManager.LoadScene ("ShopScene");
    }
}
