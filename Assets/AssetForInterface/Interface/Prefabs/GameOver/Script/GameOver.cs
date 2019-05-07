using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : UIScreen
{
    protected Canvas joystick;
    void Start() {
        Initialize();
    }
    void Update() { }
    void Initialize()
    {
       // Time.timeScale = 1;
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            if (canvas.gameObject.name == "JoystickCanvas")
            {
                
                Debug.Log("CANVASFINDED");
                joystick = canvas;
            }
        }
    }
    public void OnExitBtn() {
        Hide();
        SceneManager.LoadScene("mENU");
    }
    public void OnRestartBtn() {
        Hide();
        SceneManager.LoadScene("SampleScene");
    }
}
