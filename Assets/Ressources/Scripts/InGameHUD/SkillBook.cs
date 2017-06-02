using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkillBook : MonoBehaviour {
    public GameObject panel;
    public GameObject grid;
    SkillDatabase skDatabase;
    public GameObject cell;
    public GameObject skill;
    public int cellNumber;
    
    public List<Skill> skills = new List<Skill>();
    public List<GameObject> cells = new List<GameObject>();

    void Start()
    {
        skDatabase = GetComponent<SkillDatabase>();
        for (int i = 0; i < cellNumber; i++)
        {
            skills.Add(new Skill());
            cells.Add(Instantiate(cell));
            cells[i].GetComponent<SkillCell>().id = i;
            cells[i].transform.SetParent(grid.transform);
            cells[i].GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        AddSkill(0);
        AddSkill(1);
    }

    public void AddSkill(int id)
    {
        Skill skillToAdd = skDatabase.fetchSkillByID(id);
        for (int i = 0; i < skills.Count; i++)
        {
            if (skills[i].ID == -1)
            {
                skills[i] = skillToAdd;
                GameObject skillObj = Instantiate(skill);
                skillObj.GetComponent<SkillData>().skill = skillToAdd;
                skillObj.GetComponent<SkillData>().cellID = i;
                skillObj.transform.SetParent(cells[i].transform);
                skillObj.transform.position = Vector2.zero;
                skillObj.GetComponent<Image>().sprite = skillToAdd.Sprite;
                skillObj.GetComponent<Image>().transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                skillObj.name = skillToAdd.Title;
                break;
            }
        }
    }
}
