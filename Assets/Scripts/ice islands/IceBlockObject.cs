
using UnityEngine;

public class IceBlockObject : MonoBehaviour
{
    public GameObject unityObject;
    public bool isDown = false;
    Animator anim;
    private string name_island_object = "Island";
    GameObject bridge;

    // damage
    public bool startDamage;
    public GameObject damage_sprite;
    public float repeateDamageTime = 0.8f;
    public int currentState = 0; // no damage
    private SpriteCollection sprites;
    public int recoveryTime = 0;
    private int tempRecoveryTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        unityObject = gameObject;
        GameObject island = GameObject.Find(name_island_object);
        anim = unityObject.GetComponent<Animator>();
        GlobalSpawnBlocks gsb = island.GetComponent<GlobalSpawnBlocks>();
        gsb.AddCube(this);
        sprites = new SpriteCollection("ice_damages/states");
        tempRecoveryTime = recoveryTime;
    }

    void Start()
    {
        InvokeRepeating("damage", repeateDamageTime, repeateDamageTime);
    }

    void damage()
    {
        if (!startDamage)
        {
            if (tempRecoveryTime > 0)
            {
                tempRecoveryTime--;
            } else if(tempRecoveryTime == 0)
            {
                SpriteRenderer r = damage_sprite.GetComponent<SpriteRenderer>();
                r.sprite = null;
                Up();
            }
            return;
        }

        int nextState = currentState;
        Sprite newSprite = null;
        switch (nextState)
        {
            case 0: // no damage
                nextState = 1;
                newSprite = sprites.GetSprite("01");
                break;
            case 1: // small damage
                nextState = 2;
                newSprite = sprites.GetSprite("02");
                break;
            case 2: // medium damage
                nextState = 3;
                newSprite = sprites.GetSprite("03");
                break;
            case 3: // high damage
                nextState = 4;
                newSprite = sprites.GetSprite("04");
                break;
            case 4: // destroy
                // nothing
                nextState = 5;
                newSprite = sprites.GetSprite("05");
                break;
        }
        currentState = nextState;
        SpriteRenderer render = damage_sprite.GetComponent<SpriteRenderer>();
        render.sprite = newSprite;

        if(currentState == 4)
        {
            //currentState = 0;
            //setSwimming();
            Down();
            startDamage = false;
            tempRecoveryTime = recoveryTime;
        }
    }

    public void Up()
    {
        currentState = 0;
        isDown = false;
        anim.SetBool("IsSwim", false);
        for (int i = 1; i < 5; i++)
        {
            bridge = gameObject.transform.GetChild(i).gameObject;
            bridge.SetActive(false);
        }
    }

    public void Down()
    {
        isDown = true;
        anim.SetBool("IsSwim", true);
        for (int i = 1; i < 5; i++)
        {
            bridge = gameObject.transform.GetChild(i).gameObject;
            bridge.SetActive(true);
        }
    }
}
