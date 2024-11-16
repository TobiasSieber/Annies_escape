using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class greyscale : MonoBehaviour
{
    // Start is called before the first frame update
    private Image image;
    private Material material;
    private String description_text;
    void Awake()
    {
        image = GetComponent<Image>();
        material = new Material(image.material);
        image.material = material;
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GreyImage()
    {
        image.material.SetFloat("_GrayscaleAmount",1);
    }


}
