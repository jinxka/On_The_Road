using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {

    #region UnityCompliant Singleton
    public static GUIManager Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    #endregion

    [Header("Input Manager")]
    public KeyCode Menu = KeyCode.Escape;
    public KeyCode Inventory = KeyCode.I;
    public KeyCode LevelMap = KeyCode.Tab;
    public KeyCode GlobalMap = KeyCode.M;
    public KeyCode QuestLog = KeyCode.L;
    public KeyCode SkillBook = KeyCode.K;
    public KeyCode ActionBar1 = KeyCode.Alpha1;
    public KeyCode ActionBar2 = KeyCode.Alpha2;
    public KeyCode ActionBar3 = KeyCode.Alpha3;
    public KeyCode ActionBar4 = KeyCode.Alpha4;
    public KeyCode Skill0 = KeyCode.Mouse0;
    public KeyCode Skill1 = KeyCode.Mouse1;
    public KeyCode Skill2 = KeyCode.A;
    public KeyCode Skill3 = KeyCode.F;
    public KeyCode Skill4 = KeyCode.Space;
    public KeyCode PickUpLoot = KeyCode.E;



    public void TogglePanel(CanvasGroup panel)
    {
        if (panel.alpha == 1)
        {
            panel.alpha = 0;
            panel.blocksRaycasts = false;
            panel.interactable = false;
        }
        else
        {
            panel.alpha = 1;
            panel.blocksRaycasts = true;
            panel.interactable = true;
        }
    }
}
