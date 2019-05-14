using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void Animating(bool trigger)
    {
        // Create a boolean that is true if either of the input axes is non-zero.


        // Tell the animator whether or not the player is walking.
        if (trigger == false) {

            anim.SetBool("ice_down", trigger);
        }
       if (trigger == true)
        {
            anim.SetBool("ice_up", trigger);
        }
    }
}
