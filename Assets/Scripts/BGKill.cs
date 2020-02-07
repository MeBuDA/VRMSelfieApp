using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGKill : MonoBehaviour
{
    GameObject BG;
    // Start is called before the first frame update
    void Start ()
    {
        BG = GameObject.FindGameObjectWithTag ("BG");
    }
    public void BGKillButton ()
    {
        Destroy (BG);
    }
}