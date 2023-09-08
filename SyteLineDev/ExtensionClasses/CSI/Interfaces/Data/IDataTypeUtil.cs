using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IDataTypeUtil
    {
        string GetCSType(string type);
        bool IsUDDT(string type);
        string[] CSharpDataTypes();
        string GetUDDTFromSQLType(string sqlTtype);
        Type GetType(string typeName);
        string GetSqlNativeType(Type type);
        object ChangeType(object value, Type targetType, string dateTimeFormat = null);
    }
}
