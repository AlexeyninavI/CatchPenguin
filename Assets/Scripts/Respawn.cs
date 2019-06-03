using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private CharactersManager cm;
    // Start is called before the first frame update

    public void SpawnCharacter()
    {
        cm = FindObjectOfType<CharactersManager>();
        Debug.Log(cm);
        Character chr = Instantiate(cm.PlayableCharacter(), transform);
        chr.gameObject.SetActive(true);
    }
}
