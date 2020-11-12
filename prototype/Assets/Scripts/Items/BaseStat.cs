using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This calss is used to inherit general behaviour for a character's stat
public class BaseStat
{
    public List<StatBonus> BaseAdditives { get; set; }
    public int BaseValue { get; set; }
    public string StatType { get; set; }
    public int FinalValue { get; set; }


    public BaseStat(int baseValue, string statType)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatType = statType;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Remove(BaseAdditives.Find(x=> x.BonusValue == statBonus.BonusValue));
    }

    public int GetCalculatedStatValue()
    {
        this.FinalValue = 0;
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;
        return FinalValue;
    }
}

