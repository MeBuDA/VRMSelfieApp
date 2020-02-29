using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueClose : MonoBehaviour
{
    [SerializeField] GameObject Board;

    public void Close()
    {
        Board.SetActive(false);
    }
}
