using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMoveSpeedController : MonoBehaviour
{
    public float speed;
    public int damage;
    void Start()
    {
        damage = 100;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter (Collider collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Debug.Log("Arrow");
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
