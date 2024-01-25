using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipMenu : MonoBehaviour
{
    string ButtonName;
    int SlotValue;
    public Sprite UiReset;
    public GameObject ImageFollow;

    public List<string> Slots = new List<string>();

    void Start()
    {
        for (int i = 0; i != 8; i++)
        {
            Slots.Add("");
        }
    }

    public void ClickedSpell()
    {
        if (ButtonName != null && ButtonName == EventSystem.current.currentSelectedGameObject.name) 
        {
            ButtonName = null;
        }
        else{ButtonName = EventSystem.current.currentSelectedGameObject.name;}
    }

    public void EquipSpell()
    {
        if (ButtonName != null)
        {
            GameObject SpellImage = GameObject.Find(ButtonName);
            GameObject SpellButton = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
            Image EquipImage = SpellButton.GetComponent<UnityEngine.UI.Image>();
            EquipImage.sprite = SpellImage.GetComponent<Image>().sprite;
            SlotValue = int.Parse(EventSystem.current.currentSelectedGameObject.name) - 1;
            Slots[SlotValue] = ButtonName;
        }
        if (ButtonName == null)
        {
            GameObject SpellButton = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
            Image EquipImage = SpellButton.GetComponent<UnityEngine.UI.Image>();
            EquipImage.sprite = UiReset;
            SlotValue = int.Parse(EventSystem.current.currentSelectedGameObject.name);
            Slots[SlotValue] = "";
        }
        ButtonName = null;
    }

    public Canvas parentCanvas;
    void Update()
    {
        if (ButtonName != null)
        {
            ImageFollow.SetActive(true);
            GameObject ImageRef = GameObject.Find(ButtonName);
            Image refImage = ImageRef.GetComponent<Image>();
            Image RPicture = ImageFollow.GetComponent<Image>();
            var tempColor = refImage.color;
            tempColor.a = 0.5f;
            RPicture.sprite = refImage.sprite;
            RPicture.color = tempColor;
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out movePos);
            Vector3 mousePos = parentCanvas.transform.TransformPoint(movePos);
            ImageFollow.transform.position = mousePos;
        }
        else
        { ImageFollow.SetActive(false); }
    }
}
