using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool sessionRunning;
    public bool isPaused;
    public bool playerIsDead;
    public bool isGameOver;
    public GameObject playerObject;
    private List<GameStateListener> mListeners = new List<GameStateListener>();

    void Awake()
    {
        // let's start find player
        playerObject = GameObject.FindGameObjectWithTag("PlayerSkin");
    }

    void Start()
    {
        StartGame();
    }

    public void RegisterListener(GameStateListener listener)
    {
        if (!mListeners.Contains(listener))
        {
            mListeners.Add(listener);
        }
    }

    public void UnregisterListener(GameStateListener listener)
    {
        if (mListeners.Contains(listener))
        {
            mListeners.Remove(listener);
        }
    }

    public void StartGame()
    {
        sessionRunning = true;
        ScoreController scontroller = FindObjectOfType<ScoreController>();
        scontroller.PlayGame();

        // call game state listeners
        foreach (GameStateListener listener in mListeners)
        {
            listener.OnGameStarted();
        }
    }

    public void StopGame()
    {
        sessionRunning = false;
        ScoreController scontroller = FindObjectOfType<ScoreController>();
        scontroller.StopGame();
        scontroller.Restart();

        // call game state listeners
        foreach (GameStateListener listener in mListeners)
        {
            listener.OnGameStopped();
        }
    }

    public void PauseGame(bool slowMotion)
    {
        if(!sessionRunning)
        {
            return;
        }

        if (!slowMotion)
        {
            Time.timeScale = 0.0f;
        }
        isPaused = true;
        ScoreController scontroller = FindObjectOfType<ScoreController>();
        scontroller.StopGame();

        // call game state listeners
        foreach (GameStateListener listener in mListeners)
        {
            listener.OnGamePaused();
        }
    }

    public void UnpauseGame(bool slowMotion)
    {
        if (!slowMotion)
        {
            Time.timeScale = 1.0f;
        }
        isPaused = false;
        ScoreController scontroller = FindObjectOfType<ScoreController>();
        scontroller.PlayGame();

        // call game state listeners
        foreach (GameStateListener listener in mListeners)
        {
            listener.OnGameUnpaused();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        ScoreController scontroller = FindObjectOfType<ScoreController>();
        scontroller.StopGame();

        // call game state listeners
        foreach (GameStateListener listener in mListeners)
        {
            listener.OnGameOver();
        }

        // show game over UI
        if (sessionRunning)
        {
            UIHome.instance.ShowGameOver();
        }
    }

    // Player events
    public void onPlayerDeath()
    {
        playerIsDead = true;
        if(playerObject != null)
        {
            playerObject.SetActive(false);
        }
    }

    private void Update()
    {
        // handle key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                PauseGame(false);
            } else
            {
                UnpauseGame(false);
            }
        }

        // handle pause
        if (isPaused)
        {
            if(Time.timeScale > 0.1f)
            {
                Time.timeScale -= 0.01f;
            } else if (Time.timeScale <= 0.1f)
            {
                Time.timeScale = 0.0f;
            }
        } else
        {
            if (Time.timeScale < 1.0f)
            {
                Time.timeScale += 0.05f;
            }
        }
    }
}
