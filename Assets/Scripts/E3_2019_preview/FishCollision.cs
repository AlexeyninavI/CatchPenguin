using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollision : MonoBehaviour
{
    //public GameObject gameObject;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DeadZone")
        {
            Destroy(gameObject);
        }
    }
}
