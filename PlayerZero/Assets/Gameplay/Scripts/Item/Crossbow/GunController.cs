using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : SingletonMonobehaviour<GunController>
{
    public bool isFiring;
    
    public float timeClickDelay = 0f;
    public float timeShootdelay;
    public float bulletSpeed;

    public ArrowMoveSpeedController bullet;

    public float timeBetweenShots;
    private float shortCounter;

    public Transform firePoint;
    void Start()
    {
        
    }

    private void GetUpgrade()
    {
        timeShootdelay = SendUpgradeCrossbow.Instance.RateofFire;
        bulletSpeed = SendUpgradeCrossbow.Instance.ArrowSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        GetUpgrade();

        if(timeClickDelay > 0f)
        {
            timeClickDelay -= Time.deltaTime;
        }
        else if(timeClickDelay < 0f)
        {
            timeClickDelay = 0f;
        }

        if(timeClickDelay == 0f)
        {
            if(isFiring)
            {
                if(InventoryManager.Instance.haveArrow)
                {
                    shortCounter -= Time.deltaTime;
                    if(shortCounter <= 0)
                    {
                        shortCounter = timeBetweenShots;
                        ArrowMoveSpeedController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as ArrowMoveSpeedController;

                        InventoryManager.Instance.RemoveItem(InventoryLocation.player, 10018);      //ลบ Arrow ออกจาก Inventory 

                        newBullet.speed = bulletSpeed;

                        Debug.Log("Shoot!!!!!!!!!");

                        timeClickDelay = timeShootdelay;
                    }
                }
            }
            else
            {
                shortCounter = 0;
            }
        }
    }
}
