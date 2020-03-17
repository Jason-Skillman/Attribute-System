using System;
using System.Collections;
using System.Collections.Generic;

public class DependantAttribute : Attribute {

    private Dictionary<BaseAttribute, int> requirements;


    public DependantAttribute(int baseValue) : base(baseValue) {
        requirements = new Dictionary<BaseAttribute, int>();
    }


    public void AddBonus(BaseAttribute bonus, int requirement) {
        requirements.Add(bonus, requirement);
        base.AddBonus(bonus);
    }

    public override void RemoveBonus(BaseAttribute bonus) {
        requirements.Remove(bonus);
        base.RemoveBonus(bonus);
    }

    public override int CalculateValue() {
        //Start with this attribute's base value
        FinalValue = BaseValue;

        //Collect all of the base values and multipliers
        int bonusValue = 0;
        float bonusMultiplier = 0;

        foreach(BaseAttribute bonus in bonuses) {
            //If the attribute is another attribute then get the final value instead
            if(bonus.GetType().Equals(typeof(Attribute))) {
                Attribute attribute = (Attribute)bonus;

                int amountRequired;
                if(requirements.TryGetValue(bonus, out amountRequired))
                    FinalValue += (attribute.CalculateValue() / amountRequired);
                else
                    FinalValue += attribute.CalculateValue();
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
