using UnityEngine;
using System.Collections;

public class QuestLogController : MonoBehaviour {

    #region UnityCompliant Singleton
    public static QuestLogController Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    #endregion

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
