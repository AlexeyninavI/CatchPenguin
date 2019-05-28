using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collison : MonoBehaviour
{
    private Canvas joystick;
   // public TextMesh text;
  //  int count = 1;

    void OnCollisionEnter(Collision collision)
    {

        //if(collision.gameObject.name == "PenguinV2")
        // {
        ScoreController scontroller = FindObjectOfType<ScoreController>(); // Получаем ScoreController
                                                                           /**
                                                                           if (collision.gameObject.name == "penguin(Clone)")
                                                                           {
                                                                               Destroy(collision.gameObject);
                                                                               Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
                                                                               scontroller.RewardUp(); // При взаимодействии с пингвинов увеличивается счетчик рыбы на 1
                                                                                                       // text.text = count.ToString();
                                                                                                       // count++;
                                                                           }
                                                                           else if (collision.gameObject.name == "penguin_E3(Clone)") // E3 version
                                                                           {
                                                                               Destroy(collision.gameObject);
                                                                               Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
                                                                               scontroller.RewardUp();
                                                                           }
                                                                       **/
        if (collision.gameObject.tag == "Penguin")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
            Destroy(collision.gameObject);
            scontroller.RewardUp();
        }
        else if (collision.gameObject.name == "fishBullet(Clone)")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
            Destroy(collision.gameObject);
            scontroller.RewardUp(); // При взаимодействии с пингвинов увеличивается счетчик рыбы на 1
        }
        else if (collision.gameObject.name == "DeadZone")
        {
            //Destroy((GameObject.Find("Player")));
            Destroy(gameObject);
            scontroller.StopGame(); // Остановливаю счетчик
            Time.timeScale = 0;
            Canvas[] canvases = FindObjectsOfType<Canvas>();
            foreach (Canvas canvas in canvases)
            {
                if (canvas.gameObject.name == "JoystickCanvas")
                {

                    //Debug.Log("CANVASFINDED");
                    joystick = canvas;
                }
            }
            joystick.gameObject.SetActive(false);
            UIHome.instance.ShowGameOver();

        }
        //Debug.Log("Enter Called"+collision.gameObject.name);

    }
    void OnCollisionExit(Collision collisison)
    {
        //Debug.Log("KAVO?");
    }
}
