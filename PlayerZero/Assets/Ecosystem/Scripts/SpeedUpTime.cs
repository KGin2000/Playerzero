using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpTime : MonoBehaviour
{
    public float timeCount;
    public float modifiedScale;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            modifiedScale += 1;
            Time.timeScale = modifiedScale;
            timeCount += Time.deltaTime;
        }

    }
}
