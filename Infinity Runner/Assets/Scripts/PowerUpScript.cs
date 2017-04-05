using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    public float speed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(this.gameObject, 0.2f);
            if (other.transform.GetComponent<PlayerController>().powerLevel < 3)
            {
                other.transform.GetComponent<PlayerController>().powerLevel++;
            }
        }
    }

    private void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
