using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : SingletonMonobehaviour<RotateLight>
{
    [SerializeField] private GameObject DirecLight;
    
   [SerializeField] private Vector3 _rotation;
    // Update is called once per frame
    int x = 90;

    int Minute;
    int Hour;

    //public Quaternion RotationOfLight; 
    //public float angleX;

    void Start()
    {
        DirecLight.transform.localRotation = Quaternion.Euler(x, 0, 0);
    }

    void Update()
    {
        Minute = TimeManager.Instance.gameMinute;
        Hour = TimeManager.Instance.gameHour;

        SunUp();
        ///RotationOfLight = DirecLight.transform.rotation;
        // angleX = DirecLight.transform.rotation.eulerAngles.x; 
    }

    public void SunUp()
    {
        if(Hour >= 0)
        {
            if(Hour < 5)
            {
                DirecLight.transform.localRotation = Quaternion.Euler(30, 0, 0);
            }
        }
        if(Hour == 5)   //Rising Sun
        {
            x = Minute + 30;
            DirecLight.transform.localRotation = Quaternion.Euler(x, 0, 0);
        }
         if(Hour >= 6)
        {
            if(Hour < 18)
            {
                DirecLight.transform.localRotation = Quaternion.Euler(90, 0, 0);
            }
        }
        if(Hour == 18) //Sun Down
        {
            x = Minute + 90;
            DirecLight.transform.localRotation = Quaternion.Euler(x, 0, 0);
        }
        if(Hour >= 19)
        {
            DirecLight.transform.localRotation = Quaternion.Euler(150, 0, 0);
        }
    }
}
