using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraOutput : MonoBehaviour
{
    WebCamTexture webCamTexture;
    WebCamDevice[] webCamDevice;
    [HideInInspector] public int camNumber = 0;
    public RawImage rawImage;
    // Start is called before the first frame update
    void Start ()
    {
        webCamTexture = new WebCamTexture (Screen.currentResolution.width, Screen.currentResolution.height, 30);
        webCamDevice = WebCamTexture.devices;
        rawImage.texture = webCamTexture;
        webCamTexture.Play ();
    }
    void Update ()
    {
    }
    public void CamChange ()
    {
        int cameras = webCamDevice.Length;
        if (cameras == 1) return;

        camNumber++;
        if (camNumber >= cameras) camNumber = 0;

        webCamTexture.Stop ();
        webCamTexture = new WebCamTexture (webCamDevice[camNumber].name, Screen.currentResolution.width, Screen.currentResolution.height, 30);
        rawImage.texture = webCamTexture;
        webCamTexture.Play ();
    }
}