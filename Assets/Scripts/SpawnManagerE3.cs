using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerE3 : MonoBehaviour
{
           
    public GameObject PenguinV2;
   
    public float spawnTime = 3f;  // How long between each spawn.

    public Transform[] spawnPoints = new Transform[4];

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        int targetNumber = Random.Range(0, spawnPoints.Length);
        Transform targetSpawnPoint = spawnPoints[targetNumber];
        Instantiate(PenguinV2, targetSpawnPoint.position, targetSpawnPoint.rotation);
    }
}
