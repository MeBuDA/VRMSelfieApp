using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGrand : MonoBehaviour
{
    private byte[] pngData;
    public RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
        pngData = ScreenShotDate.ScreenShot.pngData;
        Texture2D tex = new Texture2D(0, 0);
        tex.LoadImage(pngData);
        rawImage.texture = tex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
