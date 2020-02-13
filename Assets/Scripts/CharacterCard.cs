using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRM;

public class CharacterCard : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text version;
    [SerializeField] private Image violence;
    [SerializeField] private Image sexual;
    [SerializeField] private Image commercial;
    [SerializeField] private RawImage thumbnail;
    [SerializeField] private Sprite maru,batu; 
    private string path;

    public void SetMetaText (VRMMetaObject meta)
    {
        title.text = meta.Title;
        version.text = meta.Version;
        violence.sprite = isLicence(meta.ViolentUssage);
        sexual.sprite = isLicence(meta.SexualUssage);
        commercial.sprite = isLicence(meta.CommercialUssage);
    }

    public void SetThumbnail (Texture2D tex)
    {
        thumbnail.texture = tex;
    }
    public void SetPath (string vrm)
    {
        path = vrm;
    }

    private Sprite isLicence(UssageLicense tex)
    {
        if(tex == UssageLicense.Allow)
        {
            return maru;
        }
        else
        {
            return batu;
        }
    }

    public void OnLoadVRMPath ()
    {
        LoadVRMPathStatic.Path = path;
    }
}