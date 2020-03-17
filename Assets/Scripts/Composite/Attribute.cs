using System;
using System.Collections;
using System.Collections.Generic;

public class Attribute : BaseAttribute {

    private List<BaseAttribute> bonuses;

    
    public Attribute(int startingValue) : base(startingValue) {
        bonuses = new List<BaseAttribute>();
    }


    /// <summary>
    /// Adds the bonus to the attribute
    /// </summary>
    /// <param name="bonus">The bonus to add</param>
    public void AddBonus(RawBonus bonus) {
        bonuses.Add(bonus);
    }

    /// <summary>
    /// Removes the bonus from the attrubute
    /// </summary>
    /// <param name="bonus">The bonus to remove</param>
    public void RemoveBonus(RawBonus bonus) {
        bonuses.Remove(bonus);
    }

    /// <summary>
    /// Calculates the final value of the attribute
    /// </summary>
    /// <returns>The final value</returns>
    public int CalculateValue() {
        //Start with this attribute's base value
        int finalValue = BaseValue;

        //Collect all of the base values and multipliers
        int bonusValue = 0;
        float bonusMultiplier = 0;

        foreach(BaseAttribute bonus in bonuses) {
            bonusValue += bonus.BaseValue;
            bonusMultiplier += bonus.BaseMultiplier;
        }

        //Add the value and multiplier
        finalValue += bonusValue;
        finalValue = (int)Math.Floor(finalValue * (1 + bonusMultiplier));

        return finalValue;
    }

}
