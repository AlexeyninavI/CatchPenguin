using UnityEngine;


public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public Animator anim;

    public void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        // if player is old model
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

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

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}