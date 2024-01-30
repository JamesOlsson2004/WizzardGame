using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Public Stats")]
    public float health;
    public int maxHealth;
    public float mana;
    public float maxMana;
    public float manaTimer;
    public float healthTimer;


    [Header("Public references")]
    public Slider ManaBar;

    public float tm = 0.0f;
    public float th = 0.0f;

    void Start()
    {
        ManaBar.maxValue = maxMana;
        manaTimer = 2f;
        healthTimer = 2f;
    }

    void Update()
    {
        mana = Mathf.Clamp(mana, 0, maxMana);
        ManaBar.value = mana;

        if (manaTimer > 0) { manaTimer -= 1 * Time.deltaTime; }
        if (healthTimer > 0) { healthTimer -= 1 * Time.deltaTime; }

        if (mana < maxMana && manaTimer <= 0)
        {
            mana = Mathf.Lerp(0, maxMana, tm);
            tm += 0.06f * Time.deltaTime;
        }else { tm = 0; }
        if (health < maxHealth && healthTimer <= 0)
        {
            health = Mathf.Lerp(0, maxHealth, th);
            th += 0.06f * Time.deltaTime;
        }else { th = 0; }
    }
}
