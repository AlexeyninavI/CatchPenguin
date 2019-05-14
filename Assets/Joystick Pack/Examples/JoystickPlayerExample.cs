using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JoystickPlayerExample : MonoBehaviour
{
   
    float TurnSpeed = 2f;
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    public void FixedUpdate()
    {
        

        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        
        Animating();
    }
    void Animating()
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = variableJoystick.Horizontal != 0f || variableJoystick.Vertical != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
   
}