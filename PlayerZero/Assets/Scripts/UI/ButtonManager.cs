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
        UIManager.Instance.EnableFadeBlack();
        Player.Instance.DoSleep();
    }

    public void CloseTabNotSleep()
    {
        UIManager.Instance.DisableNotSleepMenu();
    }
}
