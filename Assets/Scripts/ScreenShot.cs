using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

namespace ScreenShotDate
{

    public class ScreenShot : MonoBehaviour
    {

        public Camera renderCam;
        public GameObject canvas;
        public GameObject canvas2;
        public Check.ImageCheck check;

        [HideInInspector]
        public static byte[] pngData;
        

        // UIを消したい場合はcanvasを非アクティブにする
        private void UIStateChange()
        {
            canvas.SetActive(!canvas.activeSelf);
            canvas2.SetActive(false);
        }

        private IEnumerator CreateScreenShot()
        {
            UIStateChange();
            //レンダリング完了まで待機
            yield return new WaitForEndOfFrame();

            RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
            renderCam.targetTexture = renderTexture;

            Texture2D texture = new Texture2D(renderCam.targetTexture.width, renderCam.targetTexture.height, TextureFormat.RGB24, false);

            texture.ReadPixels(new Rect(0, 0, renderCam.targetTexture.width, renderCam.targetTexture.height), 0, 0);
            texture.Apply();

            pngData = texture.EncodeToPNG();

            renderCam.targetTexture = null;

            Debug.Log("できた");
            UIStateChange();
            check.Imageload(pngData);
        }

        public void ClickShootButton()
        {
            StartCoroutine(CreateScreenShot());
        }
    }

}
