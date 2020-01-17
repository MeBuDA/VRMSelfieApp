using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using VRM;

public class VRMFaceTracker : MonoBehaviour
{
    public Transform head { set; get; }
    public VRMBlendShapeProxy proxy { set; get; }

    private UnityARSessionNativeInterface session;

    void Start ()
    {
        InitializeSession ();
    }

    /// <summary>
    /// ARの初期化処理
    /// </summary>
    void InitializeSession ()
    {
        session = UnityARSessionNativeInterface.GetARSessionNativeInterface ();
        Application.targetFrameRate = 60;
        ARKitFaceTrackingConfiguration config = new ARKitFaceTrackingConfiguration ();
        config.alignment = UnityARAlignment.UnityARAlignmentGravity;
        config.enableLightEstimation = true;

        if (config.IsSupported)
        {
            session.RunWithConfig (config);

            UnityARSessionNativeInterface.ARFaceAnchorAddedEvent += FaceAdded;
            UnityARSessionNativeInterface.ARFaceAnchorUpdatedEvent += FaceUpdated;
            UnityARSessionNativeInterface.ARFaceAnchorRemovedEvent += FaceRemoved;

        }
        else
        {
            //利用できない場合
            return;
        }
    }

    void FaceAdded (ARFaceAnchor anchorData)
    {
        UpdateHead (anchorData);
        UpdateFace (anchorData);
    }
    void FaceUpdated (ARFaceAnchor anchorData)
    {
        UpdateHead (anchorData);
        UpdateFace (anchorData);
    }

    void FaceRemoved (ARFaceAnchor anchorData)
    {
        // 顔の認識ができなくなった場合の処理
        head.localRotation = Quaternion.identity;
    }

    void UpdateHead (ARFaceAnchor anchorData)
    {
        //ARKitが右手軸なのをUnityの左手軸に変更と水平坑はミラーにするように変更
        float angle = 0.0f;
        Vector3 axis = new Vector3 (-1, 1, -1);
        var rot = UnityARMatrixOps.GetRotation (anchorData.transform);
        rot.ToAngleAxis (out angle, out axis);
        axis.x = -axis.x;
        axis.z = -axis.z;
        head.localRotation = Quaternion.AngleAxis (angle, axis);
    }
    void UpdateFace (ARFaceAnchor anchorData)
    {
        var blendShapes = anchorData.blendShapes;
        if (blendShapes == null || blendShapes.Count == 0)
        {
            return;
        }
        // 口の動き
        proxy.ImmediatelySetValue (BlendShapePreset.A, (blendShapes[ARBlendShapeLocation.JawOpen] - blendShapes[ARBlendShapeLocation.MouthClose]));
        proxy.ImmediatelySetValue (BlendShapePreset.U, (blendShapes[ARBlendShapeLocation.MouthFunnel] + blendShapes[ARBlendShapeLocation.MouthPucker]) / 1.8F);
        proxy.ImmediatelySetValue (BlendShapePreset.I, (blendShapes[ARBlendShapeLocation.MouthStretchRight] + blendShapes[ARBlendShapeLocation.MouthStretchLeft]) / 1.8F);
        //目の動き
        proxy.ImmediatelySetValue (BlendShapePreset.Blink_L, blendShapes[ARBlendShapeLocation.EyeBlinkLeft] * 1.2F);
        proxy.ImmediatelySetValue (BlendShapePreset.Blink_R, blendShapes[ARBlendShapeLocation.EyeBlinkRight] * 1.2F);
    }
}