using System;
using UnityEngine;

public class UIHome : UIController
{
    public static UIHome instance { get; private set; }

    protected override void CreateSingleton()
    {
        instance = this;
    }

    public void ShowShop()
    {
        UIScreen menu = GetScreenOfType(ScreenType.Menu);
        menu.Hide();
        UIScreen shop = GetScreenOfType(ScreenType.Shop);
        shop.Show();
    }
    public void ShowMenu()
    {
        UIScreen menu = GetScreenOfType(ScreenType.Menu);
        menu.Show();
    }
    public void ShowAbout()
    {
        UIScreen menu = GetScreenOfType(ScreenType.Menu);
        menu.Hide();
        UIScreen about = GetScreenOfType(ScreenType.About);
        about.Show();
    }
    public void ShowPlay()
    {
        UIScreen menu = GetScreenOfType(ScreenType.Menu);
        menu.Hide();
        UIScreen play = GetScreenOfType(ScreenType.Play);
        play.Show();
    }
    public void ShowGameOver()
    {
        UIScreen play = GetScreenOfType(ScreenType.Play);
        play.Hide();
        UIScreen gameOver = GetScreenOfType(ScreenType.GameOver);
        gameOver.Show();
    }
}
