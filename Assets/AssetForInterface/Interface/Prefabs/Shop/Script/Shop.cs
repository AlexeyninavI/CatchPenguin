using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : UIScreen
{
    protected ShopManager sm;
    public override void Show()
    {
        base.Show();
        Debug.Log("This is shop");
        sm = FindObjectOfType<ShopManager>();
        if (sm == null)
            Debug.Log("ShopManager is null!");
        sm.ShowCharacter();
    }

    public void OnBackBtn()
    {
        DataManager dm = FindObjectOfType<DataManager>();
        if (dm == null)
            Debug.Log("dm is null");
        dm.Save();
        Hide();
        UIHome.instance.ShowMenu();
    }
    public void OnChooseCharacterBtn()
    {

    }
    public void OnArrowLeftBtn()
    {
        sm.PrevCharacter();
        if (sm.prevBtnActivity)
        {
            Button[] btns = GetComponentsInChildren<Button>();
            foreach (Button btn in btns)
            {
                if (btn.name == "ArrowLeftBtn")
                    btn.gameObject.SetActive(sm.prevBtnActivity);
            }
        }
    }
    public void OnArrowRightBtn()
    {
        sm.NextCharacter();
        if (sm.nextBtnActivity)
        {
            Button[] btns = GetComponentsInChildren<Button>();
            foreach (Button btn in btns)
            {
                if (btn.name == "ArrowRightBtn")
                    btn.gameObject.SetActive(sm.nextBtnActivity);
            }
        }
    }
}
