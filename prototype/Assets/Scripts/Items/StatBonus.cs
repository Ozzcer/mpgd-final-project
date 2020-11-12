using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//A class for implementing stat bonuses comming from items
public class StatBonus
{ 
    public int BonusValue { get; set; }

    public StatBonus(int bonusValue)
    {
        this.BonusValue = bonusValue;
    }
}
