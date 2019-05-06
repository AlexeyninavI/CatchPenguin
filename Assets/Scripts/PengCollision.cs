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


        }
    }
}

