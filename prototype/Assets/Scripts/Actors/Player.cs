using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [HideInInspector]
    public int currentExp;
    [HideInInspector]
    public int maxExp;
    Animator anim;

    public override void Start()
    {
        stats.Add(new BaseStat(baseHealth, "base health"));
        stats.Add(new BaseStat(baseMana, "base mana"));

        stats.Add(new BaseStat(strength, "strength"));
        stats.Add(new BaseStat(agility, "agility"));
        stats.Add(new BaseStat(intelligence, "intelligence"));

        stats.Add(new BaseStat(spellPower, "spell power"));
        stats.Add(new BaseStat(attackPower, "attack power"));

        stats.Add(new BaseStat(attackSpeed, "attack speed"));
        stats.Add(new BaseStat(armor, "armor"));

        stats.Add(new BaseStat(baseHealthRegen, "base health regen"));
        stats.Add(new BaseStat(baseManaRegen, "base mana regen"));

        currentHealth = GetMaxHealth();
        currentMana = GetMaxMana();

        lvl = 1;
        maxExp = 100;
        currentExp = 0;

        anim = GetComponent<Animator>();
    }

    public override void Die()
    {
        anim.SetBool("dead", true);
        GetComponent<WorldInteraction>().enabled = false;
        GetComponent<SpellsController>().enabled = false;
    }

    public void increaseLvl()
    {
        lvl++;
        currentExp = currentExp - maxExp;
        maxExp = 100 * lvl;
        stats.Find(x => x.StatType == "base health").AddStatBonus(new StatBonus(100));
        stats.Find(x => x.StatType == "intelligence").AddStatBonus(new StatBonus(5));
        stats.Find(x => x.StatType == "agility").AddStatBonus(new StatBonus(5));
        stats.Find(x => x.StatType == "strength").AddStatBonus(new StatBonus(5));
        currentHealth += 175; // Max health is increased so current health has to be increased with the same amount

    }
    public void GainExp(int exp)
    {
        currentExp += exp;

        if (currentExp >= maxExp)
        {
            increaseLvl();
        }
    }




}
