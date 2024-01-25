using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public float HeldExp;
    public int PlayerLevel;
    float RequiredExp;

    void Start()
    {
        RequiredExp = (PlayerLevel * (1000)) * 2.5f;
    }

    void Update()
    {
        if (HeldExp >= RequiredExp)
        {
            float OverFlow;
            OverFlow = HeldExp - RequiredExp;
            PlayerLevel += 1;
            RequiredExp = (PlayerLevel * (1000)) * 2.5f;
            HeldExp = 0 + OverFlow;
        }
    }
}
