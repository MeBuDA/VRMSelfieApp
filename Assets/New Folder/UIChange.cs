using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChange : MonoBehaviour
{
    [SerializeField] private Sprite move;
    [SerializeField] private Sprite rotation;
    [SerializeField] private Sprite scale;
    [SerializeField] private Image image;
    private int changeNum=0;

    public void Change()
    {
        changeNum++;
        if (changeNum == 3)
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
            case 2:
                image.sprite = scale;
                break;
        }
    }
}
