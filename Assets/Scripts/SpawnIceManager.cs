using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IceManager : MonoBehaviour
{

    public GameObject ICE;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] SpawnPoint;
    public bool[] Trigger;// An array of the spawn points this enemy can spawn from.


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // If the player has no health left...


        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, SpawnPoint.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if (Trigger[spawnPointIndex] == false)
        {
            Instantiate(ICE, SpawnPoint[spawnPointIndex].position, SpawnPoint[spawnPointIndex].rotation);
            Trigger[spawnPointIndex] = true;
        }
        spawnPointIndex = Random.Range(0, Trigger.Length);
        if(Trigger[spawnPointIndex] == true)
        {
            Destroy(gameObject,3f);
        }

    }
}
