using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface ISQLValueComparerUtil
    {
        bool? SQLEqual<T1, T2>(T1 leftValue, T2 rightValue);
        bool? SQLNotEqual<T1, T2>(T1 leftValue, T2 rightValue);
        bool? SQLLessThan<T1, T2>(T1 leftValue, T2 rightValue);
        bool? SQLLessThanOrEqual<T1, T2>(T1 leftValue, T2 rightValue);
        bool? SQLGreaterThan<T1, T2>(T1 leftValue, T2 rightValue);
        bool? SQLGreaterThanOrEqual<T1, T2>(T1 leftValue, T2 rightValue);
        bool? SQLBetween<T1, T2, T3>(T1 firstValue, T2 secondValue, T3 thirdValue);
        bool? SQLAnd(bool? leftValue, bool? rightValue);
        bool? SQLOr(bool? leftValue, bool? rightValue);
        bool? SQLNot(bool? value);
        bool SQLBool(bool? value);
        bool? SQLNotBetween<T1, T2, T3>(T1 firstValue, T2 secondValue, T3 thirdValue);
        T CaseWhen<T>(bool whenCondition, object thenExpression, object elseExpression = null);
    }
}
