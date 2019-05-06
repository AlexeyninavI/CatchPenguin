using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class About : UIScreen
{
    public void Show()
    {
        base.Show();
        Debug.Log("Show About");
    }

    public void OnCloseBtn()
    {
        Hide();
        UIHome.instance.ShowMenu();
    }
}
