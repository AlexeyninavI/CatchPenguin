using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMovementE3 : MonoBehaviour
{
    private float distToGround;
    public int bulletForce = 10;
    UnityEngine.AI.NavMeshAgent nav;

    public void Start()
    {
        distToGround = GetComponent<BoxCollider>().bounds.extents.y;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.updatePosition = false;
        nav.updateRotation = false;
    }

    private bool CheckIfGrounded()
    {
        //We raycast down 1 pixel from this position to check for a collider
        RaycastHit hit;
        Vector3 positionToCheck = transform.position;
        bool raycast = Physics.Raycast(positionToCheck, -Vector3.up, out hit, distToGround + 0.2f);

        //if a collider was hit, we are grounded
        if (raycast)
        {
            if (hit.transform.parent == null) return false;
            if (hit.transform.parent.parent == null) return false;
            if (hit.transform.parent.parent.parent == null) return false;
            if (hit.transform.parent.parent.parent.gameObject.name == "Island")
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        if (CheckIfGrounded())
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 pos = rb.position;
            nav.nextPosition = pos;
            //rb.AddForce(nav.desiredVelocity);
            rb.AddForce(transform.forward * bulletForce);
        }
    }
}

