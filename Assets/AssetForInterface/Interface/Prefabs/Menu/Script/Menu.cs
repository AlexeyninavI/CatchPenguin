using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : UIScreen
{
    public GameObject LanguagePanel;

    protected DataManager dm;
    protected CharactersManager cm;
    Character placeholder;

    public override void Show()
    {
        base.Show();
        LanguagePanel.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Play animation cursor!");
        Initialize();

        Text[] texts = GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            if (text.name == "TapScreenPanelRecordText")
                text.text = "" + dm.record;
        }

        if(dm.language == "rus")
        {
            ChangeRusLanguage();
        }
        if(dm.language == "eng")
        {
            ChangeEngLanguage();
        }
        
    }
    public override void Hide()
    {
        base.Hide();
        HidePlaceholder();
    }

    public void OnLanguageBtn() {
        LanguagePanel.SetActive(!LanguagePanel.activeSelf);
    }

    public void OnRusBtn()
    {
        dm.language = "rus";
        ChangeRusLanguage();
    }
    public void OnEngBtn() {
        dm.language = "eng";
        ChangeEngLanguage();
    }
    public void OnArrowDownBtn() {
        LanguagePanel.SetActive(!LanguagePanel.activeSelf);
    }
        
    public void OnShopBtn()
    {
        UIHome.instance.ShowShop();
        Debug.Log("Show shop!");
    }

    public void OnAboutBtn()
    {
        UIHome.instance.ShowAbout();
        Debug.Log("Show about!");
    }
    public void TapOnScreenPanel() {
        //SceneManager.LoadSceneAsync("SampleScene");
        SceneManager.LoadSceneAsync("E3_2019_preview", LoadSceneMode.Single);
        Debug.Log("Game start!");
    }
    public void Initialize()
    {
        dm = FindObjectOfType<DataManager>();
        if (dm == null)
            Debug.Log("DataManager not found!");
        cm = FindObjectOfType<CharactersManager>();
        if (cm == null)
            Debug.Log("CharacterManager not found!");
    }
    public void ShowPlaceholder()
    {
        placeholder = cm.PlayableCharacter();
        RectTransform[] placeholderPanels = GetComponentsInChildren<RectTransform>();
        Debug.Log("placeholder " + placeholder);
        Debug.Log("placeholder panel " + placeholderPanels);
        foreach(RectTransform placeholderPanel in placeholderPanels)
        {
            Debug.Log(placeholderPanel.name);
            if(placeholderPanel.name == "Placeholder")
            {
                placeholder.gameObject.transform.localScale = Vector3.one * 0.06f;
                placeholder.gameObject.transform.position = placeholderPanel.transform.position;
                placeholder.gameObject.SetActive(true);
                break;
            }
        }
       
    }
    public void HidePlaceholder()
    {
        Debug.Log("Destroy placeHolder! " + placeholder);
        //Destroy(placeholder.gameObject);
    }
    public void ChangeRusLanguage()
    {
        Debug.Log("Changed rus language");
        Text[] texts = GetComponentsInChildren<Text>();

        foreach (Text text in texts)
        {
            if (text.name == "TitlePanelBannerText") {
                text.text = "здесь могла бы быть ваша реклама"; continue;
            }
            if (text.name == "TapScreenPanelTitleRecordText") { 
                text.text = "рекорд"; continue;
            }
            if (text.name == "TapScreenPanelText") { 
                text.text = "нажмите на экран, чтобы начать играть"; continue;
            }
            if (text.name == "LanguageBtnText") { 
                text.text = "язык"; continue;
            }
            if (text.name == "ShopBtnText") { 
                text.text = "магазин"; continue;
            }
            if (text.name == "AboutBtnText") { 
                text.text = "информация"; continue;
            }  
        }
    }
    public void ChangeEngLanguage()
    {
        Debug.Log("Changed eng language");
        Text[] texts = GetComponentsInChildren<Text>();

        foreach (Text text in texts)
        {
            if (text.name == "TitlePanelBannerText") {
                text.text = "your advertisement could be here"; continue;
            }
            if (text.name == "TapScreenPanelTitleRecordText") { 
                text.text = "record"; continue;
            }
            if (text.name == "TapScreenPanelText") { 
                text.text = "tap the screen to start play"; continue;
            }
            if (text.name == "LanguageBtnText") { 
                text.text = "language"; continue;
            }
            if (text.name == "ShopBtnText") { 
                text.text = "shop"; continue;
            }
            if (text.name == "AboutBtnText") { 
                text.text = "about"; continue;
            }  
        }
    }
}
