using UnityEngine;
using System.Collections;

public class QuestLogController : MonoBehaviour {

    public GameObject questLogPanel;
    private questManager questSystem;


	// Use this for initialization
	void Start () {
        questSystem = this.GetComponent<questManager>();
        questLogPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void openQuestLog()
    {
        questLogPanel.SetActive(true);
    }

    public void closeQuestLog()
    {
        questLogPanel.SetActive(false);
    }
}
