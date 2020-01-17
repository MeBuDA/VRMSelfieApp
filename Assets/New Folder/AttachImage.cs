using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachImage : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private RectTransform rect;

    void Start()
    {
        image.sprite = LoadImageStatic.SelectImage;
        rect.localPosition = new Vector3(0,LoadImageStatic.RectTransformY,0); 
        rect.sizeDelta = LoadImageStatic.size;
    }

}
