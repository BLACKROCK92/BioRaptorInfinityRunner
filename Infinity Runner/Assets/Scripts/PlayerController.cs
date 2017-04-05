using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Boundary bounds;
    public float tilt;
    public GameObject shot;
    public GameObject shotLvl1;
    public GameObject shotLvl2;
    public GameObject shotLvl3;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public Transform[] shotspawns;
    public float fireRate = 0.5f;
    public float nextFire = 0.01f;
    public int powerLevel;

    private void Start()
    {
        shotspawns = new Transform[2];
        shotspawns[0] = shotSpawn1;
        shotspawns[1] = shotSpawn2;
        powerLevel = 1;
        shot = shotLvl1;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 pos = new Vector3(moveHorizontal, moveVertical, 0.0f);
        GetComponent<Rigidbody>().velocity = pos * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, bounds.xMin, bounds.xMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, bounds.yMin, bounds.yMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, bounds.zMin, bounds.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    void Update()
    {
        if (powerLevel == 2)
        {
            shot = shotLvl2;
        }
        else if (powerLevel == 3)
        {
            shot = shotLvl3;
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire || Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            if (powerLevel == 2)
            {
                fireRate = 0.4f;
            }
            else if (powerLevel == 3)
            {
                fireRate = 0.2f;
            }
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotspawns[0].transform.position, Quaternion.identity);
            Instantiate(shot, shotspawns[1].transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
        }
    }

}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax, yMax, yMin;
}