using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using VRM;

public class ImportVRM : MonoBehaviour
{
    void Awake ()
    {
        ImportVRMAsync_Net4 (LoadVRMPathStatic.Path);
    }
    private async Task ImportVRMAsync_Net4 (string path)
    {
        //ファイルをByte配列に読み込みます
        var bytes = File.ReadAllBytes (path);

        //VRMImporterContextがVRMを読み込む機能を提供します
        var context = new VRMImporterContext ();

        // GLB形式でJSONを取得しParseします
        context.ParseGlb (bytes);

        //非同期処理(Task)で読み込みます
        await context.LoadAsyncTask ();

        //読込が完了するとcontext.RootにモデルのGameObjectが入っています
        var root = context.Root;

        //モデルをワールド上に配置します
        root.transform.SetParent (transform, false);

        var animator = this.GetComponent<ToAnimator> ();
        var camIni = this.GetComponent<CameraIni> ();
        var IKAni = this.GetComponent<IKIni>();
        var VRMFaceIni = this.GetComponent<VRMFaceIni>();
        var VRMFaceTracker = this.GetComponent<VRMFaceTracker>();

        animator.SetAnimator (root);
        camIni.CameraInitilize (root);
        IKAni.IKInitilize(root);
        VRMFaceIni.VRMFaceInitialize(root);
        VRMFaceTracker.InitializeSession();

        //メッシュを表示します
        context.ShowMeshes ();
    }
}