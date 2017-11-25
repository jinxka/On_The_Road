using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	[SerializeField]
	GameObject loadPanel;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    public void onButtonHover(Image _image)
    {
        _image.enabled = true;
    }

    public void onButtonOut(Image _image)
    {
        _image.enabled = false;
    }

	public void showHideLoadPanel()
	{
		loadPanel.SetActive (!loadPanel.activeSelf);
	}

    public void newGame(string sceneToLoad)
    {
        SceneLoading.Instance.loadScene(sceneToLoad);
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        InventoryPersistence.Instance.hideInventory();
    }
}
