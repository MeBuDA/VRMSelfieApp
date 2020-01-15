using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DefaultModel : MonoBehaviour
{
    void Awake ()
    {
        // StreamingAssets内のデフォルトVRMを取得
        var file = Application.streamingAssetsPath + "/" + "Mebu.vrm";
        // バイト配列を読み込む
        byte[] _byte = File.ReadAllBytes (file);
        // Documents/にMebu.vrmという名前でbyteを保存
        File.WriteAllBytes (Application.persistentDataPath + "/Mebu.vrm", _byte);
    }
}