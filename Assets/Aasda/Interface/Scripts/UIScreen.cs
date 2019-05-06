using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreenType
{
    None,
    StartMenu,
    Menu,
    Shop,
    About,
    Play,
    GameOver
}

public class UIScreen : MonoBehaviour
{
    public ScreenType type;

    public virtual void Show()
    {
        gameObject.SetActive(true);
        MoveScreenForward();
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    private void MoveScreenForward()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.SetAsLastSibling();
    }
}
