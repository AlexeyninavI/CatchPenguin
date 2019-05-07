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
            {;
                Debug.Log("CANVASFINDED");
                joystick = canvas;
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

        Debug.Log("Pause!");
    }
    public void OnExitBtn() {
        pausePanel.SetActive(false);
        lowerBtnPanel.SetActive(false);

        pauseBtn.SetActive(true);
        
        sc.Restart();
        SceneManager.LoadScene("mENU");
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
}
