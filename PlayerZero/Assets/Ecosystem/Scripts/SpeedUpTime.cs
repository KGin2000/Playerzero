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
        timeCount += Time.deltaTime;
        
        if(modifiedScale != 0)
        {
            TimeManager.Instance.TestAdvanceGameMinute();
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            modifiedScale += 1;
            Time.timeScale = modifiedScale;

        }

    }
}
