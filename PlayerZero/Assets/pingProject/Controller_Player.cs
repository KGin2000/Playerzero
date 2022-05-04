using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void RotateObject(GameObject currentObject, float speed, float rotationAngle, int direction)
    {
        var value = Time.deltaTime * rotationAngle * speed * direction;
        currentObject.transform.Rotate(0, 0, value);
    }
}
