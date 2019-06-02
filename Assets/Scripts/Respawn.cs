using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private CharactersManager cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<CharactersManager>();
        Instantiate(cm.PlayableCharacter(),transform);
    }

    
}
