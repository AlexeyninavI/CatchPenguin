using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Play : UIScreen
{
    public GameObject pausePanel;
    public GameObject lowerBtnPanel;
    public GameObject pauseBtn;

    protected Canvas joystick;
    protected ScoreController sc;
    protected Text[] texts;
    void Start() {
        Initialize();
        texts = GetComponentsInChildren<Text>();
        sc.PlayGame();
    }

    void Update() {
        foreach (Text text in texts)
        {
            if (text.name == "ScoreText")
            {
                text.text = "" + sc.Score;
                continue;
            }
            if (text.name == "RecordText")
                text.text = "" + sc.Record;
            if (text.name == "FishText")
                text.text = "" + sc.Reward;
        } 
    }

    void Initialize()
    {
        Time.timeScale = 1;
        sc = FindObjectOfType<ScoreController>();
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            if (canvas.gameObject.name == "JoystickCanvas")
            {
                Debug.Log("CANVASFINDED");
                joystick = canvas;
                joystick.gameObject.SetActive(false);
                joystick.gameObject.SetActive(true);
                //RectTransform joystickRect = joystick.GetComponent<RectTransform>();
                //joystickRect.SetAsLastSibling();
            }
        }
        
    }

    public void OnPauseBtn()
    {
        pausePanel.SetActive(true);
        lowerBtnPanel.SetActive(true);

        pauseBtn.SetActive(false);

     
        joystick.gameObject.SetActive(false);
        Time.timeScale = 0;
        sc.StopGame();

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

        Debug.Log("Pause!");
    }
    public void OnExitBtn() {
        pausePanel.SetActive(false);
        lowerBtnPanel.SetActive(false);

        pauseBtn.SetActive(true);
        
        sc.Restart();
        SceneManager.LoadScene("MenuS");
    }
    public void OnContinueBtn() {
        Debug.Log("OnContinueBtn");
        pausePanel.SetActive(false);
        lowerBtnPanel.SetActive(false);

        joystick.gameObject.SetActive(true);

        pauseBtn.SetActive(true);
        Time.timeScale = 1;
        sc.PlayGame();
    }
    public override void Show()
    {
        base.Show();
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

        foreach (Text text in texts) {
            if (text.name == "ScoreTitleText") {
                text.text = "счет"; continue;
            }
            if (text.name == "RecordTitleText") {
                text.text = "рекорд"; continue;
            }
            if (text.name == "PauseText") {
                text.text = "пауза"; continue;
            }
            if (text.name == "ExitText") {
                text.text = "выход"; continue;
            }
            if (text.name == "ContinueText") {
                text.text = "продолжить"; continue;
            }
        }
    }
    public void ChangeEngLanguage()
    {
        Debug.Log("Changed rus language");
        Text[] texts = GetComponentsInChildren<Text>();

        foreach (Text text in texts)
        {
            if (text.name == "ScoreTitleText")
            {
                text.text = "score"; continue;
            }
            if (text.name == "RecordTitleText")
            {
                text.text = "record"; continue;
            }
            if (text.name == "PauseText")
            {
                text.text = "pause"; continue;
            }
            if (text.name == "ExitText")
            {
                text.text = "exit"; continue;
            }
            if (text.name == "ContinueText")
            {
                text.text = "continue"; continue;
            }
        }
    }
}
