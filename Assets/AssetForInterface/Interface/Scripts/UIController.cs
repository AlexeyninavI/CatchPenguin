using System.Collections.Generic;
using UnityEngine;

public abstract class UIController : MonoBehaviour
{
    public UIScreen[] screenPrefs;
    public UIScreen defaultScreenPref;

    protected List<UIScreen> screensPool;

    protected virtual void Awake()
    {
        CreateSingleton();
        Initialize();
    }

    protected abstract void CreateSingleton();

    protected virtual void Initialize()
    {
        screensPool = new List<UIScreen>();
        foreach (UIScreen screenPref in screenPrefs)
        {
            UIScreen createdScreen = CreateScreen(screenPref);
            createdScreen.Hide();
            screensPool.Add(createdScreen);
        }
        UIScreen defScreen = CreateScreen(defaultScreenPref);
        defScreen.Show();
        screensPool.Add(defScreen);
    }

    protected UIScreen CreateScreen(UIScreen pref)
    {
        return Instantiate(pref, transform);
    }

    protected UIScreen GetScreenOfType(ScreenType type)
    {
        foreach (UIScreen screen in screensPool)
        {
            if (screen.type == type)
                return screen;
        }
        throw new System.Exception("There is no screen type: " + type);
    }
}
