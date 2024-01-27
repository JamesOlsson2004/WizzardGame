using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EquipMenu : MonoBehaviour
{
    string ButtonName;
    public GameObject Dictionary;
    int SlotValue;
    public Sprite UiReset;
    public GameObject ImageFollow;
    public List<string> Slots = new List<string>();
    GameObject[] AllSpells;

    void Start()
    {
        for (int i = 0; i != 8; i++)
        {
            Slots.Add("");
        }
    }

    public void CheckSpells()
    {
        List<string> TotalSpells = new List<string>(Dictionary.GetComponent<SpellDictionary>().SpellNames);
        List<string> ToBeSent = new List<string>();
        GameObject activate;
        ToBeSent.Add("");
        ToBeSent.Add("");

        for (int i = 0; i != TotalSpells.Count; i++)
        {
            ToBeSent[0] = TotalSpells[i];
            ToBeSent[1] = "active";
            ToBeSent = Dictionary.GetComponent<SpellDictionary>().RecieveData(ToBeSent);
            if (ToBeSent[1] == "true")
            {
                AllSpells = GameObject.FindGameObjectsWithTag("EquipSpell");
                foreach (GameObject x in AllSpells)
                {
                    if (ToBeSent[0] == x.name)
                    {
                        activate = x;
                        if (activate != null)
                        {
                            activate.GetComponent<Image>().enabled = true;
                            activate.GetComponent<Button>().enabled = true;
                            GameObject textobj = x.gameObject.transform.GetChild(0).gameObject;
                            textobj.SetActive(true);
                        }
                    }
                }

            }
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
