using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{

	//　非同期動作で使用するAsyncOperation
	[SerializeField] private AsyncOperation async;
	//　シーンロード中に表示するUI画面
	[SerializeField] private GameObject loadUI;
	//　読み込み率を表示するスライダー
	[SerializeField] private Slider slider;
	[SerializeField] private string scene;
	[SerializeField] private GameObject gameObject;

	public void NextScene ()
	{
		Destroy(gameObject);
		//　ロード画面UIをアクティブにする
		loadUI.SetActive (true);

		//　コルーチンを開始
		StartCoroutine ("LoadData");
		Resources.UnloadUnusedAssets ();
		System.GC.Collect ();
	}

	IEnumerator LoadData ()
	{
		// シーンの読み込みをする
		async = SceneManager.LoadSceneAsync (scene);

		//　読み込みが終わるまで進捗状況をスライダーの値に反映させる
		while (!async.isDone)
		{
			var progressVal = Mathf.Clamp01 (async.progress / 0.9f);
			slider.value = progressVal;
			yield return null;
		}
	}
}