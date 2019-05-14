using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collison : MonoBehaviour
{
    private Canvas joystick;
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
<<<<<<< HEAD
            ScoreController scontroller = FindObjectOfType<ScoreController>();
=======
            ScoreController scontroller =    FindObjectOfType<ScoreController>();
>>>>>>> parent of c41ca43... наделал говна
            scontroller.GameOver();
            Time.timeScale = 0;
            Canvas[] canvases = FindObjectsOfType<Canvas>();
            foreach (Canvas canvas in canvases)
            {
                if (canvas.gameObject.name == "JoystickCanvas")
                {
                    
                    Debug.Log("CANVASFINDED");
                    joystick = canvas;
                }
            }
            joystick.gameObject.SetActive(false);
            UIHome.instance.ShowGameOver();

        }
        Debug.Log("Enter Called"+collision.gameObject.name);

    }
    void OnCollisionExit(Collision collisison)
    {
        Debug.Log("KAVO?");
    }
}
