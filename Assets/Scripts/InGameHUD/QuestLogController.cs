using UnityEngine;
using System.Collections;

public class QuestLogController : MonoBehaviour {

    public GameObject questLogPanel;
    private questManager questSystem;
    public static QuestLogController qlController;


	// Use this for initialization
	void Start () {
        questSystem = this.GetComponent<questManager>();
        questLogPanel.SetActive(false);
    }

    void Awake()
    {
        if (qlController == null)
        {
            DontDestroyOnLoad(gameObject);
            qlController = this;
        }
        else if (qlController != this)
        {
            Destroy(gameObject);
        }
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
