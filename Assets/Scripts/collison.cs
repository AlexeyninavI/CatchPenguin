using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collison : MonoBehaviour
{
    private Canvas joystick;
   // public TextMesh text;
  //  int count = 1;

    void OnTriggerEnter(Collider other)
    {
        // apply gravity x3 for water
        if (other.gameObject.name == "TextureWater")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.down * 3.0f, ForceMode.VelocityChange);
        }
    }

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
            scontroller.ScaleUp(20); // При взаимодействии с пингвином увериличавется счетчик на 20
        }
        else if (collision.gameObject.name == "fishBullet(Clone)")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
            Destroy(collision.gameObject);
            scontroller.RewardUp(); // При взаимодействии с рыбой увеличивается кол-во игровой волюты на 1
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
        
    }
}
