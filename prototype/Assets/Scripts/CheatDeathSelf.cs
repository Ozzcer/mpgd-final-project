using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatDeathSelf : MonoBehaviour
{
    private CharacterStats charStats;
    public int healPercentage;
    public float spellCooldown;
    public float timer;

    private void Start()
    {
        timer = 0;
        charStats = GetComponent<CharacterStats>();
    }


    private void Update()
    {
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
    }
    public void castSpell()
    {
        if (timer <= 0)
        {
            double healthDifference = charStats.GetMaxHealth() - charStats.currentHealth;
            double heal = (healthDifference / 100) * healPercentage;
            timer = spellCooldown;
        }

    }
}
