using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTree : MonoBehaviour
{
    public GameObject Player;
    public GameObject ButtonSp1;
    public GameObject ButtonSp2;
    public string Sidentifier = null;

    public void SpellOne()
    {
        ButtonSp2.SetActive(true);
        Sidentifier = "fireball";
    }

    public void SpellTwo()
    {
    } 

    void Update()
    {
        
    }
}
