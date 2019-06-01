using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject muzzle;
    public int percentLaunch = 50;
    public bool randomizePercentLaunch = false;
    public float bulletForce = 700f; //this is the bullet speed.  700 is the default

    // Start is called before the first frame update
    void Start()
    {
        if (randomizePercentLaunch)
        {
            percentLaunch = Random.Range(0, 101);
        }
        InvokeRepeating("fire", 4, 4);
    }

    public void fire()
    {
        int chance = Random.Range(0, 101);
        if (chance <= percentLaunch)
        {
            GameObject newBullet = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation); // make a new clone at raycast hit position
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();

            //make the new bullet go forward by this much force
            rb.AddForce(muzzle.transform.forward * bulletForce);

            if (randomizePercentLaunch)
            {
                percentLaunch = Random.Range(0, 101);
            }
        }
    }
}
