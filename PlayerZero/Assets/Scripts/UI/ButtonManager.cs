using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void CloseTabCanSleep()
    {
        UIManager.Instance.DisableCanSleepMenu();
    }

    public void AcceptCanSleep()
    {
        UIManager.Instance.DisableCanSleepMenu();
        PlayerSleep.Instance.DoSleep();
        TimeManager.Instance.TestAdvanceSkip();
    }

    public void CloseTabNotSleep()
    {
        UIManager.Instance.DisableNotSleepMenu();
    }
}
