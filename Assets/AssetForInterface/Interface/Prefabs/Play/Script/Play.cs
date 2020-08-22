using UnityEngine;
using UnityEngine.UI;

public class Play : UIScreen, GameStateListener
{
    public GameObject pausePanel;
    public GameObject lowerBtnPanel;
    public GameObject pauseBtn;

    protected Canvas joystick;
    protected ScoreController sc;
    protected Text[] texts;

    void Awake() {
        Initialize();
        texts = GetComponentsInChildren<Text>();
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.RegisterListener(this);
        }
        //sc.PlayGame();
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
        Debug.Log("Pause!");
        GameManager gm = FindObjectOfType<GameManager>();
        gm.PauseGame(false);
    }

    public void OnExitBtn()
    {
        Debug.Log("Exit!");
        GameManager gm = FindObjectOfType<GameManager>();
        gm.UnpauseGame(true);
        gm.StopGame();
    }

    public void OnContinueBtn() {
        Debug.Log("OnContinueBtn");
        GameManager gm = FindObjectOfType<GameManager>();
        gm.UnpauseGame(false);
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

    public void OnGameStarted()
    {
        Debug.Log("OnGameStarted()");
    }

    public void OnGamePaused()
    {
        Debug.Log("OnGamePaused()");

        pausePanel.SetActive(true);
        lowerBtnPanel.SetActive(true);
        pauseBtn.SetActive(false);
        joystick.gameObject.SetActive(false);

        // set alpha
        Image background = GetComponent<Image>();
        var tempColor = background.color;
        tempColor.a = 0.4f;
        background.color = tempColor;

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

    public void OnGameUnpaused()
    {
        Debug.Log("OnGameUnpaused()");

        // set alpha
        Image background = GetComponent<Image>();
        var tempColor = background.color;
        tempColor.a = 0f;
        background.color = tempColor;

        GameManager gm = FindObjectOfType<GameManager>();
        if (!gm.isGameOver)
        {
            pausePanel.SetActive(false);
            lowerBtnPanel.SetActive(false);
            joystick.gameObject.SetActive(true);
            pauseBtn.SetActive(true);
        }
    }

    public void OnGameOver()
    {
        Debug.Log("OnGameOver()");
        joystick.gameObject.SetActive(false);
        Hide();
    }

    public void OnGameStopped()
    {
        Debug.Log("OnGameStopped()");

        pausePanel.SetActive(false);
        lowerBtnPanel.SetActive(false);
        joystick.gameObject.SetActive(false);
        pauseBtn.SetActive(false);
        sc.Restart();

        Hide();

        // find LevelChanger
        LevelChanger levelChanger = FindObjectOfType<LevelChanger>();
        levelChanger.FadeToLevel("MenuS");
    }
}
