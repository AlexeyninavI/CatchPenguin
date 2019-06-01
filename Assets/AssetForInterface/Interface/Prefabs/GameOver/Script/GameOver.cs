using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : UIScreen
{
    protected Canvas joystick;
    void Start() {
        Initialize();
    }
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
        ScoreController sc = FindObjectOfType<ScoreController>();
        sc.GameOver();

        Hide();
        SceneManager.LoadScene("mENU");
    }
    public void OnRestartBtn() {
        ScoreController sc = FindObjectOfType<ScoreController>();
        sc.GameOver();

        Hide();
        SceneManager.LoadScene("SampleScene");
    }
    public override void Show()
    {
        base.Show();

        ScoreController sc = FindObjectOfType<ScoreController>();
        Debug.Log("sc" + sc);
        Text[] texts = GetComponentsInChildren<Text>();
        foreach (Text text in texts) {
            if(text.name == "ScoreText") {
                text.text = "" + sc.Score;
                continue;
            }
            if (text.name == "RecordText") {
                text.text = "" + sc.Record;
                continue;
            }
            if (text.name == "RewardText") {
                text.text = "" + ((sc.Reward != 0)?sc.Reward:0);
                continue;
            }
        }

        DataManager dm = FindObjectOfType<DataManager>();
        if (dm.language == "rus")
        {
            ChangeRusLanguage();
            return;
        }
        if (dm.language == "eng")
        {
            ChangeEngLanguage();
            return;
        }
    }
    public void ChangeRusLanguage()
    {
        Debug.Log("Changed rus language");
        Text[] texts = GetComponentsInChildren<Text>();

        foreach (Text text in texts)
        {
            if (text.name == "GameOverText") {
                text.text = "игра окончена"; continue;
            }
            if (text.name == "RecordTitleText") { 
                text.text = "рекорд"; continue;
            }
            if (text.name == "ScoreTitleText") { 
                text.text = "счет"; continue;
            }
            if (text.name == "RewardTitleText") { 
                text.text = "награда"; continue;
            }
            if (text.name == "ExitText") { 
                text.text = "выход"; continue;
            }
            if (text.name == "RestartText") { 
                text.text = "повторить"; continue;
            }  
        }
    }
    public void ChangeEngLanguage()
    {
        Debug.Log("Changed eng language");
        Text[] texts = GetComponentsInChildren<Text>();

        foreach (Text text in texts)
        {
            if (text.name == "GameOverText") {
                text.text = "game over"; continue;
            }
            if (text.name == "RecordTitleText") { 
                text.text = "record"; continue;
            }
            if (text.name == "ScoreTitleText") { 
                text.text = "score"; continue;
            }
            if (text.name == "RewardTitleText") { 
                text.text = "reward"; continue;
            }
            if (text.name == "ExitText") { 
                text.text = "exit"; continue;
            }
            if (text.name == "RestartText") { 
                text.text = "restart"; continue;
            }  
        }
    }
}
