using System;
using UnityEngine;


public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    private Animator anim;

    public void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        // if player is old model
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        variableJoystick = FindObjectOfType<VariableJoystick>();
    }

    private Vector3 lookDir;
    private Vector3 oldLookDir;

    public void FixedUpdate()
    {
        if (variableJoystick.Vertical != 0f || variableJoystick.Horizontal != 0f)
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
            oldLookDir = direction;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(oldLookDir);
        }
        Animating();
    }

    void Animating()
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = variableJoystick.Horizontal != 0f || variableJoystick.Vertical != 0f;
        float defaultAnimationSpeed = 1.0f;
        if (walking)
        {
            float speedAnim = Math.Abs(defaultAnimationSpeed * variableJoystick.Vertical + defaultAnimationSpeed * variableJoystick.Horizontal);
            if (speedAnim > defaultAnimationSpeed)
            {
                speedAnim = defaultAnimationSpeed;
            }
            anim.speed = speedAnim;
            //Debug.Log("Speedy racer: " + speedAnim);
        }
        else
        {
            anim.speed = defaultAnimationSpeed;
        }

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}