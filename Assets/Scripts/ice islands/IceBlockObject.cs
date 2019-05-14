using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlockObject : MonoBehaviour
{
    public GameObject unityObject;
    private bool isSwim = true;
    Animator anim;
    private string name_island_object = "Island";
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject island = GameObject.Find(name_island_object);
        anim = unityObject.GetComponent<Animator>();
        GlobalSpawnBlocks gsb = island.GetComponent<GlobalSpawnBlocks>();
        gsb.AddCube(this);
    }

    public void setSwimming()
    {
        isSwim = false;
        anim.SetBool("IsSwim", false);
        anim.SetBool("NoSwim", true);
        //anim.Play("ice_down");
    }
    public void setUp()
    {
        isSwim = true;
        anim.SetBool("IsSwim", true);
        anim.SetBool("NoSwim", false);
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
