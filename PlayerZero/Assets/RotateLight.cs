using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : SingletonMonobehaviour<RotateLight>
{
    [SerializeField] private GameObject DirecLight;
   [SerializeField] private Vector3 _rotation;
    // Update is called once per frame
    float x = 90.0f;
    void Start()
    {
        DirecLight.transform.localRotation = Quaternion.Euler(x, 0, 0);
    }

    public void RotateLightingDown(float y)
    {
        // transform.Rotate(_rotation * Time.deltaTime);
        // transform.Rotate(x+y, 0, 0);
        if(x < 150.0f)
        {
            // Debug.Log("Y = " + y);
            x += y;
            DirecLight.transform.localRotation = Quaternion.Euler(x, 0, 0);
        }
    }

    public void RotateLightingUp(float y)
    {
        // transform.Rotate(_rotation * Time.deltaTime);
        // transform.Rotate(x+y, 0, 0);
        if(x < 90.0f)
        {
            // Debug.Log("Y = " + y);
            x += y;
            DirecLight.transform.localRotation = Quaternion.Euler(x, 0, 0);
        }
    }

    public void RotateBackLighting()
    {
        transform.Rotate(_rotation * Time.deltaTime * -1);
    }

    public void ReSetLight()
    {
        x = 30.0f;
    }
}
