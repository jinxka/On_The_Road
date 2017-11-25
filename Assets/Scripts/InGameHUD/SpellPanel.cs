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
        if (Input.GetKeyDown("f"))
            heal.UseSpell();
        if (Input.GetKeyDown("a"))
            damageBuff.UseSpell();
        if (Input.GetKeyDown("e"))
           sprint.UseSpell();
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
            rCA.UseSpell();
    }
}
