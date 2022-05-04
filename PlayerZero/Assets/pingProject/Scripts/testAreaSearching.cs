using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAreaSearching : MonoBehaviour
{

    [Tooltip("Function AreaSearching")]
    public GameObject targetGameObject = null;
    public Quaternion rotation = Quaternion.identity;

    public int genNum = 1;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Plant")
        {
            AreaSearching();
        }
    }

    void AreaSearching()
    {
        Vector3 thisPosition = transform.position;
        Vector3 size = transform.localScale;
        if (targetGameObject != null)
        {
            for (int i = 0; i < genNum; i++)
            {
                //Instantiate(targetGameObject, thisPosition, Quaternion.identity);

                GameObject A = (GameObject)Instantiate(targetGameObject);
                A.transform.position = new Vector3(thisPosition.x, 0, thisPosition.z);

            }
        }
        else Debug.Log("targetGameObject = null");
    }
}
