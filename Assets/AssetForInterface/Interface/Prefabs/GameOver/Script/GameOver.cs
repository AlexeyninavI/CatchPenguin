using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : UIScreen
{
    
    void Start() { }
    void Update() { }
    public void OnExitBtn() {
        Hide();
        UIHome.instance.ShowMenu();
    }
    public void OnRestartBtn() {
        Hide();
        UIHome.instance.ShowPlay();
    }
}
