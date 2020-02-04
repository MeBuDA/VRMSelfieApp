using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRefresh : MonoBehaviour
{
    public void Refresh()
    {
        LoadImageStatic.SelectImage = null;
    }
}