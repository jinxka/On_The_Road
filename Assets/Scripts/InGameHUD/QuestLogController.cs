using UnityEngine;
using System.Collections;

public class QuestLogController : MonoBehaviour {

    public GameObject questLogPanel;
    public CanvasGroup questLogCanvas;


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
