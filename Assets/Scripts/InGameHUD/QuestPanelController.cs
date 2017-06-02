using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestPanelController : MonoBehaviour {

    public GameObject questDetails;

	// Use this for initialization
	void Start () {
        questDetails.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onQuestClick()
    {
        questDetails.SetActive(true);
    }
}
