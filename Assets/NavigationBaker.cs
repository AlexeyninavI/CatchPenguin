using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate = new Transform [16];
    UnityEngine.AI.NavMeshSurface nav;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Bake",2,2);
        
    }
    void Bake()
    {
        UnityEngine.AI.NavMeshSurface nav = GetComponent<UnityEngine.AI.NavMeshSurface>();
        nav.BuildNavMesh();
    }
}

