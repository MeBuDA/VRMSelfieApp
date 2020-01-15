using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledAndDontdestroy : MonoBehaviour
{
    [SerializeField] private GameObject image;
    void Start()
    {
        DontDestroyOnLoad(image);
    }
    public void OnNext()
    {
        image.GetComponent<DragImage>().enabled = false;
    }
}
