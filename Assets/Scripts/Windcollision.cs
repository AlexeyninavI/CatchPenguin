using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windcollision : MonoBehaviour
{
    public Text messageText;
    public float force;
    public float timeRemaining = 900f;
    public TextMesh text;
    bool wind = false;
    float hoverForce;
    int napravlen;
    public Transform bulletPrefab;
    void Start()
    {
        InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);
    
        Transform bullet = Instantiate(bulletPrefab) as Transform;
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void Update()
    {
        decreaseTimeRemaining();

        if (timeRemaining < 0 && wind == false)
        {
            hoverForce = force;
            timeRemaining = 900f;
            napravlen = Random.Range(1, 4);
            wind = true;
            messageText.text = "Ветер дует";
        }
        else if (timeRemaining < 0 && wind == true)
        {
            hoverForce = 0;
            timeRemaining = 900f;
            wind = false;
            messageText.text = "Ветер не дует";
        }
        
            
       

        //GuiText.text = timeRemaining + " Seconds remaining!";

    }

    void decreaseTimeRemaining()
    {
        timeRemaining--;
    }
    void OnTriggerStay(Collider other)
    {

        switch (napravlen)
        {
            case 1:
                {
                    if (other.attachedRigidbody)
                        other.attachedRigidbody.AddForce(Vector3.forward * hoverForce);
                    
                    break;
                }
            case 2:
                {
                    if (other.attachedRigidbody)
                        other.attachedRigidbody.AddForce(Vector3.back * hoverForce);
                    break;
                }
            case 3:
                {
                    if (other.attachedRigidbody)
                        other.attachedRigidbody.AddForce(Vector3.right * hoverForce);
                    break;
                }
                
            case 4:
                {
                    if (other.attachedRigidbody)
                        other.attachedRigidbody.AddForce(Vector3.left * hoverForce);
                    break;
                }
                
        }

            
        
       
    }

  
}
