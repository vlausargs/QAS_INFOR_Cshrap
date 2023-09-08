using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IEvaluateDatatypesUtil
    {
        (int precedence, string type, object convertedValue) GetPrecedence(object value);
        (string higherType, string lowerType, object higherValue, object lowerValue, bool isLeftValueHigher) GetPrecedence(object leftValue, object rightValue);
        DateTime? EvaluateDateTime<T>(T lowerValue, string lowerPrecedence);
        double? EvaluateDouble<T>(T lowerValue, string lowerPrecedence);
        decimal? EvaluateDecimal<T>(T lowerValue, string lowerPrecedence);
        long? EvaluateInt64<T>(T lowerValue, string lowerPrecedence);
        int? EvaluateInt32<T>(T lowerValue, string lowerPrecedence);
        short? EvaluateInt16<T>(T lowerValue, string lowerPrecedence);
        byte? EvaluateByte<T>(T lowerValue, string lowerPrecedence);
        Boolean? EvaluateBoolean<T>(T lowerValue, string lowerPrecedence);
        object ChangeType<T>(T value, Type conversion);
    }
}
