using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinCollisionE3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Target East" || collision.gameObject.name == "Target North" || collision.gameObject.name == "Target South" || collision.gameObject.name == "Target West")
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "fishBullet(Clone)")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
            // типо жрет рыбу
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Penguin")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
        }
    }
}