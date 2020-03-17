using System.Collections;
using System.Collections.Generic;

public class BaseAttribute {

    public int BaseValue {
        get; private set;
    }

    public int BaseMultiplier {
        get; private set;
    }


    public BaseAttribute(int value, int multiplier = 0) {
        BaseValue = value;
        BaseMultiplier = multiplier;
    }

}
