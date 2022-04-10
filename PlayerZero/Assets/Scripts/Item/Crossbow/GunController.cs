using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public ArrowMoveSpeedController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shortCounter;

    public Transform firePoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFiring)
        {
            shortCounter -= Time.deltaTime;
            if(shortCounter <= 0)
            {
                shortCounter = timeBetweenShots;
                ArrowMoveSpeedController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as ArrowMoveSpeedController;
                InventoryManager.Instance.RemoveItem(InventoryLocation.player, 10018);      //ลบ Arrow ออกจาก Inventory

                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shortCounter = 0;
        }

    }
}
