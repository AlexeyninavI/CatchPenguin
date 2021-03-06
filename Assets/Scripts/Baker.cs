﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Baker : MonoBehaviour
{
    public bool timerEnable = true;
    public float timef;
    // Start is called before the first frame update

    UnityEngine.AI.NavMeshSurface nav;
    // Use this for initialization
    private void Bake()
    {
        nav.BuildNavMesh();
    }

    public void updateNavMesh()
    {
        nav.UpdateNavMesh(nav.navMeshData);
    }

    private void SetOptimization()
    {
        nav.overrideVoxelSize = true;
        nav.voxelSize = 0.25f;
        nav.overrideTileSize = true;
        nav.tileSize = 64;
    }

    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshSurface>();
        //SetOptimization();
        Bake();
        if (timerEnable)
        {
            InvokeRepeating("UpdateNavMesh", 0, timef);
        }
    }

    
}
