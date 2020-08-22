
using UnityEngine;

public class CameraFollow : MonoBehaviour, GameStateListener
{
    public Transform target;
    public Vector3 target_Offset;

    public void OnGameOver()
    {
        GameObject resp = GameObject.Find("RespManager");
        target = resp.transform;
        //target_Offset = transform.position - target.position;
        target_Offset = new Vector3(-0.5f, 25, -18);
    }

    public void OnGamePaused()
    {
    }

    public void OnGameStarted()
    {
        target = GameObject.FindGameObjectWithTag("PlayerSkin").transform;
        //target_Offset = transform.position - target.position;
    }

    public void OnGameStopped()
    {
    }

    public void OnGameUnpaused()
    {
    }

    // Start is called before the first frame update
    void Awake()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        gm.RegisterListener(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + target_Offset, 0.1f);
        }
    }
}
