using System.Collections;
using System.Collections.Generic;

public abstract class BaseAttribute {

    public int BaseValue {
        get; private set;
    }

    public float BaseMultiplier {
        get; private set;
    }


    public BaseAttribute(int value, float multiplier = 0) {
        BaseValue = value;
        BaseMultiplier = multiplier;
    }

}
