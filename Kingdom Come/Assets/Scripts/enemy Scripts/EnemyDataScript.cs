using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyDataScript : MonoBehaviour
{
    [Header("Public Access Variables")]
    public float Health;

    [Header("Public Reference Variables")]
    public GameObject ExpHandler;

    //non public variables
    float Exp;
    Random rnd = new Random();

    void Start()
    {
        string x = "fireball";
        getHit(x, ExpHandler);
    }

    public void getHit(string SpellName, GameObject DataTo)
    { 
        Exp = rnd.Next(rnd.Next(5, 15), rnd.Next(5, 15));
        DataTo.GetComponent<ExpHandling>().TransferData(SpellName, Exp);
    }
}
