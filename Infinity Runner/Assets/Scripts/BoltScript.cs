using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    public float speed;
    public float destroyTimer = 1;
    public GameObject explosion;
    public Rigidbody rb;
    void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(this.gameObject, destroyTimer);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Shot")
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Destroy(gameObject, 0.01f);
            Destroy(other.gameObject, 0.01f);
            Instantiate(explosion, transform.position, transform.rotation);
        }

    }
}
