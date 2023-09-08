using CSI.Data.SQL.UDDT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSI.Data.Utilities
{
    public class EvaluateDatatypesUtil : IEvaluateDatatypesUtil
    {
        readonly IDateTimeUtil dateTimeUtil;
        readonly IDataTypeUtil dataTypeUtil;

        public EvaluateDatatypesUtil(IDateTimeUtil dateTimeUtil,
            IDataTypeUtil dataTypeUtil)
        {
            this.dateTimeUtil = dateTimeUtil;
            this.dataTypeUtil = dataTypeUtil;
        }

        /// <summary>
        /// Overload method to get the precedence of two objects
        /// </summary>
        /// <param name="leftValue">Object</param>
        /// <param name="rightValue">Object</param>
        /// <returns>Higher precedence DataType, Higher precedence DataType, Object with higher precedence, Object with lower precedence, Boolean if left value has higher precedence</returns>
        public (string higherType, string lowerType, object higherValue, object lowerValue, bool isLeftValueHigher) 
            GetPrecedence(object leftValue, object rightValue)
        {
            try
            {
                // Get the datatype of leftValue
                string leftType = leftValue.GetType().FullName;
                bool isUDDTLeftType = dataTypeUtil.IsUDDT(leftType);

                // Cast object if UDDT
                if (isUDDTLeftType)
                {
                    leftType = dataTypeUtil.GetCSType(leftType);
                    leftValue = (leftValue as IUDDTType)?.Value;
                }

                // Get the datatype of rightValue
                string rightType = rightValue.GetType().FullName;
                bool isUDDTRightType = dataTypeUtil.IsUDDT(rightType);

                // Cast object if UDDT
                if (isUDDTRightType)
                {
                    rightType = dataTypeUtil.GetCSType(rightType);
                    rightValue = (rightValue as IUDDTType)?.Value;
                }

                // Get the precedence of two objects
                if ((int)Enum.Parse(typeof(Precedence), leftType.Replace(".", ""))
                    <= (int)Enum.Parse(typeof(Precedence), rightType.Replace(".", "")))
                {
                    // Return if leftValue has higher precedence
                    return (leftType, rightType, leftValue, rightValue, true);
                }

                // Return if rightValue has higher precedence
                return (rightType, leftType, rightValue, leftValue, false);
            }
            catch (Exception ex)
            {
                throw new Exception("EvaluateDatatypesUtil GetPrecedence Error - " + ex.Message);
            }
        }

        /// <summary>
        /// Overload method to get the precedence of one object
        /// </summary>
        /// <param name="value">Object</param>
        /// <returns>Precedent value, Precedence DataType</returns>
        public (int precedence, string type, object convertedValue) GetPrecedence(object value)
        {
            try
            {
                // Get the datatype of object
                string type = value.GetType().FullName;
                bool isUDDTType = dataTypeUtil.IsUDDT(type);

                // Cast object if UDDT
                if (isUDDTType)
                {
                    type = dataTypeUtil.GetCSType(type);
                    value = (value as IUDDTType)?.Value;
                }

                // Get precedence of object
                int precedence = (int)Enum.Parse(typeof(Precedence), type.Replace(".", ""));

                return (precedence, type, value);
            }
            catch (Exception ex)
            {
                throw new Exception("EvaluateDatatypesUtil GetPrecedence Error - " + ex.Message);
            }
        }

        /// <summary>
        /// EvaluateDateTime converts object to DateTime
        /// </summary>
        /// <param name="lowerValue">Object</param>
        /// <param name="lowerPrecedence">DataType of the object</param>
        /// <returns>Nullable DateTime</returns>
        public DateTime? EvaluateDateTime<T>(T lowerValue, string lowerPrecedence)
        {
            string inputValue = string.Empty;
            if (lowerValue is IUDDTType)
                inputValue = (string)ChangeType(((IUDDTType)lowerValue).Value, typeof(string));
            else
                inputValue = (string)ChangeType(lowerValue, typeof(string));

            try
            {
                // Evaluate the datatype of lower precedence object then convert to DateTime
                switch (lowerPrecedence)
                {
                    case "System.DateTime":
                        return Convert.ToDateTime(inputValue);
                    case "System.String":
                        DateTime convertedDate = dateTimeUtil.EmptyValue;

                        if (string.IsNullOrEmpty(inputValue))
                            return convertedDate;

                        string[] formats = dateTimeUtil.DateFormatDictionary();

                        if (DateTime.TryParseExact(inputValue.ToString(), formats, DateTimeFormatInfo.InvariantInfo,
                                     DateTimeStyles.AllowTrailingWhite, out convertedDate))
                            return convertedDate;

                        throw new Exception("Invalid DateTime format");

                    case "System.Double":
                    case "System.Decimal":
                    case "System.Int32":
                    case "System.Int16":
                    case "System.Int64":
                    case "System.Byte":
                        // Plus 2: SQL uses zero-date as 1900-01-01, in C# it uses 1899-12-30
                        return DateTime.FromOADate(Convert.ToDouble(inputValue) + 2);

                    default:
                        throw new Exception("Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EvaluateDateTime Error - " + ex.Message);
            }
        }

        /// <summary>
        /// EvaluateDouble converts object to Double
        /// </summary>
        /// <param name="lowerValue">Object</param>
        /// <param name="lowerPrecedence">DataType of the object</param>
        /// <returns>Nullable Double</returns>
        public double? EvaluateDouble<T>(T lowerValue, string lowerPrecedence)
        {
            double inputValue;
            if (lowerValue is IUDDTType)
                inputValue = (double)ChangeType(((IUDDTType)lowerValue).Value, typeof(double));
            else
                inputValue = (double)ChangeType(lowerValue, typeof(double));

            try
            {
                // Evaluate the datatype of lower precedence object then convert to Double
                switch (lowerPrecedence)
                {

                    case "System.Double":
                    case "System.Decimal":
                    case "System.Int64":
                    case "System.Int32":
                    case "System.Int16":
                    case "System.Byte":
                    case "System.String":
                        return Convert.ToDouble(inputValue);

                    default:
                        throw new Exception("Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EvaluateDouble Error - " + ex.Message);
            }
        }

        /// <summary>
        /// EvaluateDecimal converts object to Decimal
        /// </summary>
        /// <param name="lowerValue">Object</param>
        /// <param name="lowerPrecedence">DataType of the object</param>
        /// <returns>Nullable Decimal</returns>
        public decimal? EvaluateDecimal<T>(T lowerValue, string lowerPrecedence)
        {
            decimal inputValue;
            if (lowerValue is IUDDTType)
                inputValue = (decimal)ChangeType(((IUDDTType)lowerValue).Value, typeof(decimal));
            else
                inputValue = (decimal)ChangeType(lowerValue, typeof(decimal));
            try
            {
                // Evaluate the datatype of lower precedence object then convert to Decimal
                switch (lowerPrecedence)
                {
                    case "System.Decimal":
                    case "System.Int64":
                    case "System.Int32":
                    case "System.Int16":
                    case "System.Byte":
                    case "System.String":
                        return Convert.ToDecimal(inputValue);

                    default:
                        throw new Exception("Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EvaluateDecimal Error - " + ex.Message);
            }
        }

        /// <summary>
        /// EvaluateInt64 converts object to Int64
        /// </summary>
        /// <param name="lowerValue">Object</param>
        /// <param name="lowerPrecedence">DataType of the object</param>
        /// <returns>Nullable Int64</returns>
        public long? EvaluateInt64<T>(T lowerValue, string lowerPrecedence)
        {
            long inputValue;
            if (lowerValue is IUDDTType)
                inputValue = (long)ChangeType(((IUDDTType)lowerValue).Value, typeof(long));
            else
                inputValue = (long)ChangeType(lowerValue, typeof(long));
            try
            {
                // Evaluate the datatype of lower precedence object then convert to Int64
                switch (lowerPrecedence)
                {
                    case "System.Int64":
                    case "System.Int32":
                    case "System.Int16":
                    case "System.Byte":
                    case "System.String":
                        return Convert.ToInt64(inputValue);

                    default:
                        throw new Exception("Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EvaluateInt64 Error - " + ex.Message);
            }
        }

        /// <summary>
        /// EvaluateInt32 converts object to Int32
        /// </summary>
        /// <param name="lowerValue">Object</param>
        /// <param name="lowerPrecedence">DataType of the object</param>
        /// <returns>Nullable Int32</returns>
        public int? EvaluateInt32<T>(T lowerValue, string lowerPrecedence)
        {
            int inputValue;
            if (lowerValue is IUDDTType)
                inputValue = (int)ChangeType(((IUDDTType)lowerValue).Value, typeof(int));
            else
                inputValue = (int)ChangeType(lowerValue, typeof(int));

            try
            {
                // Evaluate the datatype of lower precedence object then convert to Int32
                switch (lowerPrecedence)
                {
                    case "System.Int32":
                    case "System.Int16":
                    case "System.Byte":
                    case "System.String":
                    case "System.Boolean":
                        return Convert.ToInt32(inputValue);

                    default:
                        throw new Exception("Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EvaluateInt32 Error - " + ex.Message);
            }
        }

        /// <summary>
        /// EvaluateInt16 converts object to Int16
        /// </summary>
        /// <param name="lowerValue">Object</param>
        /// <param name="lowerPrecedence">DataType of the object</param>
        /// <returns>Nullable Int16</returns>
        public short? EvaluateInt16<T>(T lowerValue, string lowerPrecedence)
        {
            short inputValue;
            if (lowerValue is IUDDTType)
                inputValue = (short)ChangeType(((IUDDTType)lowerValue).Value, typeof(short));
            else
                inputValue = (short)ChangeType(lowerValue, typeof(short));

            try
            {
                // Evaluate the datatype of lower precedence object then convert to Int16
                switch (lowerPrecedence)
                {
                    case "System.Int16":
                    case "System.Byte":
                    case "System.String":
                        return Convert.ToInt16(inputValue);

                    default:
                        throw new Exception("Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EvaluateInt16 Error - " + ex.Message);
            }
        }

        /// <summary>
        /// EvaluateByte converts object to byte
        /// </summary>
        /// <param name="lowerValue">Object</param>
        /// <param name="lowerPrecedence">DataType of the object</param>
        /// <returns>Nullable Byte</returns>
        public byte? EvaluateByte<T>(T lowerValue, string lowerPrecedence)
        {
            byte inputValue ;
            if (lowerValue is IUDDTType)
                inputValue = (byte)ChangeType(((IUDDTType)lowerValue).Value, typeof(byte));
            else
                inputValue = (byte)ChangeType(lowerValue, typeof(byte));
            try
            {
                // Evaluate the datatype of lower precedence object then convert to Byte
                switch (lowerPrecedence)
                {
                    case "System.String":
                    case "System.Byte":
                        return Convert.ToByte(inputValue);

                    default:
                        throw new Exception("Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EvaluateDouble Error - " + ex.Message);
            }
        }

        /// <summary>
        /// EvaluateBoolean converts object to boolean
        /// </summary>
        /// <param name="lowerValue">Object</param>
        /// <param name="lowerPrecedence">DataType of the object</param>
        /// <returns>Nullable Boolean</returns>
        public Boolean? EvaluateBoolean<T>(T lowerValue, string lowerPrecedence)
        {
            Boolean inputValue;
            if (lowerValue is IUDDTType)
                inputValue = (Boolean)ChangeType(((IUDDTType)lowerValue).Value, typeof(Boolean));
            else
                inputValue = (Boolean)ChangeType(lowerValue, typeof(Boolean));
            try
            {
                // Evaluate the datatype of lower precedence object then convert to Boolean
                switch (lowerPrecedence)
                {
                    case "System.Boolean":
                        return Convert.ToBoolean(inputValue);

                    default:
                        throw new Exception("Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EvaluateBoolean Error - " + ex.Message);
            }
        }
        
        public object ChangeType<T>(T value, Type conversion)
        {
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

            return Convert.ChangeType(value, t);
        }

        enum Precedence
        {
            SystemDataSqlTypesSqlXml = 1,
            SystemDateTime = 2,
            SystemDouble = 3,
            SystemDecimal = 4,
            SystemInt64 = 5,
            SystemInt32 = 6,
            SystemInt16 = 7,
            SystemByte = 8,
            SystemBoolean = 9,
            SystemString = 10,
            SystemChar = 10,
            //byte[] = 11
            SystemGuid = 12
        }

    }
}
