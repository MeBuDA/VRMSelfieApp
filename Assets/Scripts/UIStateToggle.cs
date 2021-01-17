using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateToggle : MonoBehaviour
{
    public static void Toggle (GameObject item)
    {
        item.SetActive (!item.activeSelf);
    }
}