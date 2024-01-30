using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpellDictionary : MonoBehaviour
{

    public class Spell 
    {
        public string name { get; set; }
        public string description { get; set; }
        public float damage { get; set; }
        public int range { get; set; }
        public float speed { get; set; }
        public float CastTime { get; set; }
        public int duration { get; set; }
        public float Exp { get; set; }
        public float RequiredExp { get; set; }
        public bool active { get; set; }
        public float mana { get; set; }

        public string[] Property = { "name", "description", "damage", "range", "speed", "CastTime", "duration", "Exp", "RequiredExp", "active", "mana" };
    }

    public GameObject SpellTree;
    public string Sidentifier;
    List<Spell> Spells = new List<Spell>();
    public List<string> SpellNames = new List<string>();
    public List<bool> SpellActives = new List<bool>();

    void Start()
    {

        Spell Fireball = new Spell();
        Fireball.name = "fireball";
        Fireball.description = "Cast a fireball which explodes on contact";
        Fireball.damage = 5f;
        Fireball.range = 3;
        Fireball.duration = 3;
        Fireball.speed = Fireball.range / Fireball.duration;
        Fireball.CastTime = 1.5f;
        Fireball.Exp = 0f;
        Fireball.RequiredExp = 1000f;
        Fireball.active = false;
        Fireball.mana = 10f;
        AddToLists(Fireball);
    }

    void AddToLists(Spell spell)
    { 
        Spells.Add(spell);
        SpellNames.Add(spell.name);
        SpellActives.Add(spell.active);
    }

    void Update()
    {
        if (SpellTree.GetComponent<SpellTree>().Sidentifier != null)
        {
            var Sidentifier = SpellTree.GetComponent<SpellTree>().Sidentifier;
            for (int i = 0; i < Spells.Count; i++)
            {
                if (Spells[i].name == Sidentifier)
                {
                    Spells[i].active = true;
                    Sidentifier = null;
                }
            }
        }
    }

    public List<string> RecieveData(List<string> ToBeSent)
    {
        Spell spellname = new Spell();
        if (ToBeSent.Count != null)
        {
            for (int y = 0; y != ToBeSent.Count; y++)
            {
                if (y == 0)
                {
                    for (int c = 0; c != Spells.Count; c++)
                    {
                        if (Spells[c].name == ToBeSent[y])
                        {
                            spellname = Spells[c];
                        }
                    }
                    if (spellname == null)
                    {
                        return null;
                    }
                }
                else
                {
                    for (int d = 0; d != spellname.Property.Length; d++)
                    {
                        if (spellname.Property[d] == ToBeSent[y])
                        {
                            switch (d)
                            {
                                case 0:
                                    ToBeSent[y] = spellname.name;
                                    break;
                                case 1:
                                    ToBeSent[y] = spellname.description;
                                    break;
                                case 2:
                                    ToBeSent[y] = spellname.damage.ToString(); 
                                    break;
                                case 3:
                                    ToBeSent[y] = spellname.range.ToString(); 
                                    break;
                                case 4:
                                    ToBeSent[y] = spellname.speed.ToString(); 
                                    break;
                                case 5:
                                    ToBeSent[y] = spellname.CastTime.ToString(); 
                                    break;
                                case 6:
                                    ToBeSent[y] = spellname.duration.ToString(); 
                                    break;
                                case 7:
                                    ToBeSent[y] = spellname.Exp.ToString(); 
                                    break;
                                case 8:
                                    ToBeSent[y] = spellname.RequiredExp.ToString(); 
                                    break;
                                case 9:
                                    if (spellname.active == true)
                                    { ToBeSent[y] = "true"; }
                                    else
                                    { ToBeSent[y] = "false"; }
                                    break;
                                case 10:
                                    {
                                        ToBeSent[y] = spellname.mana.ToString();
                                        break;
                                    }
                            } // matching a name to a parameter
                        } 
                    }
                    return ToBeSent;
                }
            }
        }
        return null;
    }

    public void UpdateExp(string spellname, float exp)
    {
        if (spellname == null)
        { Debug.Log("no spell name"); return; }
        if (exp == null)
        { Debug.Log("no exp"); return;  }

        Spell ToUpdate = null;
        foreach (Spell x in Spells)
        {
            if (x.name == spellname)
            { ToUpdate = x; }
        }

        if (ToUpdate == null)
        { Debug.Log("no spell found"); return; }

        if (ToUpdate.Exp >= ToUpdate.RequiredExp)
        { Debug.Log("No More Exp Required"); ToUpdate.Exp = ToUpdate.RequiredExp; return; }

        ToUpdate.Exp += exp;
    }
}
