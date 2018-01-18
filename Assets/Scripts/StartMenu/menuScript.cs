using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	[SerializeField]
	GameObject loadPanel;

    public void onButtonHover(Image _image)
    {
        _image.enabled = true;
		AudioManager.instance.Play("MenuNavigation");

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
}
