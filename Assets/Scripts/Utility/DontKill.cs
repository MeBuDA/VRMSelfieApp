﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontKill : MonoBehaviour
{
    void Awake ()
    {
        DontDestroyOnLoad (this);
    }
}