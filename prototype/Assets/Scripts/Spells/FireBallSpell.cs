using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireBallSpell : BasicSpell
{
    public GameObject spawnLocation;
    public GameObject spellPrefab;

    private int baseDamage;

    public override void CastSpell()
    {
        int spellPower = player.GetSpellPower();
        baseDamage = Random.Range(minAmount, minAmount);
        if (timer <= 0)
        {   
            GameObject fireBall = (GameObject) Instantiate(spellPrefab, spawnLocation.transform.position, spawnLocation.transform.rotation);
            fireBall.GetComponent<DestroyOnCollision>().damage = baseDamage + spellPower;
            timer = spellCooldown;
        }
    }
}
