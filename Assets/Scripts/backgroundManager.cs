using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundManager : MonoBehaviour
{

    public Texture2D backgroundImage;

    void Start()
    {
        /*
        // Old code that displays a blury background image
        GameObject backgroundGameObject = new GameObject("Background");
        SpriteRenderer backgroungSpriteRender = backgroundGameObject.AddComponent<SpriteRenderer>();
        backgroungSpriteRender.sprite = backgroundImage;
        */

        Color MyPixel = backgroundImage.GetPixel(0,0);
        Debug.Log(MyPixel);
    }

    void Update()
    {
        
    }
}
