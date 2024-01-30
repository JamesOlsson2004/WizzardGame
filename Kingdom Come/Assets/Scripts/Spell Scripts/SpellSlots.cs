using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlots : MonoBehaviour
{
    public bool active;
    public Image ThisImage;
    public GameObject SisterSlot;
    public GameObject EquiptMenu;

    RectTransform rectTransform;
    Vector3 currentPos, targetPos;

    int sisterSiblingIndex;
    string spellname;
    string SpellInSlot;

    void Start()
    {
        rectTransform = this.gameObject.GetComponent<RectTransform>();
        currentPos = rectTransform.anchoredPosition3D;
        targetPos = SisterSlot.GetComponent<RectTransform>().anchoredPosition3D;
        sisterSiblingIndex = SisterSlot.transform.GetSiblingIndex();
    }

    public void ChangeActive()
    {
        if (active == true)
        {
            for (int t = 0; t < 1; t ++)
            {
                rectTransform.anchoredPosition3D = Vector3.Lerp(targetPos, currentPos, t);
            }
            transform.SetSiblingIndex(sisterSiblingIndex);
            active = false;
        } 
        else
        {
            for (int t = 0; t < 1; t ++)
            {
                rectTransform.anchoredPosition3D = Vector3.Lerp(targetPos, currentPos, t);
            }
            transform.SetSiblingIndex(sisterSiblingIndex);
            active = true;
        }
    }

    public void UpdateSlots()
    { 
        int SlotValue = int.Parse(this.name) - 11;
        List<Sprite> SlotImages = EquiptMenu.GetComponent<EquipMenu>().images;
        ThisImage.sprite = SlotImages[SlotValue];
        SpellInSlot = EquiptMenu.GetComponent<EquipMenu>().Slots[SlotValue];
    }

    void Update()
    {
        currentPos = rectTransform.anchoredPosition3D;
        targetPos = SisterSlot.GetComponent<RectTransform>().anchoredPosition3D;
        sisterSiblingIndex = SisterSlot.transform.GetSiblingIndex();
    }

}
    

