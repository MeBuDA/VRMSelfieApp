using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveImage : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject returnButton;
    public void saveImage ()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive (false);
            returnButton.SetActive (true);
        }
    }
    public void ReturnScene ()
    {
        SceneManager.LoadScene ("Camera");
    }
}