using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate = new Transform [16];
    NavMeshSurface nav;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Bake",2,2);
        
    }
    void Bake()
    {
        NavMeshSurface nav = GetComponent<NavMeshSurface>();
        nav.BuildNavMesh();
    }
}

