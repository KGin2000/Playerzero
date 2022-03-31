using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    void OnTriggerEnter (Collider collider)
    {
        GameControlScript.moneyAmount += 1;
        Destroy (gameObject);
    }
}
