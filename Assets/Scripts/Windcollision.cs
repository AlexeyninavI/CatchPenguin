using UnityEngine;
using UnityEngine.UI;

public class Windcollision : MonoBehaviour
{
    public Text messageText;
    public float force;
    public float standForce = 0.3f;
    public float timeRemaining = 5f;
    private float tick = 0;
    bool wind = false;
    float hoverForce;
    public int napravlen;
    public Transform bulletPrefab;
    public float maxVelocitySpeed = 11.0f; // default

    // text display
    public int timeDisplayVisible = 2; // 2 seconds
    private int tickDisplay = -1;

    // icon
    public Image image;

    void Start()
    {
        tick = timeRemaining;
        InvokeRepeating("decreaseTick", 1.0f, 1.0f);
        Transform bullet = Instantiate(bulletPrefab) as Transform;
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void Update()
    {
        if (tickDisplay == 0)
        {
            tickDisplay = -1; // disable
            messageText.text = "";
            // update image
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
        }

        if (tick < 0 && wind == false)
        {
            hoverForce = force;
            tick = timeRemaining;
            napravlen = Random.Range(1, 5);
            wind = true;
            tickDisplay = timeDisplayVisible;
            messageText.text = "Ветер дует";

            // update image
            Vector3 rotationVector = new Vector3(0, 0, 90); // default
            Vector3 rotationWind = new Vector3(0, 0, 0);
            switch (napravlen)
            {
                case 1: // forward
                    {
                        rotationVector = new Vector3(0, 0, 270);
                        rotationWind = new Vector3(0, 0, 0);
                        break;
                    }
                case 2: //back
                    {
                        rotationVector = new Vector3(0, 0, 90);
                        rotationWind = new Vector3(0, 180, 0);
                        break;
                    }
                case 3:
                    {
                        rotationVector = new Vector3(0, 0, 180);
                        rotationWind = new Vector3(0, 90, 0);
                        break;
                    }
                case 4:
                    {
                        rotationVector = new Vector3(0, 0, 0);
                        rotationWind = new Vector3(0, 270, 0);
                        break;
                    }
            }
            RectTransform rectTransform = image.GetComponent<RectTransform>();
            //rectTransform.Rotate(vector);
            Quaternion rotation = Quaternion.Euler(rotationVector);
            rectTransform.rotation = rotation;
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;

            // update windzone
            GameObject wheather = GameObject.Find("Wheather");
            WindZone zone = wheather.GetComponent<WindZone>();
            zone.windMain = 2.0f;
            Quaternion windRotation = Quaternion.Euler(rotationWind);
            wheather.transform.rotation = windRotation;
        }
        else if (tick < 0 && wind == true)
        {
            hoverForce = 0;
            tick = timeRemaining * 2;
            wind = false;
            tickDisplay = timeDisplayVisible;
            messageText.text = "Ветер не дует";

            // update image
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;

            // update windzone
            GameObject wheather = GameObject.Find("Wheather");
            WindZone zone = wheather.GetComponent<WindZone>();
            zone.windMain = 0.0f;
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
                GameObject player = GameObject.FindGameObjectWithTag("PlayerSkin");
                if (player != null)
                {
                    Rigidbody rb = player.GetComponent<Rigidbody>();
                    JoystickPlayerExample jpe = player.GetComponent<JoystickPlayerExample>();
                    //TODO: make a separate physics file
                    if (jpe.isGrounded())
                    {
                        if (jpe.isJoystickMoved())
                        {
                            if (rb.velocity.magnitude < maxVelocitySpeed)
                            {
                                other.attachedRigidbody.AddForce(vector * hoverForce);
                            }
                        }
                        else
                        {
                            other.attachedRigidbody.AddForce(vector * standForce, ForceMode.VelocityChange);
                        }
                    }
                }
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
