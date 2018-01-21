using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpellPanel : MonoBehaviour {

    [SerializeField]
    Heal heal;

    [SerializeField]
    BuffDegats damageBuff;

    [SerializeField]
    Sprint sprint;

    [SerializeField]
    RightClickAttack rCA;

	// Update is called once per frame
	void Update () {
        if (GUIManager.Instance.allPanelsAreClosed)
        {
            if (Input.GetKeyDown(NewInputManager.Instance.Skill3))
                heal.UseSpell();
            if (Input.GetKeyDown(NewInputManager.Instance.Skill2))
                damageBuff.UseSpell();
            if (Input.GetKeyDown(NewInputManager.Instance.Skill4))
                sprint.UseSpell();
            if (Input.GetKeyDown(NewInputManager.Instance.Skill1) && !EventSystem.current.IsPointerOverGameObject())
                rCA.UseSpell();
        }
    }
}
