using UnityEngine;
using UnityEngine.AI;

public class PengMovement : MonoBehaviour
{

    public Transform mainTarget;
    public Transform target;

    NavMeshAgent nav;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Target").transform;
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 5);
        int i = 0;
        while (i < hitColliders.Length)
        {
            GameObject gObject = hitColliders[i].gameObject;
            if (gObject.name.StartsWith("fishBullet"))
            {
                target = hitColliders[i].gameObject.transform;
                break;
            }
            i++;
        }

        if (target == null)
        {
            target = mainTarget;
        }
        nav.SetDestination(target.position);
    }
}

