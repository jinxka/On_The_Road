using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;
using System;


public class SkillDatabase : MonoBehaviour {
    private List<Skill> database = new List<Skill>();
    private JsonData skillData;

    void Start()
    {
        skillData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Skills.json"));
        constructSkillDatabase();
    }

    public Skill fetchSkillByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
                return database[i];
        return null;
    }

    public List<Skill> getSkDataBase ()
    {
        return database;
    }

    void constructSkillDatabase()
    {
        for (int i = 0; i < skillData.Count; i++)
        {
            database.Add(new Skill((int)skillData[i]["id"], skillData[i]["title"].ToString(), (int)skillData[i]["power"],
                skillData[i]["category"].ToString(), skillData[i]["description"].ToString(), skillData[i]["slug"].ToString()));
        }
    }
}

public class Skill {
    public int ID { get; set; }
    public string Title { get; set; }
    public int Power { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Skill(int id, string title, int power, string category, string description, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Power = power;
        this.Category = category;
        this.Description = description;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Skills/" + slug);
    }

    public Skill()
    {
        this.ID = -1;
    }
}
