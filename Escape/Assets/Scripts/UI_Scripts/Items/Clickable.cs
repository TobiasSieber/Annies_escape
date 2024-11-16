using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class MouseHoverCheck : MonoBehaviour
{
    private Vector3 originalScale;
    bool sizeUp;
    public float scaleFactor = 1.2f;
    public GameObject imageHolder;
    public string description;
    public TextMeshProUGUI displaytext;
    void Start()
    {
        originalScale = transform.localScale;
       

    }
    
    

 
    void OnMouseOver()
    {
        if (!sizeUp)
        {
            Vector3 newScale = originalScale * scaleFactor;
            transform.localScale = newScale;
            sizeUp = true;
        }

     
    }

   

    void OnMouseExit()
    {
        transform.localScale = originalScale;
        sizeUp = false;
    }

    private void OnMouseDown()
    {
        if (gameObject.GetComponent<Image>().material.GetFloat("_GrayscaleAmount").Equals(0))
        {
            
            Image image = gameObject.GetComponent<Image>();
            imageHolder.GetComponent<Image>().sprite = image.sprite;
            displaytext.text = description;
        }
        
    }
    
   
}
