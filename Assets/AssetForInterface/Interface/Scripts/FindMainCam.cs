using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindMainCam : MonoBehaviour
{
    public Canvas canvas;
    void Awake()
    {
        canvas.worldCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
