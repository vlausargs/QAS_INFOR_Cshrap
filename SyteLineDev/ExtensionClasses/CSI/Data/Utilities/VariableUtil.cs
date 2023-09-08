using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text;

namespace CSI.Data.Utilities
{
    public class VariableUtil : IVariableUtil
    {
        readonly IDataTypeUtil dataTypeUtil;

        public VariableUtil(IDataTypeUtil dataTypeUtil)
        {
            this.dataTypeUtil = dataTypeUtil;
        }

        private object GetValue(object input, bool withoutQuotes, Type type)
        {
            var uddtBaseType = string.Empty;
            var isUDDT = dataTypeUtil.IsUDDT(type.FullName);

            if (isUDDT)
                uddtBaseType = dataTypeUtil.GetCSType(type.FullName);
            if (input is IUDDTType uDDTInput)
                input = uDDTInput.Value;

            ///For null values
            if (input == null || input is DBNull)
            {
                if (type == typeof(string) || uddtBaseType == "System.String") return withoutQuotes ? input : SqlString.Null;
                if (type == typeof(byte?) || uddtBaseType == "System.Byte") return withoutQuotes ? input : SqlByte.Null;
                if (type == typeof(int?) || uddtBaseType == "System.Int") return withoutQuotes ? input : SqlInt32.Null;
                if (type == typeof(decimal?) || uddtBaseType == "System.Decimal") return withoutQuotes ? input : SqlDecimal.Null;
                if (type == typeof(DateTime?) || uddtBaseType == "System.DateTime") return withoutQuotes ? input : SqlDateTime.Null;
                if (type == typeof(Guid?) || uddtBaseType == "System.Guid") return withoutQuotes ? input : SqlGuid.Null;
                if (type == typeof(char?) || uddtBaseType == "System.Char") return withoutQuotes ? input : SqlString.Null;
            }
            else
            {
                if (type == typeof(string) || uddtBaseType == "System.String") return withoutQuotes ? $"{input}" : IntCheckerForString(input);
                if (type == typeof(DateTime?) || type == typeof(DateTime) || uddtBaseType == "System.DateTime")
                {
                    DateTime inputConverted = (DateTime)input;
                    return withoutQuotes ? $"{inputConverted.ToString("yyyy-MM-dd HH:mm:ss.fff")}" : $"'{inputConverted.ToString("yyyy-MM-dd HH:mm:ss.fff")}'";
                }
                if (type == typeof(Guid?) || type == typeof(Guid) || uddtBaseType == "System.Guid") return withoutQuotes ? $"{input}" : $"'{input}'";
                if (type == typeof(char?) || type == typeof(char) || uddtBaseType == "System.Char") return withoutQuotes ? $"{input}" : $"N'{input}'";
            }

            return input;
        }

        public object GetValue<T>(object input, bool withoutQuotes = false)
        {
            var type = typeof(T);
            return GetValue(input, withoutQuotes, type);
        }

        public object GetValue(object input, bool withoutQuotes = false)
        {
            if (input == null)
                return null;
            var type = input.GetType();
            return GetValue(input, withoutQuotes, type);
        }

        private object IntCheckerForString(object input)
        {
            var type = input.GetType().FullName;
            if (type == "System.Int32")
                return $"'{input}'";
            else
                return $"N'{((string)input).Replace("'", "''")}'";
        }

        public string GetQuotedValue<T>(T input)
        {
            Type type = typeof(T);

            object inputObj = input;

            var uddtBaseType = string.Empty;
            var isUDDT = dataTypeUtil.IsUDDT(type.FullName);

            if (isUDDT)
                uddtBaseType = dataTypeUtil.GetCSType(type.FullName);
            if (input is IUDDTType uddtInput)
                inputObj = uddtInput.Value;

            ///For null values
            if (inputObj == null || inputObj is DBNull)
            {
                return "NULL";
            }
            else
            {
                if (type == typeof(DateTime?) || type == typeof(DateTime) || uddtBaseType == "System.DateTime")
                {
                    DateTime inputConverted = (DateTime)inputObj;
                    return $"'{inputConverted.ToString("yyyy-MM-dd HH:mm:ss.fff")}'";
                }
                else if (type == typeof(string) || uddtBaseType == "System.String")
                {
                    return Convert.ToString(IntCheckerForString(inputObj));
                }
                else if (type == typeof(decimal?) || type == typeof(decimal) || uddtBaseType == "System.Decimal")
                {
                    decimal inputConverted = (decimal)inputObj;
                    return $"'{ inputConverted.ToString("G", CultureInfo.InvariantCulture)}'";
                }
                else if (type == typeof(int?) || type == typeof(int) || uddtBaseType == "System.Int32" ||
                    type == typeof(long?) || type == typeof(long) || uddtBaseType == "System.Int64" ||
                    type == typeof(short?) || type == typeof(short) || uddtBaseType == "System.Int16" ||
                    type == typeof(double?) || type == typeof(double) || uddtBaseType == "System.Double" ||
                    type == typeof(byte?) || type == typeof(byte) || uddtBaseType == "System.Byte")
                {
                    return $"'{ConvertObjectToString(inputObj)}'";
                }
                else if(type == typeof(Guid?) || type == typeof(Guid) || uddtBaseType == "System.Guid")
                {
                    return $"'{ConvertObjectToString(inputObj)}'";
                }
                else
                {
                    return $"N'{ConvertObjectToString(inputObj)}'";
                }
            }
        }

        private string ConvertObjectToString(object input)
        {
            if (input is IUDDTType uDDTType)
                input = uDDTType.Value;

            string inputValue = string.Empty;
            if (input is IUDDTType)
                inputValue = (string)ChangeType(((IUDDTType)input).Value, typeof(string));
            else
                inputValue = (string)ChangeType(input, typeof(string));

            return inputValue;
        }

        private object ChangeType(object value, Type conversion)
        {

            if (value is IUDDTType uDDTType)
                value = uDDTType.Value;

            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            var fullName = value?.GetType().FullName;
            if (fullName != null && (t.FullName.Contains("CSI.Data.SQL.UDDT")
                                     && fullName.Contains("CSI.Data.SQL.UDDT") == false))
            {
                foreach (var constructorInfo in conversion.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
                {
                    try
                    {
                        return constructorInfo.Invoke(new object[] { value });
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            if (value != null && (value.GetType() == typeof(String) && conversion == typeof(Char)))
            {
                string stringValue = (string)value;

                if (int.TryParse(stringValue, out _))
                {
                    if (char.IsDigit(stringValue[stringValue.Length - 1]))
                        return stringValue[stringValue.Length - 1];
                    else
                        return stringValue[0];
                }
            }

            if (conversion == typeof(Guid))
                return Guid.Parse(value as string);
            if (value is Guid)
                value = Convert.ToString(value);

            return Convert.ChangeType(value, t);
        }
    }
}
