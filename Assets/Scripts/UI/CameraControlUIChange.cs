using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControlUIChange : MonoBehaviour
{
    [SerializeField] private Sprite move;
    [SerializeField] private Sprite rotation;
    [SerializeField] private Image image;
    private int changeNum=0;

    public void Change()
    {
        changeNum++;
        if (changeNum == 2)
        {
            changeNum = 0;
        }
        switch (changeNum)
        {
            case 0:
                image.sprite = rotation;
                break;
            case 1:
                image.sprite = move;
                break;
        }
    }
}
