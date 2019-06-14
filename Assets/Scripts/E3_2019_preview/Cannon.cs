using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject muzzle;
    public int percentLaunch = 50;
    public bool randomizePercentLaunch = false;
    public int maxRandomPercentLaunch = 100; // default 100%
    public float bulletForce = 700f; //this is the bullet speed.  700 is the default
    public int repeatDelay = 6;

    // Start is called before the first frame update
    void Start()
    {
        if (randomizePercentLaunch)
        {
            percentLaunch = Random.Range(1, maxRandomPercentLaunch + 1);
        }
        InvokeRepeating("fire", repeatDelay, repeatDelay);
    }

    public void fire()
    {
        int chance = Random.Range(0, 101);
        if (chance <= percentLaunch)
        {
            GameObject newBullet = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation); // make a new clone at raycast hit position
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();

            float force = Random.Range(bulletForce, bulletForce + 50);
            //make the new bullet go forward by this much force
            rb.AddForce(muzzle.transform.forward * force);

            if (randomizePercentLaunch)
            {
                percentLaunch = Random.Range(1, maxRandomPercentLaunch + 1);
            }
        }
    }
}
