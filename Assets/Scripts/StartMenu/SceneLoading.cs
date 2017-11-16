using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour {

    public static SceneLoading sceneLoader;
	public GameObject menuCanvas;

    [SerializeField]
    Image progressBarFull;

    [SerializeField]
    Text progressText;

    [SerializeField]
    CanvasGroup progressGroup;

    void Awake()
    {
		if (sceneLoader == null)
			sceneLoader = this;
//        if (sceneLoader == null)
//		{
//			if (menuCanvas != null)
//				DontDestroyOnLoad(menuCanvas);
//            sceneLoader = this;
//        }
//        else if (sceneLoader != this)
//        {
//            Destroy(gameObject);
//        }
    }

    public void loadScene(string sceneToLoad)
    {       
        progressGroup.alpha = 1;
        StartCoroutine(waitForSceneToLoad(sceneToLoad));
    }

    private IEnumerator waitForSceneToLoad(string sceneToLoad)
    {
		Debug.Log("Scene loading is starting");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        int progress;
        while (!asyncLoad.isDone)
        {
            progressBarFull.fillAmount = asyncLoad.progress;
            progress = (int)(asyncLoad.progress * 100);
            progressText.text = progress.ToString() + "%";
            yield return null;
        }
        progressGroup.alpha = 0;
		Debug.Log("Scene loading is over");
    }
}
