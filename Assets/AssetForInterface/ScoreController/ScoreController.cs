using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    protected DataManager dm;
    protected float scoreUpLimit = 0.1f;
    public float ScoreUpLimit
    {
        get
        {
            return scoreUpLimit;
        }
        set
        {
            if (value < 0)
            {
                Debug.Log("Speed chenge scale can't be negative number! ScaleSpeed = 0.1");
                scoreUpLimit = 0.1f;
            }
            else scoreUpLimit = value;
        }
    }
    protected float timeLastScaleUpdate = 0f;

    protected uint score = 0;
    protected uint record = 0;
    protected uint reward = 0;

    private bool pauseGame = true;

    public uint Score { get { return score; } }
    public uint Record { get { return record; } }
    public uint Reward { get { return reward; } }

    public void Initialize()
    {
        dm = FindObjectOfType<DataManager>();
        Debug.Log(dm);
        score = 0;
        record = dm.record;
        reward = 0;
        pauseGame = true;
    }
    public void PlayGame()
    {
        pauseGame = false;
    }
    public void StopGame()
    {
        pauseGame = true;
    }
    protected void ScaleUp()
    {
        score++;
        if (score > record)
            record = score;
    }
    public void Restart()
    {
        score = 0;
        record = dm.record;
        reward = 0;
        pauseGame = true;
    }
    public void RewardUp()
    {
        reward++;
    }
    public void RewardUp(uint count)
    {
        reward += count;
    }
    public void GameOver()
    {
        dm.fish += reward;
        if (record >= dm.record)
            dm.record = record;
        Restart();
        dm.Save();
    }
    void Awake()
    {
        Debug.Log("ScoreController.Awake()");
    }

    void Update()
    {
        timeLastScaleUpdate += Time.deltaTime;
        if (!pauseGame && (timeLastScaleUpdate > ScoreUpLimit))
        {
            ScaleUp();
            //Debug.Log(Time.deltaTime);
            timeLastScaleUpdate = 0f;
        }
    }
}
