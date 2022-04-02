using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerPosition : MonoBehaviour
{
    public Vector3 PlayerPosition;

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = transform.position;
        //Debug.Log("PlayerPosition" + Position);
    }
}
