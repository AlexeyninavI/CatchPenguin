using UnityEngine;
using System.Collections;
namespace SampleScene { 
public class PengMovement : MonoBehaviour
{
    Transform player;
   
    UnityEngine.AI.NavMeshAgent nav;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Target").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
       
        nav.SetDestination(player.position);
        
    }
}
    }
