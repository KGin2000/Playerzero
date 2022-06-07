using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManManager : SingletonMonobehaviour<InfoManManager>
{
    [SerializeField] GameObject InfoMan;
    [SerializeField] GameObject DialogInfoMan;
    Dialog dialogInfoMan;
    
    void Start()
    {
       dialogInfoMan = DialogInfoMan.GetComponent<Dialog>();
    }

    void Update()
    {
        // SetPositionInfoMan();
    }

    public void SetPositionInfoMan()
    {
        if(TimeManager.Instance.gameHour == 0 && TimeManager.Instance.gameMinute == 0)
        {
            InfoMan.transform.position = new Vector3(104.0f, 0.0f, -60.0f);
        }
        if(TimeManager.Instance.gameHour == 6 && TimeManager.Instance.gameMinute == 0)
        {
            InfoMan.transform.position = new Vector3(0f, 0.0f, 0f);
        }
        
    }

    public void SetDialogInfoMan()
    {
            dialogInfoMan.DialogCode = 300;
            dialogInfoMan.DialogCode = 301;
    }
}
