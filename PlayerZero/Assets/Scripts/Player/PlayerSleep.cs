using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSleep : SingletonMonobehaviour<PlayerSleep>
{
    public void DoSleep()
    {
        StartCoroutine(SleepRoutine());
    }

    IEnumerator SleepRoutine()
    {
        ScreenTint screenTint = GameManager.instance.screenTint;

        screenTint.Tint();
        yield return new WaitForSeconds(1f);

        screenTint.UnTint();
        yield return new WaitForSeconds(1f);

        UIManager.Instance.DisableFadeBlack();

        yield return null;
    }
}
