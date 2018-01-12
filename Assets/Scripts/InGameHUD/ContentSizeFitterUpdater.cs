using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentSizeFitterUpdater : MonoBehaviour {

    [SerializeField]
    ContentSizeFitter csf;
	
	void OnEnable () {
        StartCoroutine(UpdateContentSize());
	}

    private IEnumerator UpdateContentSize()
    {
        csf.enabled = false;
        yield return new WaitForSeconds(0.01f);
        csf.enabled = true;
    }
}
