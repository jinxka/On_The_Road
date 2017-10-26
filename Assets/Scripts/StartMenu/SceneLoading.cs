using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour {

    public static SceneLoading sceneLoader;

    [SerializeField]
    Image progressBarFull;

    [SerializeField]
    Text progressText;

    [SerializeField]
    CanvasGroup progressGroup;

    void Awake()
    {
        if (sceneLoader == null)
        {
            DontDestroyOnLoad(gameObject);
            sceneLoader = this;
        }
        else if (sceneLoader != this)
        {
            Destroy(gameObject);
        }
    }

    public void loadScene(string sceneToLoad)
    {       
        progressGroup.alpha = 1;
        StartCoroutine(waitForSceneToLoad(sceneToLoad));
    }

    private IEnumerator waitForSceneToLoad(string sceneToLoad)
    {
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
    }
}
