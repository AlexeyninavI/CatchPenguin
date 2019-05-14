using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject characterPanel;
    public Character currentCharacter;
    public bool prevBtnActivity, nextBtnActivity;

    protected int currentIter = 0;

    protected DataManager dm;
    protected CharactersManager cm;

    void Awake()
    {
        dm = FindObjectOfType<DataManager>();
        cm = FindObjectOfType<CharactersManager>();
        if (dm == null && cm == null)
            Debug.Log("DataManager or CharactersManager is null!");
        currentIter = 0;
        currentCharacter = new Character();
        currentCharacter = cm.GetCharacter(currentIter);
        if (currentCharacter == null)
            Debug.Log("currentCharacter is null!");
        prevBtnActivity = false;
        nextBtnActivity = true;
    }
    public ValueChooseCharacterBtn ValueChooseCharacterBtn()
    {
        switch (currentCharacter.state)
        {
            case CharacterState.Selected:
                {
                    return global::ValueChooseCharacterBtn.Selected;
                }
            case CharacterState.Bought:
                {
                    return global::ValueChooseCharacterBtn.Select;
                }
            case CharacterState.Sale:
                {
                    if (dm.fish >= currentCharacter.price)
                        return global::ValueChooseCharacterBtn.Buy;
                    else return global::ValueChooseCharacterBtn.NotAvailable;
                }
        }
        return global::ValueChooseCharacterBtn.None;
    }
    public void SelectCharacter()
    {
        cm.SelectCharacter(currentIter);
    }
    public void BuyCharacter()
    {
        if(dm.fish < currentCharacter.price)
        {
            Debug.Log("Need more fish!");
            return;
        }
        dm.fish -= currentCharacter.price;
        cm.BuyCharacter(currentIter);
    }
    public void NextCharacter()
    {
        currentIter++;
        if(currentIter == cm.CountCharacters())
        {
            nextBtnActivity = false;
        }
        prevBtnActivity = true;
        HideCharacter();
        currentCharacter = cm.GetCharacter(currentIter);
        ShowCharacter();
    }
    public void PrevCharacter()
    {
        currentIter--;
        if (currentIter == 0)
        {
            prevBtnActivity = false;
        }
        nextBtnActivity = true;
        HideCharacter();
        currentCharacter = cm.GetCharacter(currentIter);
        ShowCharacter();
    }
    public void ShowCharacter()
    {
        if (currentCharacter == null)
            Debug.Log("currentCharacter is null!");
        if (characterPanel == null)
            Debug.Log("characterPanel is null!");


        //currentCharacter.gameObject.transform. = characterPanel.transform.localToWorldMatrix;
        //characterPanel.transform.localScale;
        //currentCharacter.gameObject.transform.localScale = Vector3.
        currentCharacter.gameObject.transform.position = characterPanel.transform.position;
        currentCharacter.Show();
    }
    public void HideCharacter()
    {
        currentCharacter.Hide();
    }
}

public enum ValueChooseCharacterBtn {
    Select,
    Selected,
    Buy,
    NotAvailable,
    None
}

