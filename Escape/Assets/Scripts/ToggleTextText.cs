using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTextText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TextCanvas;
    public GameObject AnswerCanvas;
    GameObject Handy;

    void Awake()
    {
        Handy = GameObject.FindGameObjectWithTag("Smartphone");
        Handy.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisableTextObjects()
    {
        TextCanvas.gameObject.SetActive(false);
        AnswerCanvas.gameObject.SetActive(false);

    }

   
    private void OnMouseDown()
    {
        if (!Handy.activeSelf && AnswerCanvas.activeSelf)
        {
           
            DisableTextObjects();
            Handy.gameObject.SetActive(true);
            
        }

    }
}