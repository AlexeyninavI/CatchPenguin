using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : UIScreen
{
    public Button arrowLeftBtn;
    public Button arrowRightBtn;
    protected ShopManager sm;
    public override void Show()
    {
        base.Show();
        Debug.Log("This is shop");
        sm = FindObjectOfType<ShopManager>();
        if (sm == null)
            Debug.Log("ShopManager is null!");
        sm.Initialize();
        sm.ShowCharacter();

        //Button[] btns = GetComponentsInChildren<Button>(); // Делаю невидимой левую стрелку
        //foreach (Button btn in btns)
        //{
        //    if (btn.name == "ArrowLeftBtn")
        //        btn.gameObject.SetActive(false);
        //}

        arrowLeftBtn.gameObject.SetActive(sm.prevBtnActivity);
        arrowRightBtn.gameObject.SetActive(sm.nextBtnActivity);

        Text[] texts = GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            if (text.name == "TitleText")
            {
                DataManager dm = FindObjectOfType<DataManager>();
                if (dm.language == "rus")
                {
                    text.text = "магазин";
                    break;
                }
                if (dm.language == "eng")
                {
                    text.text = "shop";
                    break;
                }
            }
        }

        UpdateInfoAboutCurrentCharacter();
    }

    public void OnBackBtn()
    {
        DataManager dm = FindObjectOfType<DataManager>();
        if (dm == null)
            Debug.Log("dm is null");
        dm.Save();
        sm.HideCharacter();
        Hide();
        UIHome.instance.ShowMenu();
    }
    public void OnChooseCharacterBtn()
    {
        switch (sm.ValueChooseCharacterBtn())
        {
            case ValueChooseCharacterBtn.Buy:
                {
                    sm.BuyCharacter();
                    break;
                }
            case ValueChooseCharacterBtn.Select:
                {
                    sm.SelectCharacter();
                    break;
                }
        }

        // Нужно, чтобы обновить данные о персонаже
        sm.HideCharacter();
        sm.ShowCharacter();

        UpdateInfoAboutCurrentCharacter();
    }
    public void OnArrowLeftBtn()
    {
        sm.PrevCharacter();

        arrowLeftBtn.gameObject.SetActive(sm.prevBtnActivity);
        arrowRightBtn.gameObject.SetActive(sm.nextBtnActivity);

        UpdateInfoAboutCurrentCharacter();
    }
    public void OnArrowRightBtn()
    {
        sm.NextCharacter();

        arrowLeftBtn.gameObject.SetActive(sm.prevBtnActivity);
        arrowRightBtn.gameObject.SetActive(sm.nextBtnActivity);

        UpdateInfoAboutCurrentCharacter();
    }
    public void UpdateInfoAboutCurrentCharacter()
    {
        DataManager dm = FindObjectOfType<DataManager>();
        Text[] texts = GetComponentsInChildren<Text>();
        Text chooseCharacterText = null;
        Text nameCharacterText = null;
        Text countFishText = null;

        foreach (Text text in texts)
        {
            if (text.name == "NameCharacterText")
            {
                nameCharacterText = text;
                continue;
            }
            if (text.name == "ChooseCharacterText")
            {
                chooseCharacterText = text;
                continue;
            }
            if (text.name == "CountFishText")
            {
                countFishText = text;
                continue;
            }
        }

        Button[] btns = GetComponentsInChildren<Button>();
        Button chooseCharacterBtn = null;
        foreach (Button btn in btns)
        {
            if (btn.name == "ChooseCharacterBtn")
            {
                chooseCharacterBtn = btn;
            }
        }

        nameCharacterText.text = sm.currentCharacter.name;
        countFishText.text = "" + dm.fish;

        switch (sm.ValueChooseCharacterBtn())
        {
            case ValueChooseCharacterBtn.Buy:
                {
                    if (dm.language == "rus")
                    {
                        chooseCharacterText.text = "купить " + sm.currentCharacter.price;
                    }
                    if (dm.language == "eng")
                    {
                        chooseCharacterText.text = "buy " + sm.currentCharacter.price;
                    }
                    chooseCharacterBtn.interactable = true;
                    break;
                }
            case ValueChooseCharacterBtn.NotAvailable:
                {
                    if (dm.language == "rus")
                    {
                        chooseCharacterText.text = "купить " + sm.currentCharacter.price;
                    }
                    if (dm.language == "eng")
                    {
                        chooseCharacterText.text = "buy " + sm.currentCharacter.price;
                    }

                    chooseCharacterBtn.interactable = false;
                    break;
                }
            case ValueChooseCharacterBtn.Select:
                {
                    if (dm.language == "rus")
                    {
                        chooseCharacterText.text = "выбрать";
                    }
                    if (dm.language == "eng")
                    {
                        chooseCharacterText.text = "select";
                    }
                    chooseCharacterBtn.interactable = true;
                    break;
                }
            case ValueChooseCharacterBtn.Selected:
                {
                    if (dm.language == "rus")
                    {
                        chooseCharacterText.text = "выбран";
                    }
                    if (dm.language == "eng")
                    {
                        chooseCharacterText.text = "selected";
                    }
                    chooseCharacterBtn.interactable = false;
                    break;
                }
        }
    }
}
