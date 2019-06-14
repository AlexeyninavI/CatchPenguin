using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollision : MonoBehaviour
{

    private GameObject wind;
   
    void Start() {
        wind = GameObject.Find("Wind");
    }
    void Update()
    {
        wind = GameObject.Find("Wind");
        Physics.IgnoreCollision(wind.GetComponent<Collider>(), GetComponent<Collider>());
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "NavMeshWater")
        {
            Destroy(gameObject);
        }
       
    }
}
