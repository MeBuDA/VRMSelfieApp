using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueOpen : MonoBehaviour
{
    [SerializeField] GameObject Board;

    public void Open()
    {
        Board.SetActive(true);
    }
}
