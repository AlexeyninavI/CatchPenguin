using UnityEngine;
using UnityEngine.AI;

public class Baker : MonoBehaviour
{
    public bool timerEnable = true;
    public float timef = 2;
    NavMeshSurface nav;

    // Use this for initialization
    private void Bake()
    {
        nav.BuildNavMesh();
    }

    public void UpdateNavMesh()
    {
        nav.UpdateNavMesh(nav.navMeshData);
    }

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshSurface>();
        Bake();
        if (timerEnable)
        {
            InvokeRepeating("UpdateNavMesh", timef, timef);
        }
    }

    
}
