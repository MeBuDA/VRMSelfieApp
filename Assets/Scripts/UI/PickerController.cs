using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kakera;
using UnityEngine.UI;

public class PickerController : MonoBehaviour
{
    [SerializeField] private Unimgpicker unimgpicker;//画像ファイルのパスが帰ってくるやつ
    [SerializeField] private Image Image;
    [SerializeField] private RectTransform rect;
    [SerializeField] private GameObject imageGameobject, uiNextGameObject, uiStartGameOcject;

    void Awake()
    {

        unimgpicker.Completed += (string path) =>
        {
            StartCoroutine(LoadImage(path, Image));
        };
    }
    private IEnumerator LoadImage(string path, Image output)
    {
        var url = "file://" + path;
        var www = new WWW(url);
        yield return www;

        var texture = www.texture;
        if (texture == null)
        {
            Debug.LogError("Failed to load texture url:" + url);
            yield break;
        }
        //キャンセルされたら実行せず
        imageGameobject.SetActive(true);
        uiNextGameObject.SetActive(true);
        uiStartGameOcject.SetActive(false);
        //縦横画像対応
        //倍率の計算
        var asW = (Mathf.Ceil((1920f / texture.width) * 10)) / 10;
        var asH = (Mathf.Ceil((1080f / texture.height) * 10)) / 10;
        var asM = Mathf.Max(asH, asW);//でかい方に合わせる
        output.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        rect.sizeDelta = new Vector2(texture.width * asM, texture.height * asM);
    }

    public void OnPressShowPicker()
    {
        unimgpicker.Show("Select Image", "unimgpicker", 2048);
    }
}
