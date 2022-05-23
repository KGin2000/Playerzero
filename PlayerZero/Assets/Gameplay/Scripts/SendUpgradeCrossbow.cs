using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendUpgradeCrossbow : SingletonMonobehaviour<SendUpgradeCrossbow>
{
    // Start is called before the first frame update
    public float RateofFire;
    public float ArrowSpeed;

    public void upgradeRateofFire(float Rate)
    {
        RateofFire += Rate;
    }

    public void upgradeArrowSpeed(float Speed)
    {
        ArrowSpeed += Speed;
    }
}
