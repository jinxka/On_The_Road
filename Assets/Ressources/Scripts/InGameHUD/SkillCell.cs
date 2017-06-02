using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SkillCell : MonoBehaviour, IDropHandler
{
    public int id;
    private SkillBook sb;

    void Start()
    {
        sb = GameObject.Find("SkillBook").GetComponent<SkillBook>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        SkillData droppedSkill = eventData.pointerDrag.GetComponent<SkillData>();
        if (sb.skills[id].ID == -1)
        {
            sb.skills[droppedSkill.cellID] = new Skill();
            sb.skills[id] = droppedSkill.skill;
            droppedSkill.cellID = id;
        }
        else if (droppedSkill.cellID != id)
        {
            Transform skill = this.transform.GetChild(0);
            skill.GetComponent<SkillData>().cellID = droppedSkill.cellID;
            skill.transform.SetParent(sb.cells[droppedSkill.cellID].transform);
            skill.transform.position = sb.cells[droppedSkill.cellID].transform.position;

            droppedSkill.cellID = id;
            droppedSkill.transform.SetParent(this.transform);
            droppedSkill.transform.position = this.transform.position;

            sb.skills[droppedSkill.cellID] = skill.GetComponent<SkillData>().skill;
            sb.skills[id] = droppedSkill.skill;
        }
    }
}
