using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class ActionBar : MonoBehaviour {

    public GameObject[] keys;
    public GameObject[] skillsLocations;
    private string[] actionBarDefaultBinds = new string[5];
    private List<Skill> skills = new List<Skill>();
    private SkillDatabase skDataBase;

	// Use this for initialization
	void Start () {
        actionBarDefaultBinds[0] = "a";
        actionBarDefaultBinds[1] = "e";
        actionBarDefaultBinds[2] = "r";
        actionBarDefaultBinds[3] = "f";
        actionBarDefaultBinds[4] = "m";
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].GetComponent<Text>().text = PlayerPrefs.GetString("keybindAction" + i, actionBarDefaultBinds[i]);
        }

        skDataBase = GameObject.Find("SkillBook").GetComponent<SkillDatabase>();
        for (int i = 0; i < 5; i++)
            skills.Add(new Skill());
        AddSkill(0);
        AddSkill(1);
        AddSkill(2);
        AddSkill(3);
    }
	
	// Update is called once per frame
	void Update () {
	      foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                    for (int i = 0; i < keys.Length; i++)
                    {    
                        if (kcode.ToString() == keys[i].GetComponent<Text>().text.ToUpper())
                        {
                            triggerAction(i);
                        }
                    }
            }
	}

    public void setKey(int id, string keybind)
    {
        keys[id].GetComponent<Text>().text = keybind;
    }


    void triggerAction(int id)
    {
        Debug.Log("Running action " + id);
    }

    public void AddSkill(int id)
    {
        Skill skillToAdd = skDataBase.fetchSkillByID(id);
       for (int i = 0; i < skills.Count; i++)
        {
            if (skills[i].ID == -1)
            {
                skills[i] = skillToAdd;
                skillsLocations[i].GetComponent<actionBarSkillData>().skill = skillToAdd;
                skillsLocations[i].GetComponent<Image>().sprite = skillToAdd.Sprite;
                skillsLocations[i].GetComponent<Image>().transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                skillsLocations[i].name = skillToAdd.Title;
                break;
            }
        }
    }
}
