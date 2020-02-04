using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using VRM;

public class ImportVRMnonTask : MonoBehaviour
{
    void Start()
    {
        ImportVRMSync(LoadVRMPathStatic.Path);
    }
    private void ImportVRMSync(string path)
    {
        //ファイルをByte配列に読み込みます
        var bytes = File.ReadAllBytes(path);

        //VRMImporterContextがVRMを読み込む機能を提供します
        var context = new VRMImporterContext();

        // GLB形式でJSONを取得しParseします
        context.ParseGlb(bytes);

        // VRMのメタデータを取得
        var meta = context.ReadMeta(false); //引数をTrueに変えるとサムネイルも読み込みます

        //読み込めたかどうかログにモデル名を出力してみる
        Debug.LogFormat("meta: title:{0}", meta.Title);

        //同期処理で読み込みます
        context.Load();

        //読込が完了するとcontext.RootにモデルのGameObjectが入っています
        var root = context.Root;

        //モデルをワールド上に配置します
        root.transform.SetParent(transform, false);
        var animator = this.GetComponent<ToAnimator> ();
        var camIni = this.GetComponent<CameraIni> ();
        var IKAni = this.GetComponent<IKIni>();
        animator.SetAnimator (root);
        camIni.CameraInitilize (root);
        IKAni.IKInitilize(root);
        var VRMFaceIni = this.GetComponent<VRMFaceIni>();
        VRMFaceIni.VRMFaceInitialize(root);


        //メッシュを表示します
        context.ShowMeshes();

    }
}
