using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePicture : MonoBehaviour
{
    [SerializeField] private Image picture;
    [SerializeField] private GameObject imageGameobject, uiNextGameObject, uiStartGameOcject;
    [SerializeField] private RectTransform rect;
    public void OnTakePicture()
    {
        TakePictureWithNativeCamera(2048);
    }

    private void TakePictureWithNativeCamera(int MAX_SIZE)
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            if (path != null)
            {
                Texture2D texture = NativeCamera.LoadImageAtPath(path, MAX_SIZE);
                if (texture == null)
                {
                    return;
                }
                //キャンセルされたら実行せず
                imageGameobject.SetActive(true);
                uiNextGameObject.SetActive(true);
                uiStartGameOcject.SetActive(false);
                //縦横画像対応
                //倍率の計算
                var asW = (Mathf.Ceil((1920f / texture.width) * 10)) / 10;
                var asH = (Mathf.Ceil((1080f / texture.height) * 10)) / 10;
                var asM = Mathf.Min(asH, asW);//でかい方に
                picture.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                rect.sizeDelta = new Vector2(texture.width * asM, texture.height * asM);
            }
        }, MAX_SIZE);
    }
}
