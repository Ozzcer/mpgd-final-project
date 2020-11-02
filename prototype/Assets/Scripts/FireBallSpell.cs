using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireBallSpell : BasicSpell
{
    public int minDmg;
    public int maxDmg;
    private int baseDamage;
    private CharacterStats charStats;
    

    private void Start()
    {
        charStats = GetComponent<CharacterStats>();
    }
    public override void castSpell()
    {
        int spellPower = (int)charStats.GetTotalSpellPower();
        baseDamage = Random.Range(minDmg, maxDmg);
        if (timer <= 0)
        {   
            GameObject fireBall = (GameObject) Instantiate(spellPrefab, spawnLocation.transform.position, spawnLocation.transform.rotation);
            fireBall.GetComponent<DestroyOnCollision>().damage = baseDamage + spellPower;
            timer = spellCooldown;
        }
    }
}
