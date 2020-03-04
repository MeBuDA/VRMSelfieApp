using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    public void Shot ()
    {
        StartCoroutine ("ShotandSave");
    }
    IEnumerator ShotandSave ()
    {

        UIStateChange.Toggle (canvas);
        yield return new WaitForEndOfFrame ();

        Texture2D ss = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply ();

        // Save the screenshot to Gallery/Photos
        NativeGallery.SaveImageToGallery (ss, "GalleryTest", "Image.png");

        // To avoid memory leaks
        Destroy (ss);
        UIStateChange.Toggle (canvas);
    }
}