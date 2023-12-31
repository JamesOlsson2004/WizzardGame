using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTree : MonoBehaviour
{
    public GameObject Player;
    public GameObject ButtonSp1;
    public GameObject ButtonSp2;

    public void SpellOne()
    {
        ButtonSp2.SetActive(true);
    }

    public void SpellTwo()
    {
    } 

    void Update()
    {
        
    }
}
