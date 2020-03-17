﻿using System;
using System.Collections;
using System.Collections.Generic;

public class Attribute : BaseAttribute {

    private List<BaseAttribute> bonuses;

    public int FinalValue {
        get; private set;
    }

    
    public Attribute(int baseValue) : base(baseValue) {
        bonuses = new List<BaseAttribute>();
    }


    /// <summary>
    /// Adds the bonus to the attribute
    /// </summary>
    /// <param name="bonus">The bonus to add</param>
    public void AddBonus(BaseAttribute bonus) {
        bonuses.Add(bonus);
    }

    /// <summary>
    /// Removes the bonus from the attrubute
    /// </summary>
    /// <param name="bonus">The bonus to remove</param>
    public void RemoveBonus(BaseAttribute bonus) {
        bonuses.Remove(bonus);
    }

    /// <summary>
    /// Calculates the final value of the attribute
    /// </summary>
    /// <returns>The final value</returns>
    public int CalculateValue() {
        //Start with this attribute's base value
        FinalValue = BaseValue;

        //Collect all of the base values and multipliers
        int bonusValue = 0;
        float bonusMultiplier = 0;

        foreach(BaseAttribute bonus in bonuses) {
            //If the attribute is another attribute then get the final value instead
            if(bonus.GetType().Equals(typeof(Attribute))) {
                Attribute attribute = (Attribute)bonus;
                FinalValue += attribute.FinalValue;
            } else {
                bonusValue += bonus.BaseValue;
                bonusMultiplier += bonus.BaseMultiplier;
            }
        }

        //Add the value and multiplier
        FinalValue += bonusValue;
        FinalValue = (int)Math.Floor(FinalValue * (1 + bonusMultiplier));

        return FinalValue;
    }

}
