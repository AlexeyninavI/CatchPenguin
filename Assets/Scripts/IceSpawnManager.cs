using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class IceSpawnManager : MonoBehaviour
{

    public GameObject ICE;                // The enemy prefab to be spawned.
    public float spawnTime = 1f;            // How long between each spawn.
    
    // An array of the spawn points this enemy can spawn from.
    
    public static int count = 4;
    public Transform spawnpoint;
    
    private GameObject[,] Clones = new GameObject[count,count];
    public Transform[,] SpawnPoint = new Transform[count, count];
    public bool[,] Trigger = new bool[count, count];


    void Start()
    {
        float next = 4.0f;
        float neyt = 0;
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                spawnpoint.position = new Vector3(0 + next, -3.0f, -0 + neyt);
                SpawnPoint[i,j] = Instantiate(spawnpoint, spawnpoint.position, spawnpoint.rotation);
           
                next += 4.0f;
            }
            next = 4.0f;
            neyt += 4.0f;
        }
        for (int spawnPointIndex = 0; spawnPointIndex < count; spawnPointIndex++)
        {
            for (int j = 0; j < count; j++)
            {
                Clones[spawnPointIndex, j] = Instantiate(ICE, SpawnPoint[spawnPointIndex, j].position, SpawnPoint[spawnPointIndex, j].rotation);
                Trigger[spawnPointIndex, j] = true;
            }
           // Instantiate(ICE, SpawnPoint[spawnPointIndex].position, SpawnPoint[spawnPointIndex].rotation);
        }
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                if(Trigger[i,j] != true)
                {
                    Trigger[i, j] = false;
                }
            }

        }
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        

    }


    void Spawn()
    {
        // If the player has no health left...


        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, count);
        int randomI = Random.Range(0, count);
        
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if (Trigger[spawnPointIndex, randomI] == false)
        {
           Clones[spawnPointIndex,randomI] = Instantiate(ICE, SpawnPoint[spawnPointIndex, randomI].position, SpawnPoint[spawnPointIndex, randomI].rotation);
            Trigger[spawnPointIndex,randomI] = true;
        }

        spawnPointIndex = Random.Range(0, count);
        randomI = Random.Range(0, count);
        if (Trigger[spawnPointIndex, randomI] == true)
        {
            Destroy(Clones[spawnPointIndex, randomI]);
            Trigger[spawnPointIndex, randomI] = false;
        }


    }
  
}