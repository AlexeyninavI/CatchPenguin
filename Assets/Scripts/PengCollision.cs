using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PengCollision : MonoBehaviour
{


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "DeadZone")
        {
            Destroy(this.gameObject);
        } else if (collision.gameObject.name == "fishBullet(Clone)")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
            // типо жрет рыбу
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "Penguin")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
        }
    }
}

