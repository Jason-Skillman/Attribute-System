using System;
using System.Collections;
using System.Collections.Generic;

public class Attribute : BaseAttribute {

    private List<RawBonus> rawBonuses;
    private List<FinalBonus> finalBonuses;

    private int FinalValue {
        get; set;
    }

    
    public Attribute(int startingValue) : base(startingValue) {
        rawBonuses = new List<RawBonus>();
        finalBonuses = new List<FinalBonus>();

        FinalValue = BaseValue;
    }


    /// <summary>
    /// Adds the raw bonus to the attribute
    /// </summary>
    /// <param name="bonus">The raw bonus to add</param>
    public void AddRawBonus(RawBonus bonus) {
        rawBonuses.Add(bonus);
    }

    /// <summary>
    /// Removes the raw bonus from the attrubute
    /// </summary>
    /// <param name="bonus">The raw bonus to remove</param>
    public void RemoveRawBonus(RawBonus bonus) {
        rawBonuses.Remove(bonus);
    }

    /// <summary>
    /// Adds the final bonus to the attribute
    /// </summary>
    /// <param name="bonus">The final bonus to add</param>
    public void AddFinalBonus(FinalBonus bonus) {
        finalBonuses.Add(bonus);
    }

    /// <summary>
    /// Removes the final bonus from the attrubute
    /// </summary>
    /// <param name="bonus">The final bonus to remove</param>
    public void RemoveFinalBonus(FinalBonus bonus) {
        finalBonuses.Remove(bonus);
    }

    /// <summary>
    /// Calculates the final value of the attribute
    /// </summary>
    /// <returns>The final value</returns>
    public int CalculateValue() {
        FinalValue = BaseValue;

        //Add to FinalValue from raw value
        int rawBonusValue = 0;
        float rawBonusMultiplier = 0;

        foreach(RawBonus bonus in rawBonuses) {
            rawBonusValue += bonus.BaseValue;
            rawBonusMultiplier += bonus.BaseMultiplier;
        }

        FinalValue += rawBonusValue;
        FinalValue = (int)Math.Floor(FinalValue * (1 + rawBonusMultiplier));


        //Add to FinalValue from final value
        int finalBonusValue = 0;
        float finalBonusMultiplier = 0;

        foreach(FinalBonus bonus in finalBonuses) {
            finalBonusValue += bonus.BaseValue;
            finalBonusMultiplier += bonus.BaseMultiplier;
        }

        FinalValue += finalBonusValue;
        FinalValue = (int)Math.Floor(FinalValue * (1 + finalBonusMultiplier));

        return FinalValue;
    }

}
