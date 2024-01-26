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

        public string[] Property = { "name", "description", "damage", "range", "speed", "CastTime", "duration", "Exp", "RequiredExp", "active" };
    }

    public GameObject SpellTree;
    public string Sidentifier;
    List<Spell> Spells = new List<Spell>();

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
        Spells.Add(Fireball);
    }

    void Update()
    {
        if (SpellTree.GetComponent<SpellTree>().Sidentifier != null)
        {
            var Sidentifier = SpellTree.GetComponent<SpellTree>().Sidentifier;
        }

        for (int i = 0; i < Spells.Count; i++)
        {
            if (Spells[i].name == Sidentifier)
            {
                Spells[i].active = true;

                Sidentifier = null;
            }
        }

    }

    public object RecieveData(object[] ToBeSent)
    {
        Spell spellname = new Spell();
        if (ToBeSent.Length != null)
        {
            for (int y = 2; y != ToBeSent.Length; y++)
            {
                if (y == 2)
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
                        Debug.Log("No spell with name");
                        return null;
                    }
                }
                else
                {
                    var z = ToBeSent[y] as string;
                    for (int d = 0; d != spellname.Property.Length; d++)
                    {
                        if (z == spellname.Property[d])
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
                                    ToBeSent[y] = spellname.damage;
                                    break;
                                case 3:
                                    ToBeSent[y] = spellname.range;
                                    break;
                                case 4:
                                    ToBeSent[y] = spellname.speed;
                                    break;
                                case 5:
                                    ToBeSent[y] = spellname.CastTime;
                                    break;
                                case 6:
                                    ToBeSent[y] = spellname.duration;
                                    break;
                                case 7:
                                    ToBeSent[y] = spellname.Exp;
                                    break;
                                case 8:
                                    ToBeSent[y] = spellname.RequiredExp;
                                    break;
                                case 9:
                                    ToBeSent[y] = spellname.active;
                                    break;
                            } // matching a name to a parameter
                        }
                        else { Debug.Log("No matching parameters");  return null; }
                    }
                }
            }
            return ToBeSent;
        }
        Debug.Log("Empty obj");
        return null;
    }
}
