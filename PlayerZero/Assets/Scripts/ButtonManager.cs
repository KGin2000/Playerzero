using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void CloseTab()
    {
        UIManager.Instance.DisableSleepMenu();
    }

    public void Accept()
    {
        UIManager.Instance.DisableSleepMenu();
        TimeManager.Instance.TestAdvanceSkip();
    }
}
