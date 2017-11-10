using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorScript : MonoBehaviour {

    [SerializeField]
    Text errorText;

    void Start()
    {
        errorText.canvasRenderer.SetAlpha(0f);
    }

    public void DisplayErrorMessage(string errorMessage)
    {
        HideErrorMessage();
        errorText.text = errorMessage;
        errorText.CrossFadeAlpha(0.99f, 0.3f, false);
        StartCoroutine(beginHidingErrorMessage());
    }
    
    void HideErrorMessage()
    {
        errorText.CrossFadeAlpha(0.01f, 0.3f, false);
    }

    public IEnumerator beginHidingErrorMessage()
    {
        yield return new WaitForSeconds(3f);
        HideErrorMessage();
    }
}
