﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlockObject : MonoBehaviour
{
    public GameObject unityObject;
    private bool isSwim = true;
    Animator anim;
    private string name_island_object = "Island";
    GameObject bridge;
    
    // Start is called before the first frame update
    void Start()
    {
        unityObject = gameObject;
        GameObject island = GameObject.Find(name_island_object);
        anim = unityObject.GetComponent<Animator>();
        GlobalSpawnBlocks gsb = island.GetComponent<GlobalSpawnBlocks>();
        gsb.AddCube(this);
       
    }

    public void setSwimming()
    {
        isSwim = false; //LOH
        anim.SetBool("IsSwim", false);
        for (int i = 1; i < 5; i++)
        {
            bridge = this.gameObject.transform.GetChild(i).gameObject;
            bridge.SetActive(true);
        }
        // anim.SetBool("NoSwim", true);
        //anim.Play("ice_down");
    }
    public void setUp()
    {
        isSwim = true; //ne loh
        anim.SetBool("IsSwim", true);
        for (int i = 1; i < 5; i++)
        {
            bridge = this.gameObject.transform.GetChild(i).gameObject;
            bridge.SetActive(false);
        }
       // anim.SetBool("NoSwim", false);
    }
    public void checkerSwim(bool flag)
    {
        isSwim = flag;
        
    }

    public bool isSwimming()
    {
        return isSwim;
    }

    // Update is called once per frame
    void Update()
    {

    }
 
}
