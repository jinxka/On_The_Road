using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class SkillTooltip : MonoBehaviour {

    private Skill skill;
    private string data;
    private string color;
    public GameObject tooltip;

    void Start()
    {
        tooltip.SetActive(false);
        color = "<color=#FFFFFFFF>";
    }

    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Skill skill)
    {
        this.skill = skill;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        //System.Diagnostics.Debug.WriteLine(skill.Title);// + " " + skill.Power + " " + skill.Description);
        if (skill != null)
        {
            data = color + "<b>" + skill.Title + "</b></color>\n" +
                "\nPower: " + skill.Power + "\n" + skill.Description;
            tooltip.transform.GetChild(0).GetComponent<Text>().text = data; 
        }
    }
}
