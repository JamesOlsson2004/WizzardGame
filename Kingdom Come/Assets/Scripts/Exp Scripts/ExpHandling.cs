using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpHandling : MonoBehaviour
{
    float MovingExp;
    public GameObject Player;
    public GameObject SpellHandeler;

    public void TransferData(string Spellname, float Exp)
    { 
        MovingExp = Exp;
        Player.GetComponent<PlayerExp>().HeldExp += MovingExp;

        SpellHandeler.GetComponent<SpellDictionary>().UpdateExp(Spellname, Exp);
    }
}
