using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collison : MonoBehaviour
{
   // public TextMesh text;
  //  int count = 1;
    // Start is called before the first frame update
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay occuring");

    }
    void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.name == "PenguinV2")
        // {
        if (collision.gameObject.name== "PenguinV2(Clone)")
        {
            Destroy(collision.gameObject);
           // text.text = count.ToString();
           // count++;
        }
        if(collision.gameObject.name == "DeadZone")
        {
            Destroy((GameObject.Find("Player")));
        }
        Debug.Log("Enter Called"+collision.gameObject.name);

    }
    void OnCollisionExit(Collision collisison)
    {
        Debug.Log("KAVO?");
    }
}
