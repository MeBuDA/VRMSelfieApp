using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Check
{
    public class ImageCheck : MonoBehaviour
    {
        public RawImage rawImage;
        public GameObject canvas;
        public string nextScene;

        public void Imageload(byte[] image)
        {
            Debug.Log("test");
            UIStateChange();
            Texture2D tex = new Texture2D(0, 0);
            tex.LoadImage(image);
            rawImage.texture = tex;
        }

        public void sceneTransition()
        {
            SceneManager.LoadScene(nextScene);
        }

        public void RetakeImage()
        {
            rawImage.texture = null;
            UIStateChange();
        }

        private void UIStateChange()
        {
            canvas.SetActive(!canvas.activeSelf);
        }
    }
}
