using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IConvertToUtil
    {
        //decimal? ToDecimal(object value);
        decimal? ToDecimal<T>(T value);
        //int? ToInt32(object value);
        int? ToInt32<T>(T value);
        //long? ToInt64(object value);
        long? ToInt64<T>(T value);
        //bool? ToBoolean(object value);
        bool? ToBoolean<T>(T value);
        //DateTime? ToDateTime(object value);
        DateTime? ToDateTime<T>(T value);
        //string ToString(object value);
        string ToString<T>(T value);
        //string ToString(object value, object style);
        string ToString<T>(T value, object style);
        //Guid? ToGuid(object value);
        Guid? ToGuid<T>(T value);
    }
}
