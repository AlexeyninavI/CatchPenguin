using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWindPointer : MonoBehaviour
{
    private Windcollision wind;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Error!");
        wind = FindObjectOfType<Windcollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
            TurnPointer(wind.GetDirection());
    }
    void TurnPointer(int direction)
    {
        float directionAngle = 0f;
        Animation climbing = FindObjectOfType<Animation>();
        switch (direction)
        {
            case 0:
                {
                    climbing.Stop();
                    directionAngle = gameObject.transform.rotation.y;
                    break;
                }
            case 1:
                {
                    directionAngle = -0.1f;
                    break;
                }
            case 2:
                {
                    directionAngle = 1f;
                    break;
                }
            case 3:
                {
                    directionAngle = 0.7f;
                    break;
                }
            case 4:
                {
                    directionAngle = -0.7f;
                    break;
                }
        }

        float rotationAngle = 2f; // угол, на который будет поворачиваться указатель за один кадр
        float deltaAngle = 0.01f; // допустимый разброс угла при повороте указателя по направлению ветра
        if (Mathf.Abs(directionAngle - gameObject.transform.rotation.y) < deltaAngle) // если указатель направлен в сторону ветра
        {
            climbing.Play();
        }
        else
        {
            if (gameObject.transform.rotation.y < directionAngle)
                gameObject.transform.Rotate(0, rotationAngle, 0);
            else gameObject.transform.Rotate(0, -rotationAngle, 0);
        }
        //Debug.Log("direction " + direction);
        //Debug.Log("Angle " + gameObject.transform.rotation.y);
    }
}
   