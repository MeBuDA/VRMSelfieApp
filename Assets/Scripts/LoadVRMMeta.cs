using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using VRM.QuickMetaLoader;

public class LoadVRMMeta : MonoBehaviour
{
    [SerializeField] private RectTransform _cardPrefab;

    void Start()
    {
        var vrms = Directory.GetFiles(Application.streamingAssetsPath + "/VRMSelfie_Models/", "*.vrm", System.IO.SearchOption.TopDirectoryOnly);
        foreach (var vrm in vrms)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            LoadMeta(vrm);
            stopwatch.Stop();
            Debug.Log("LoadTime: " + (float)stopwatch.Elapsed.TotalSeconds + " sec");
        }
    }
    private void LoadMeta(string file)
    {
        var bytes = File.ReadAllBytes(file);
        using (var metaLoader = new MetaLoader(bytes))
        {
            var meta = metaLoader.Read(true);

            var go = Instantiate(_cardPrefab, transform);
            var card = go.GetComponent<CharacterCard>();
            card.SetMetaText(meta);
            card.SetThumbnail(meta.Thumbnail);
            card.SetPath(file);
        }
    }
}
