using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public Character[] charactersPrefs;
    protected List<Character> characters;

    protected DataManager dm;

    public void Initialize()
    {
        characters = new List<Character>();
        foreach (Character characterPref in charactersPrefs)
        {
            Character createdCharacter = Instantiate(characterPref, transform);
            createdCharacter.Hide();
            characters.Add(createdCharacter);
        }
    }

    public void InitializeCharactersFromDataManager()
    {
        dm = FindObjectOfType<DataManager>();
        if (dm == null)
            Debug.Log("dm is null!");
        CharacterInfo[] charactersFromDataManager = dm.GetCharacters();
        for(int i = 0; i < charactersFromDataManager.Length; i++)
        {
            for(int j = 0; j < characters.Count; j++)
            {
                if(characters[j].name == charactersFromDataManager[i].name)
                {
                    characters[j].price = charactersFromDataManager[i].price;
                    characters[j].state = charactersFromDataManager[i].state;
                    break;
                }
            }          
        }
    }

    public Character GetCharacter(int i)
    {
        if(i > characters.Count && i < 0)
        {
            Debug.Log("Error! Out of the range!");
            //return new Character();
            return null;
        }
        //return new Character(characters[i]);
        return characters[i];
    }
    public List<Character> GetListCharacters()
    {
        return new List<Character>(characters);
    }

    public void SelectCharacter(int i)
    {
        if (characters[i].state == CharacterState.Selected)
        {
            Debug.Log("Character already selected!");
            return;
        }
        foreach (Character character in characters)
        {
            if (character.state == CharacterState.Selected)
            {
                character.state = CharacterState.Bought;
                break;
            }
        }
        if(characters[i].state == CharacterState.Sale)
        {
            Debug.Log("Begin need buy character!");
            return;
        }
        characters[i].state = CharacterState.Selected;
    }
    public void BuyCharacter(int i)
    {
        if(characters[i].state == CharacterState.Bought || characters[i].state == CharacterState.Selected)
        {
            Debug.Log("Character already bought!");
            return;
        }
        characters[i].state = CharacterState.Bought;
    }
    public int CountCharacters()
    {
        return characters.Count;
    }
    void Awake()
    {
        Initialize();
    }
    void Start()
    {
        InitializeCharactersFromDataManager();
    }
    
}
