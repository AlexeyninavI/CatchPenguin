﻿using System.Collections;
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
        UIHome.instance.ShowMenu();
    }
    public void OnRestartBtn() {
        Hide();
        SceneManager.LoadScene("SampleScene");
<<<<<<< HEAD
=======
        UIHome.instance.ShowPlay();
>>>>>>> parent of c41ca43... наделал говна
    }
}
