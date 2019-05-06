using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Baker : MonoBehaviour
{
    public float timef;
    // Start is called before the first frame update

    UnityEngine.AI.NavMeshSurface nav;
    // Use this for initialization
    void Bake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshSurface>();
        nav.BuildNavMesh();
    }
    void Start()
    {
        InvokeRepeating("Bake", 0, timef);

    }

    
}
