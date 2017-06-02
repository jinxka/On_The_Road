using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SkillData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    public Skill skill;
    public int amount;
    public int cellID;

    //private Transform originalParent;
    private SkillBook sb;
    private Vector2 offset;
    private SkillTooltip tooltip;

    void Start()
    {
        sb = GameObject.Find("SkillBook").GetComponent<SkillBook>();
        tooltip = sb.GetComponent<SkillTooltip>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (skill != null)
        {
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offset;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (skill != null)
        {
            this.transform.position = eventData.position - offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(sb.cells[cellID].transform);
        //this.transform.SetParent(originalParent);
        //this.transform.position = originalParent.transform.position;
        this.transform.position = sb.cells[cellID].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (skill != null)
        {
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(skill);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }
}
