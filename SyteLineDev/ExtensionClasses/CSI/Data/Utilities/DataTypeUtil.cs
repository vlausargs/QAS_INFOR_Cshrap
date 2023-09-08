using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSI.Data.Utilities
{
    public class DataTypeUtil : IDataTypeUtil
    {
        public string GetCSType(string type)
        {
            try
            {
                string typeFullName = type.Contains("CSI.Data.SQL.UDDT") ? type : $"CSI.Data.SQL.UDDT.{type}";
                Type desc = GetType(typeFullName);
                var opImplicitType =
                    desc.GetMembers().FirstOrDefault(x => x.ToString().IndexOf("op_Implicit", StringComparison.Ordinal) > 0);
                string _type = desc.GetMembers()[0].ToString();
                if (opImplicitType != null)
                {
                    _type = opImplicitType.ToString();
                }

                if (_type.Contains("String"))
                {
                    int trimStart = _type.IndexOf("op_Implicit") + 12;
                    int trimEnd = _type.Length - trimStart - 1;
                    _type = _type.Substring(trimStart, trimEnd);

                    return Type.GetType(_type).FullName;
                }
                else
                {
                    var startIndex = _type.IndexOf("[System.") + 1;
                    var firstSubstring = _type.Substring(startIndex, _type.Length - startIndex);
                    var endIndex = firstSubstring.IndexOf("]");
                    var typeString = firstSubstring.Substring(0, endIndex);

                    return typeString;
                }
            }
            catch
            {
                throw new Exception("Invalid UDDT");
            }
        }

        public bool IsUDDT(string type)
        {
            string[] datatypes = CSharpDataTypes();
            return !(datatypes.Any(type.Contains));
        }

        public string[] CSharpDataTypes()
        {
            string[] datatypes = {
                       "System.Boolean"
                     , "System.Byte"
                     , "System.SByte"
                     , "System.Char"
                     , "System.Decimal"
                     , "System.Double"
                     , "System.Single"
                     , "System.Int32"
                     , "System.UInt32"
                     , "System.Int64"
                     , "System.UInt64"
                     , "System.Int16"
                     , "System.UInt16"
                     , "System.String"
                     , "System.DateTime"
                     , "System.Guid"
            };

            return datatypes;
        }

        public string GetUDDTFromSQLType(string sqlTtype)
        {
            try
            {
                string typeFullName = sqlTtype.Contains("CSI.Data.SQL.UDDT") ? sqlTtype : $"CSI.Data.SQL.UDDT.{sqlTtype}";
                Type desc = GetType(typeFullName);

                if (desc != null)
                    return desc.FullName.Replace(desc.Namespace + ".", "");
                else
                    return SQLBaseTypeGenericType(sqlTtype);
            }
            catch
            {
                return SQLBaseTypeGenericType(sqlTtype);
            }

        }
        private string SQLBaseTypeGenericType(string type)
        {
            if (type.ToLower().Contains("bit"))
                return "IntType";
            if (type.ToLower().Contains("tinyint"))
                return "IntType";
            if (type.ToLower().Contains("varbinary"))
                return "BinaryType";
            if (type.ToLower().Contains("binary"))
                return "BinaryType";
            if (type.ToLower().Contains("datetimeoffset"))
                return "DateTimeOffsetType";
            if (type.ToLower().Contains("datetime"))
                return "DateTimeType";
            if (type.ToLower().Contains("date"))
                return "DateTimeType";
            if (type.ToLower().Contains("decimal"))
                return "DecimalType";
            if (type.ToLower().Contains("money"))
                return "DecimalType";
            if (type.ToLower().Contains("smallmoney"))
                return "DecimalType";
            if (type.ToLower().Contains("float"))
                return "DecimalType";
            if (type.ToLower().Contains("uniqueidentifier"))
                return "GuidType";
            if (type.ToLower().Contains("bigint"))
                return "LongType";
            if (type.ToLower().Contains("int"))
                return "IntType";
            if (type.ToLower().Contains("smallint"))
                return "IntType";
            if (type.ToLower().Contains("char"))
                return "StringType";
            if (type.ToLower().Contains("nchar"))
                return "StringType";
            if (type.ToLower().Contains("ntext"))
                return "StringType";
            if (type.ToLower().Contains("text"))
                return "StringType";
            if (type.ToLower().Contains("nvarchar"))
                return "StringType";
            if (type.ToLower().Contains("varchar"))
                return "StringType";
            if (type.ToLower().Contains("sysname"))
                return "StringType";
            if (type.ToLower().Contains("real"))
                return "DecimalType";
            if (type.ToLower().Contains("numeric"))
                return "DecimalType";
            if (type.ToLower().Contains("image"))
                return "BinaryType";
            if (type.ToLower().Contains("time"))
                return "DateTimeType";
            if (type.ToLower().Contains("xml"))
                return "SqlXmlType";
            else
                return "/* " + type + " DATATYPE NOT FOUND*/";
        }

        public Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName, false, true);
                if (type != null)
                    return type;
            }
            return null;
        }
        public string GetSqlNativeType(Type type)
        {
            var result = "";

            try
            {
                Type baseType = type.BaseType;
                switch (baseType)
                {
                    case Type _ when baseType == typeof(ShortType):
                    case Type _ when baseType == typeof(LongType):
                    case Type _ when baseType == typeof(ByteType):
                    case Type _ when baseType == typeof(IntType):
                        result = $"int";
                        break;

                    case Type _ when baseType == typeof(BooleanType):
                        result = $"bit";
                        break;

                    case Type _ when baseType == typeof(BinaryType):
                        result = $"binary";
                        break;

                    case Type _ when baseType == typeof(DateTimeType):
                        result = $"datetime";
                        break;

                    case Type _ when baseType == typeof(FloatType):
                        result = $"float";
                        break;

                    case Type _ when baseType == typeof(GuidType):
                        result = $"uniqueidentifier";
                        break;

                    case Type _ when baseType == typeof(SqlXmlType):
                        result = $"xml";
                        break;

                    case Type _ when baseType == typeof(StringType):
                        object stringObj = Activator.CreateInstance(type, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public, null, new object[] { null }, null);
                        if (stringObj is IUDDTType uDDTType)
                        {
                            int length = uDDTType.Length;
                            if (length == -1)
                                result = $"nvarchar(max)";
                            else
                                result = $"nvarchar({length / 2})";
                        }
                        break;

                    case Type _ when baseType == typeof(DecimalType):
                        object decimalObj = Activator.CreateInstance(type, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public, null, new object[] { null }, null);
                        if (decimalObj is IUDDTType decimalUDDTType)
                        {
                            int precision = decimalUDDTType.Precision;
                            int Scale = decimalUDDTType.Scale;
                            result = $"decimal({precision},{Scale})";
                        }
                        break;
                }
            }
            catch
            {
                result = "nvarchar(max)";
            }



            return result;
        }

        public Type NewMethod(Type type)
        {
            return type.BaseType;
        }

        public object ChangeType(object value, Type targetType, string dateTimeFormat = null)
        {
            if (targetType ==null)
                return null;

            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                    return null;

                targetType = Nullable.GetUnderlyingType(targetType);
            }

            var fullName = value?.GetType().FullName;
            if (targetType.FullName.Contains("CSI.Data.SQL.UDDT"))
            {
                if ((fullName != null && fullName.Contains("CSI.Data.SQL.UDDT") == false)
                    ||(value == null))
                {
                    foreach (var constructorInfo in targetType.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
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
            }

            if (value is IUDDTType newValue)
                value = newValue.Value;

            if (value != null && (value.GetType() == typeof(String) && targetType == typeof(Char)))
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

            if (targetType == typeof(Guid))
                return Guid.Parse(value as string);

            if (value is string stringEmptyValue && targetType == typeof(DateTime))
            {
                if (stringEmptyValue == "")
                    return DateTime.Parse("1900-01-01 00:00:00.000");
                return DateTime.ParseExact(stringEmptyValue, dateTimeFormat, DateTimeFormatInfo.InvariantInfo);
            }

            return Convert.ChangeType(value, targetType);
        }

    }
}
