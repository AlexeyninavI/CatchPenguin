using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
           
    public GameObject PenguinV2;
   
    public float spawnTime = 3f;  // How long between each spawn.

    public Transform[] SpawnLocation = new Transform[4];
    public Transform SpawnLocation2;
    public Transform SpawnLocation3;
    public Transform SpawnLocation4;

    public Vector3[] Spawnl = new Vector3[1];// An array of the spawn points this enemy can spawn from.
    public Vector3 Spawn4;
    public Vector3 Spawn3;
    public Vector3 Spawn2;

    public Vector3[] center = new Vector3[1];
    private static Vector3 RandomPointInBox(Vector3 center, Vector3 Spawnl)
    {

        return center + new Vector3(
           (Random.value - 0.5f) * Spawnl.x,
           0,
           (Random.value - 0.5f) * Spawnl.y
        );
    }

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // If the player has no health left...
        //Instantiate(PenguinV2, Spawn(Random.Range(minY, maxY), Random.Range(minZ, maxZ), Random.Range(minX, maxX)), Quaternion.identity)
        int rolls = Random.Range(0, 1);
        Instantiate(PenguinV2, RandomPointInBox(center[rolls],Spawnl[rolls]), SpawnLocation[rolls].rotation);
        // Find a random index between zero and one less than the number of spawn points.
        //int spawnPointIndex = RandomPointInBox( center, SpawnPoint.Scale)
       // SpawnLocation.position = Random.insideUnitCircle
       // // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
       // Instantiate(PenguinV2, SpawnPoint[spawnPointIndex].position, SpawnPoint[spawnPointIndex].rotation);
        //Instantiate()
    }
}
