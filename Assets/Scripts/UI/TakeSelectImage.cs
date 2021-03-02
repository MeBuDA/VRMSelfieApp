using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeSelectImage : MonoBehaviour
{
    [SerializeField] Image sprite;
    [SerializeField] RectTransform rect;

    public void SetImage ()
    {
        LoadImageStatic.SelectImage = sprite.sprite;
        LoadImageStatic.RectTransformY = rect.localPosition.y;
        LoadImageStatic.size = rect.sizeDelta;
    }
}