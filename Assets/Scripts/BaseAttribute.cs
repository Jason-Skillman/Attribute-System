using System.Collections;
using System.Collections.Generic;

public class BaseAttribute {

    public int BaseValue {
        get; private set;
    }

    public int BaseMultiplier {
        get; private set;
    }


    public BaseAttribute(int baseValue, int baseMultiplier = 0) {
        BaseValue = baseValue;
        BaseMultiplier = baseMultiplier;
    }

}
