using UnityEngine;
using System.Collections;

public class QuestLogController : MonoBehaviour {

    public GameObject questLogPanel;
    public static QuestLogController qlController;
    public CanvasGroup questLogCanvas;

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
        questLogCanvas.alpha = 1;
        questLogCanvas.interactable = true;
        questLogCanvas.blocksRaycasts = true;
    }

    public void closeQuestLog()
    {
        questLogCanvas.alpha = 0;
        questLogCanvas.interactable = false;
        questLogCanvas.blocksRaycasts = false;
    }
}
