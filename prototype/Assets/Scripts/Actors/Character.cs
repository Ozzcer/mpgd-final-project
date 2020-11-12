using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentMana;

    public int lvl;
    public int baseHealth;
    public int baseMana;
    public int strength;
    public int agility;
    public int intelligence;
    public int spellPower;
    public int attackPower;
    public int attackSpeed;
    public int armor;
    public int baseHealthRegen;
    public int baseManaRegen;


    public virtual void Start()
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
    }

    private void Update()
    {
        this.HealthHeal(GetHealthRegen() * Time.deltaTime);
        this.ManaHeal(GetHealthRegen() * Time.deltaTime);
    }


    public virtual void Die()
    {

    }

    public void TakeDamage(float rawDamage)
    {
        float damageMulti = GetDamageMultiplier();
        float damage = rawDamage * damageMulti;
        this.currentHealth -= damage;

        Debug.Log("Takes " + damage + " dmg");
        if (this.currentHealth <= 0)
        {
            Die();
        }
    }

    public void HealthHeal(float healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > GetMaxHealth())
        {
            currentHealth = GetMaxHealth();
        }
    }

    public void ManaHeal(float healAmount)
    {
        currentMana += healAmount;

        if (currentMana > GetMaxMana())
        {
            currentMana = GetMaxMana();
        }
    }


    public float GetDamageMultiplier()
    {
        int armor = GetStat("armor");
        int agility = GetStat("agility");
        float finalArmor = armor + agility * 0.1f;
        float dmgMultiplier = 1 - ((0.052f * finalArmor) / (0.9f + 0.048f * Math.Abs(finalArmor)));
        return dmgMultiplier;
    }

    public int GetMaxHealth()
    {
        int baseHealth = GetStat("base health");
        int strength = GetStat("strength");
        return baseHealth + strength * 15;
    }
    public int GetMaxMana()
    {
        int spellPower = GetStat("base mana");
        int intelligence = GetStat("intelligence");
        return spellPower + intelligence * 15;
    }

    public float GetHealthRegen()
    {
        float baseHealthRegen = GetStat("base health regen");
        int strength = GetStat("strength");
        return baseHealthRegen + strength * 0.2f;
    }

    public float GetManaRegen()
    {
        float baseManaRegen =  GetStat("base mana regen");
        int intelligence =  GetStat("strength");
        return baseManaRegen + intelligence * 0.2f;
    }

    public float GetAttackSpeed()
    {
        float attackSpeed =  GetStat("attack speed");
        int agility =  GetStat("agility");
        return attackSpeed + agility * 0.5f;
    }

    public int GetSpellPower()
    {
        int spellPower =  GetStat("spell power");
        return spellPower;
    }

    public int GetAttackPower()
    {
        int spellPower = GetStat("attack power");
        return spellPower;
    }

    public int GetStat(string statType)
    {
        return stats.Find(x => x.StatType == statType).GetCalculatedStatValue();
    }

    public void AddStatBonus(string statType, int value)
    {
        stats.Find(x => x.StatType == statType).AddStatBonus(new StatBonus(value));
    }

    public void RemoveStatBonus(string statType, int value)
    {
        stats.Find(x => x.StatType == statType).RemoveStatBonus(new StatBonus(value));
    }
}
