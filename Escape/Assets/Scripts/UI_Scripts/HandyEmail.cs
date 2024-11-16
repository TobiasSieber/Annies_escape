using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandyEmail : MonoBehaviour
{
    public GameObject emailCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!emailCanvas.activeSelf)
        {
            emailCanvas.SetActive(true);
            GameObject parent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
            parent.SetActive(false);
        }
    }
}
