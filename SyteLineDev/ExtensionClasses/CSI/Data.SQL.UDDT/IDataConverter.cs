using System;

namespace CSI.Data.SQL.UDDT
{
    public interface IDataConverter
    {
        string ToString(object val);
        int ToInt(object val);
        decimal ToDecimal(object val);
        bool ToBool(object val);
        long ToLong(object val);
        short ToShort(object val);
        double ToDouble(object val);
        float ToFloat(object val);
        byte ToByte(object val);
        Guid ToGuid(object val);
        T ToGeneric<T>(object val);
        T ToGeneric<T>(object v, T valueWhenNull) where T : struct;
        T ChangeType<T>(object value);
    }
}
