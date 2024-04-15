using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform ballSpawn;

    public GameObject dodgeball;

    public float nextShoot = 1.0f;
    public float currentTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        ballSpawn = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }


    public void shoot()
    {
        currentTime += Time.deltaTime;

        if (Input.GetButton ("Fire1") && currentTime > nextShoot)
        {
            nextShoot += currentTime;

            Instantiate(dodgeball, ballSpawn.position, Quaternion.identity);

            nextShoot -= currentTime;
            currentTime = 0.0f;
        }
    }




}
