using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windcollision : MonoBehaviour
{
    public Text messageText;
    public float force;
    public float timeRemaining = 5f;
    private float tick = 0;
    bool wind = false;
    float hoverForce;
    int napravlen;
    public Transform bulletPrefab;

    // text display
    public int timeDisplayVisible = 2; // 2 seconds
    private int tickDisplay = -1;

    void Start()
    {
        tick = timeRemaining;
        InvokeRepeating("decreaseTick", 1.0f, 1.0f);
        Transform bullet = Instantiate(bulletPrefab) as Transform;
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void Update()
    {
        if(tickDisplay == 0)
        {
            tickDisplay = -1; // disable
            messageText.text = "";
        }

        if (tick < 0 && wind == false)
        {
            hoverForce = force;
            tick = timeRemaining;
            napravlen = Random.Range(1, 5);
            wind = true;
            tickDisplay = timeDisplayVisible;
            messageText.text = "Ветер дует";
        }
        else if (tick < 0 && wind == true)
        {
            hoverForce = 0;
            tick = timeRemaining * 2;
            wind = false;
            tickDisplay = timeDisplayVisible;
            messageText.text = "Ветер не дует";
        }
    }

    void decreaseTick()
    {
        tick--;
        if (tickDisplay > 0)
        {
            tickDisplay--;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (wind)
        {
            Vector3 vector = Vector3.forward; // default
            switch (napravlen)
            {
                case 1:
                    {
                        vector = Vector3.forward;
                        break;
                    }
                case 2:
                    {
                        vector = Vector3.back;
                        break;
                    }
                case 3:
                    {
                        vector = Vector3.right;
                        break;
                    }
                case 4:
                    {
                        vector = Vector3.left;
                        break;
                    }

            }
            if (other.attachedRigidbody)
            {
                other.attachedRigidbody.AddForce(vector * hoverForce);
            }
        }
    }
    // нужно для работы ветрового указателя
    public int GetDirection()
    {
        if (wind)
            return napravlen;
        else return 0;
    }
}
