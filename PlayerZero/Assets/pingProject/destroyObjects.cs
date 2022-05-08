using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObjects : MonoBehaviour
{
    public string TagObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == TagObj)
        {
            Destroy(collider.gameObject);
            Debug.Log("destroy obj");
        }
    }
}
