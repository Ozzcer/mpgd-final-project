using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();
    public double currentHealth;
    public int lvl;
    public int currentExp;
    public int maxExp;
    Animator anim;

    void Start()
    {
        lvl = 1;
        maxExp = 100;
        currentExp = 0;
        
        anim = GetComponent<Animator>();

        stats.Add(new BaseStat(500, "base health"));
        stats.Add(new BaseStat(5, "armor"));
        stats.Add(new BaseStat(10, "strength"));
        stats.Add(new BaseStat(10, "agility"));
        stats.Add(new BaseStat(10, "intelligence"));
        stats.Add(new BaseStat(20, "attack speed"));
        stats.Add(new BaseStat(50, "spell power"));
        stats.Add(new BaseStat(2, "base health regen"));

        currentHealth = GetMaxHealth();
        
    }

    private void Update()
    {
        if (this.currentHealth <= 0)
        {
            Die();
        }

        if (currentHealth < GetMaxHealth())
        {
            currentHealth += GetHealthRegen() * Time.deltaTime;

            if (currentHealth > GetMaxHealth())
            {
                currentHealth = GetMaxHealth();
            }
        }

        if (currentExp >= maxExp)
        {
            increaseLvl();
        }
    }


    private void Die()
    {
        anim.SetBool("dead", true);
        GetComponent<WorldInteraction>().enabled = false;
        GetComponent<SpellsController>().enabled = false;
    }

    public void TakeDamage(double rawDamage)
    {
        double damageMulti = GetDamageMultiplier();
        double damage = rawDamage * damageMulti;
        this.currentHealth -= damage;
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

    public void AddStatBonus(string statType, int value) 
    {
            stats.Find(x => x.StatType == statType).AddStatBonus(new StatBonus(value));
    }

    public void RemoveStatBonus(string statType, int value)
    {
        stats.Find(x => x.StatType == statType).RemoveStatBonus(new StatBonus(value));
    }

    public double GetDamageMultiplier()
    {
        int armor = stats.Find(x => x.StatType == "armor").GetCalculatedStatValue();
        int agility = stats.Find(x => x.StatType == "agility").GetCalculatedStatValue();
        double finalArmor = agility * 0.5;
        double dmgMultiplier = 1 - ((0.052 * finalArmor) / (0.9 + 0.048 * Math.Abs(finalArmor)));
        return dmgMultiplier;
    }

    public double GetMaxHealth()
    {
        double baseHealth = stats.Find(x => x.StatType == "base health").GetCalculatedStatValue();
        int strength = stats.Find(x => x.StatType == "strength").GetCalculatedStatValue();
        return baseHealth + strength * 15;
    }

    public double GetHealthRegen()
    {
        double baseHealthRegen = stats.Find(x => x.StatType == "base health regen").GetCalculatedStatValue();
        int strength = stats.Find(x => x.StatType == "strength").GetCalculatedStatValue();
        return baseHealthRegen + strength * 0.2;
    }

   // public double GetTotalAttackSpeed()
   // {
   //     double attackSpeed = stats.Find(x => x.StatType == "attack speed").GetCalculatedStatValue();
   //     int agility = stats.Find(x => x.StatType == "agility").GetCalculatedStatValue();
   //     return attackSpeed + agility * 0.5;
   // }

    public double GetTotalSpellPower()
    {
        double spellPower = stats.Find(x => x.StatType == "spell power").GetCalculatedStatValue();
        int intelligence = stats.Find(x => x.StatType == "intelligence").GetCalculatedStatValue();
        return spellPower + intelligence * 1.5;
    }

    public void GainExp(int exp)
    {
        currentExp += exp;
    }
}
