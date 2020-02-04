using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStart : MonoBehaviour
{
    void Start ()
    {
        if (SceneManager.GetActiveScene ().name == "Load")
        {
            SceneManager.LoadScene ("Start");
            Resources.UnloadUnusedAssets ();
            System.GC.Collect ();
        }
    }
}