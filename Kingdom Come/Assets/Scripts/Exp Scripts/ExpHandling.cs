using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpHandling : MonoBehaviour
{
    float MovingExp;
    public GameObject Player;
    public GameObject SpellHandeler;

    void Update()
    {
        //other code which gets the exp
        //distrubution
        Player.GetComponent<PlayerExp>().HeldExp += MovingExp;

    }
}
