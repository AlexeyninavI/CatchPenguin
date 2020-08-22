using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject PenguinV2;
    public Transform Target;
    public PengMovement script;
    public float spawnTime = 3f;  // How long between each spawn.

    public Transform[] SpawnLocation = new Transform[1];

    public Vector3[] Zone= new Vector3[1];// An array of the spawn points this enemy can spawn from.

    public Vector3[] center = new Vector3[1]; // = Transform 
    private static Vector3 RandomPointInBox(Vector3 center, Vector3 Spawnl)
    {

        return center + new Vector3(
           (Random.value - 0.5f) * Spawnl.x,
           0,
           (Random.value - 0.5f) * Spawnl.z
        );
    }

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        Spawn();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        //Instantiate(PenguinV2, Spawn(Random.Range(minY, maxY), Random.Range(minZ, maxZ), Random.Range(minX, maxX)), Quaternion.identity)
        int rolls = Random.Range(0, Zone.Length - 1);

        script = this.PenguinV2.gameObject.GetComponent<PengMovement>();
        script.mainTarget = Target;
        script.target = Target;
        Instantiate(PenguinV2, RandomPointInBox(center[rolls], Zone[rolls]), SpawnLocation[rolls].rotation);
        // Find a random index between zero and one less than the number of spawn points.
        //int spawnPointIndex = RandomPointInBox( center, SpawnPoint.Scale)
        // SpawnLocation.position = Random.insideUnitCircle

    }
}
