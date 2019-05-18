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
        ScoreController scontroller = FindObjectOfType<ScoreController>(); // Получаем ScoreController
        if (collision.gameObject.name== "penguin(Clone)")
        {
            Destroy(collision.gameObject);
            scontroller.RewardUp(); // При взаимодействии с пингвинов увеличивается счетчик рыбы на 1
           // text.text = count.ToString();
           // count++;
        }
        if(collision.gameObject.name == "DeadZone")
        {
            Destroy((GameObject.Find("Player")));
            scontroller.StopGame(); // Остановливаю счетчик
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
