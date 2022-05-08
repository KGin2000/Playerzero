using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MousePosition : MonoBehaviour
{
    Ray _ray;
    RaycastHit hit;

    public static event Action<Vector3> sendposition; //Action<Vector3> สำหรับส่งค่า Vector3 (เป็น Speaker พูดลอยๆ)

   void Update()
   {
       _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

       if(Physics.Raycast(_ray, out hit)) //ใช้ physics ใส่ algorithm (out คือ ส่งค่าออกมา)
       {
          Vector3 direc = hit.point; //hit.point คืนเป็น Vector3
          direc.y = 0;              //กำหนดค่า y

          //if(Input.GetMouseButton(0))   //เช็คคลิ๊ก 0 เม้าซ้าย
          //{
              if (sendposition != null)
              {
                  sendposition(direc);
              }
          //}
          //Debug.Log("direc" + direc); //Print Position Mouse
       }
       else
       {
           //Debug.Log("Out of Plane");
       }
       
   }
}
