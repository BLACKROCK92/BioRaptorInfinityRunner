using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossScript : MonoBehaviour
{

    public GameObject shotPrefab;
    public Transform shotSpawn;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public Transform shotSpawn4;
    public Transform shotSpawn5;
    public float fireRate = 1.5f;
    public float delay;
    public float speed;
    public Boundary bounds;
    public GameObject player;

    public AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        var shot = Instantiate(shotPrefab, shotSpawn.position, Quaternion.identity);
        var shot2 = Instantiate(shotPrefab, shotSpawn2.position, Quaternion.identity);
        var shot3 = Instantiate(shotPrefab, shotSpawn3.position, Quaternion.identity);
        var shot4 = Instantiate(shotPrefab, shotSpawn4.position, Quaternion.identity);
        var shot5 = Instantiate(shotPrefab, shotSpawn5.position, Quaternion.identity);
        audioS.Play();
    }

    private void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, bounds.xMin, bounds.xMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, bounds.yMin, bounds.yMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, bounds.zMin, bounds.zMax)
        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -3);
    }
}