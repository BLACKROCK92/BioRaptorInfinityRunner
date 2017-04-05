using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject shotPrefab;
    public Transform shotSpawn;
    public Transform shotSpawn2;
    public float fireRate = 1.5f;
    public float delay;
    public float speed;

    public AudioSource audioS;

    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        var shot = Instantiate(shotPrefab, shotSpawn.position, Quaternion.identity);
        var shot2 = Instantiate(shotPrefab, shotSpawn2.position, Quaternion.identity);
        audioS.Play();
    }

    private void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

    }
}
