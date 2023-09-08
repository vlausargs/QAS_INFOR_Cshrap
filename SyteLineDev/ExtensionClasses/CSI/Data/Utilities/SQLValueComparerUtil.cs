using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSI.Data.Utilities
{
    /// <summary>
    /// These functions follow the behavior of SQL comparison operators. 
    /// </summary>
    public class SQLValueComparerUtil : ISQLValueComparerUtil
    {
        readonly IEvaluateDatatypesUtil evaluateDatatypes;

        public SQLValueComparerUtil(IEvaluateDatatypesUtil evaluateDatatypes)
        {
            this.evaluateDatatypes = evaluateDatatypes;
        }

        /// <summary>
        /// SQLEqual compares two object if equal to each other
        /// </summary>
        /// <param name="leftValue">Object</param>
        /// <param name="rightValue">Object</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLEqual<T1,T2>(T1 leftValue, T2 rightValue)
        {
            try
            {
                object leftValueObj = leftValue;
                object rightValueObj = rightValue;

                //  If one object is NULL, return NULL.
                if (leftValue is IUDDTType leftValueUDDT){ leftValueObj = leftValueUDDT.Value; }
                if (rightValue is IUDDTType rightValueUDDT) { rightValueObj = rightValueUDDT.Value; }
                if (leftValueObj is null) { return null; }
                if (rightValueObj is null) { return null; }

                string higherType;
                string lowerType;
                object higherValue;
                object lowerValue;
                bool isLeftValueHigher;

                // For objects with different datatypes, datatype precedence must be followed for conversion.
                // Returns the precedence of each object and determine which has higher precedence
                (higherType, lowerType, higherValue, lowerValue, isLeftValueHigher) =
                    evaluateDatatypes.GetPrecedence(leftValueObj, rightValueObj);

                // Evaluate the datatype of higher precedence object 
                switch (higherType)
                {
                    case "System.DateTime":
                        DateTime? convertedHigherDateTime = Convert.ToDateTime(higherValue);
                        DateTime? convertedLowerDateTime;

                        // Evaluate datatype of lower precedence object and returns converted DateTime 
                        convertedLowerDateTime =
                            evaluateDatatypes.EvaluateDateTime(lowerValue, lowerType);

                        return Equals(convertedHigherDateTime, convertedLowerDateTime);

                    case "System.Double":
                        double? convertedHigherDouble = Convert.ToDouble(higherValue);
                        double? convertedLowerDouble;

                        // Evaluate datatype of lower precedence object and returns converted Double 
                        convertedLowerDouble = evaluateDatatypes.EvaluateDouble(lowerValue, lowerType);

                        return Equals(convertedHigherDouble, convertedLowerDouble);

                    case "System.Decimal":
                        decimal? convertedHigherDecimal = Convert.ToDecimal(higherValue);
                        decimal? convertedLowerDecimal;

                        // Evaluate datatype of lower precedence object and returns converted Decimal 
                        convertedLowerDecimal = evaluateDatatypes.EvaluateDecimal(lowerValue, lowerType);

                        return Equals(convertedHigherDecimal, convertedLowerDecimal);

                    case "System.Int64":
                        long? convertedHigherInt64 = Convert.ToInt64(higherValue);
                        long? convertedLowerInt64;

                        // Evaluate datatype of lower precedence object and returns converted Int64
                        convertedLowerInt64 = evaluateDatatypes.EvaluateInt64(lowerValue, lowerType);

                        return Equals(convertedHigherInt64, convertedLowerInt64);

                    case "System.Int32":
                        int? convertedHigherInt32 = Convert.ToInt32(higherValue);
                        int? convertedLowerInt32;

                        // Evaluate datatype of lower precedence object and returns converted Int32
                        convertedLowerInt32 = evaluateDatatypes.EvaluateInt32(lowerValue, lowerType);

                        return Equals(convertedHigherInt32, convertedLowerInt32);

                    case "System.Int16":
                        short? convertedHigherInt16 = Convert.ToInt16(higherValue);
                        short? convertedLowerInt16;

                        // Evaluate datatype of lower precedence object and returns converted Int16
                        convertedLowerInt16 =evaluateDatatypes.EvaluateInt16(lowerValue, lowerType);

                        return Equals(convertedHigherInt16, convertedLowerInt16);

                    case "System.Byte":
                        byte? convertedHigherByte = Convert.ToByte(higherValue);
                        byte? convertedLowerByte;

                        // Evaluate datatype of lower precedence object and returns converted Byte
                        convertedLowerByte = evaluateDatatypes.EvaluateByte(lowerValue, lowerType);

                        return Equals(convertedHigherByte, convertedLowerByte);

                    case "System.Boolean":
                        Boolean? convertedHigherBool = Convert.ToBoolean(higherValue);
                        Boolean? convertedLowerBool;

                        // Evaluate datatype of lower precedence object and returns converted Boolean
                        convertedLowerBool = evaluateDatatypes.EvaluateBoolean(lowerValue, lowerType);

                        return Equals(convertedHigherBool, convertedLowerBool);

                    case "System.String":
                    case "System.Guid":
                        return string.Equals(Convert.ToString(higherValue), Convert.ToString(lowerValue),
                       StringComparison.InvariantCultureIgnoreCase);

                    default:
                        throw new Exception("SQLValueComparerUtil SQLEqual Error - Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SQLNotEqual compares two object if not equal to each other
        /// </summary>
        /// <param name="leftValue">Object</param>
        /// <param name="rightValue">Object</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLNotEqual<T1, T2>(T1 leftValue, T2 rightValue)
        {
            object leftValueObj = leftValue;
            object rightValueObj = rightValue;
            try
            {
                //  If one object is NULL, return NULL.
                if (leftValue is IUDDTType leftValueUDDT) { leftValueObj = leftValueUDDT.Value; }
                if (rightValue is IUDDTType rightValueUDDT) { rightValueObj = rightValueUDDT.Value; }
                if (leftValueObj is null) { return null; }
                if (rightValueObj is null) { return null; }

                string higherType;
                string lowerType;
                object higherValue;
                object lowerValue;
                bool isLeftValueHigher;


                // For objects with different datatypes, datatype precedence must be followed for conversion.
                // Returns the precedence of each object and determine which has higher precedence
                (higherType, lowerType, higherValue, lowerValue, isLeftValueHigher) =
                    evaluateDatatypes.GetPrecedence(leftValueObj, rightValueObj);

                // Evaluate the datatype of higher precedence object 
                switch (higherType)
                {
                    case "System.DateTime":
                        DateTime? convertedHigherDateTime = Convert.ToDateTime(higherValue);
                        DateTime? convertedLowerDateTime;

                        // Evaluate datatype of lower precedence object and returns converted DateTime 
                        convertedLowerDateTime =
                            evaluateDatatypes.EvaluateDateTime(lowerValue, lowerType);

                        return convertedHigherDateTime != convertedLowerDateTime;

                    case "System.Double":
                        double? convertedHigherDouble = Convert.ToDouble(higherValue);
                        double? convertedLowerDouble;

                        // Evaluate datatype of lower precedence object and returns converted Double 
                        convertedLowerDouble = evaluateDatatypes.EvaluateDouble(lowerValue, lowerType);

                        return convertedHigherDouble != convertedLowerDouble;

                    case "System.Decimal":
                        decimal? convertedHigherDecimal = Convert.ToDecimal(higherValue);
                        decimal? convertedLowerDecimal;

                        // Evaluate datatype of lower precedence object and returns converted Decimal 
                        convertedLowerDecimal = evaluateDatatypes.EvaluateDecimal(lowerValue, lowerType);

                        return convertedHigherDecimal != convertedLowerDecimal;

                    case "System.Int64":
                        long? convertedHigherInt64 = Convert.ToInt64(higherValue);
                        long? convertedLowerInt64;

                        // Evaluate datatype of lower precedence object and returns converted Int64 
                        convertedLowerInt64 = evaluateDatatypes.EvaluateInt64(lowerValue, lowerType);

                        return convertedHigherInt64 != convertedLowerInt64;

                    case "System.Int32":
                        int? convertedHigherInt32 = Convert.ToInt32(higherValue);
                        int? convertedLowerInt32;

                        // Evaluate datatype of lower precedence object and returns converted Int32 
                        convertedLowerInt32 = evaluateDatatypes.EvaluateInt32(lowerValue, lowerType);

                        return convertedHigherInt32 != convertedLowerInt32;

                    case "System.Int16":
                        short? convertedHigherInt16 = Convert.ToInt16(higherValue);
                        short? convertedLowerInt16;

                        // Evaluate datatype of lower precedence object and returns converted Int16 
                        convertedLowerInt16 = evaluateDatatypes.EvaluateInt16(lowerValue, lowerType);

                        return convertedHigherInt16 != convertedLowerInt16;

                    case "System.Byte":
                        byte? convertedHigherByte = Convert.ToByte(higherValue);
                        byte? convertedLowerByte;

                        // Evaluate datatype of lower precedence object and returns converted Byte
                        convertedLowerByte =evaluateDatatypes.EvaluateByte(lowerValue, lowerType);

                        return convertedHigherByte != convertedLowerByte;

                    case "System.Boolean":
                        Boolean? convertedHigherBool = Convert.ToBoolean(higherValue);
                        Boolean? convertedLowerBool;

                        // Evaluate datatype of lower precedence object and returns converted Boolean
                        convertedLowerBool = evaluateDatatypes.EvaluateBoolean(lowerValue, lowerType);

                        return convertedHigherBool != convertedLowerBool;

                    case "System.String":
                    case "System.Guid":
                        // Less than zero strA precedes strB in the sort order.
                        // Zero strA occurs in the same position as strB in the sort order.
                        // Greater than zero strA follows strB in the sort order.
                        int result = string.Compare(Convert.ToString(leftValueObj), Convert.ToString(rightValueObj), true);
                        if (result != 0)
                            return true;
                        return false;

                    default:
                        throw new Exception("SQLValueComparerUtil SQLNotEqual Error - Datatype not handled");

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SQLLessThan compares if leftValue is less than rightValue
        /// </summary>
        /// <param name="leftValue">Object</param>
        /// <param name="rightValue">Object</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLLessThan<T1, T2>(T1 leftValue, T2 rightValue)
        {
            object leftValueObj = leftValue;
            object rightValueObj = rightValue;
            try
            {
                //  If one object is NULL, return NULL.
                if (leftValue is IUDDTType leftValueUDDT) { leftValueObj = leftValueUDDT.Value; }
                if (rightValue is IUDDTType rightValueUDDT) { rightValueObj = rightValueUDDT.Value; }
                if (leftValueObj is null) { return null; }
                if (rightValueObj is null) { return null; }

                string higherType;
                string lowerType;
                object higherValue;
                object lowerValue;
                bool isLeftValueHigher;

                // For objects with different datatypes, datatype precedence must be followed for conversion.
                // Returns the precedence of each object and determine which has higher precedence
                (higherType, lowerType, higherValue, lowerValue, isLeftValueHigher) =
                    evaluateDatatypes.GetPrecedence(leftValueObj, rightValueObj);

                // Evaluate the datatype of higher precedence object 
                switch (higherType)
                {
                    case "System.DateTime":
                        DateTime? convertedHigherDateTime = Convert.ToDateTime(higherValue);
                        DateTime? convertedLowerDateTime;

                        // Evaluate datatype of lower precedence object and returns converted DateTime 
                        convertedLowerDateTime =
                            evaluateDatatypes.EvaluateDateTime(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDateTime < convertedLowerDateTime;

                        return convertedLowerDateTime < convertedHigherDateTime;

                    case "System.Double":
                        double? convertedHigherDouble = Convert.ToDouble(higherValue);
                        double? convertedLowerDouble;

                        // Evaluate datatype of lower precedence object and returns converted Double 
                        convertedLowerDouble = evaluateDatatypes.EvaluateDouble(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDouble < convertedLowerDouble;

                        return convertedLowerDouble < convertedHigherDouble;

                    case "System.Decimal":
                        decimal? convertedHigherDecimal = Convert.ToDecimal(higherValue);
                        decimal? convertedLowerDecimal;

                        // Evaluate datatype of lower precedence object and returns converted Decimal 
                        convertedLowerDecimal = evaluateDatatypes.EvaluateDecimal(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDecimal < convertedLowerDecimal;

                        return convertedLowerDecimal < convertedHigherDecimal;

                    case "System.Int64":
                        long? convertedHigherInt64 = Convert.ToInt64(higherValue);
                        long? convertedLowerInt64;

                        // Evaluate datatype of lower precedence object and returns converted Int64 
                        convertedLowerInt64 = evaluateDatatypes.EvaluateInt64(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt64 < convertedLowerInt64;

                        return convertedLowerInt64 < convertedHigherInt64;

                    case "System.Int32":
                        int? convertedHigherInt32 = Convert.ToInt32(higherValue);
                        int? convertedLowerInt32;

                        // Evaluate datatype of lower precedence object and returns converted Int32
                        convertedLowerInt32 = evaluateDatatypes.EvaluateInt32(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt32 < convertedLowerInt32;

                        return convertedLowerInt32 < convertedHigherInt32;

                    case "System.Int16":
                        short? convertedHigherInt16 = Convert.ToInt16(higherValue);
                        short? convertedLowerInt16;

                        // Evaluate datatype of lower precedence object and returns converted Int16
                        convertedLowerInt16 = evaluateDatatypes.EvaluateInt16(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt16 < convertedLowerInt16;

                        return convertedLowerInt16 < convertedHigherInt16;

                    case "System.Byte":
                        byte? convertedHigherByte = Convert.ToByte(higherValue);
                        byte? convertedLowerByte;

                        // Evaluate datatype of lower precedence object and returns converted Byte
                        convertedLowerByte = evaluateDatatypes.EvaluateByte(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherByte < convertedLowerByte;

                        return convertedLowerByte < convertedHigherByte;

                    case "System.String":

                        // Less than zero strA precedes strB in the sort order.
                        // Zero strA occurs in the same position as strB in the sort order.
                        // Greater than zero strA follows strB in the sort order.
                        int result = string.Compare(Convert.ToString(leftValueObj), Convert.ToString(rightValueObj), true);
                        if (result < 0)
                            return true;
                        return false;

                    default:
                        throw new Exception("SQLValueComparerUtil SQLLessThan Error - Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SQLLessThanOrEqual compares if leftValue is less than or equal to rightValue
        /// </summary>
        /// <param name="leftValue">Object</param>
        /// <param name="rightValue">Object</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLLessThanOrEqual<T1, T2>(T1 leftValue, T2 rightValue)
        {
            object leftValueObj = leftValue;
            object rightValueObj = rightValue;

            try
            {
                //  If one object is NULL, return NULL.
                if (leftValue is IUDDTType leftValueUDDT) { leftValueObj = leftValueUDDT.Value; }
                if (rightValue is IUDDTType rightValueUDDT) { rightValueObj = rightValueUDDT.Value; }
                if (leftValueObj is null) { return null; }
                if (rightValueObj is null) { return null; }

                string higherType;
                string lowerType;
                object higherValue;
                object lowerValue;
                bool isLeftValueHigher;

                // For objects with different datatypes, datatype precedence must be followed for conversion.
                // Returns the precedence of each object and determine which has higher precedence
                (higherType, lowerType, higherValue, lowerValue, isLeftValueHigher) =
                    evaluateDatatypes.GetPrecedence(leftValueObj, rightValueObj);

                // Evaluate the datatype of higher precedence object 
                switch (higherType)
                {
                    case "System.DateTime":
                        DateTime? convertedHigherDateTime = Convert.ToDateTime(higherValue);
                        DateTime? convertedLowerDateTime;

                        // Evaluate datatype of lower precedence object and returns converted DateTime 
                        convertedLowerDateTime =
                            evaluateDatatypes.EvaluateDateTime(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDateTime <= convertedLowerDateTime;

                        return convertedLowerDateTime <= convertedHigherDateTime;

                    case "System.Double":
                        double? convertedHigherDouble = Convert.ToDouble(higherValue);
                        double? convertedLowerDouble;

                        // Evaluate datatype of lower precedence object and returns converted Double 
                        convertedLowerDouble = evaluateDatatypes.EvaluateDouble(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDouble <= convertedLowerDouble;

                        return convertedLowerDouble <= convertedHigherDouble;

                    case "System.Decimal":
                        decimal? convertedHigherDecimal = Convert.ToDecimal(higherValue);
                        decimal? convertedLowerDecimal;

                        // Evaluate datatype of lower precedence object and returns converted Decimal 
                        convertedLowerDecimal = evaluateDatatypes.EvaluateDecimal(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDecimal <= convertedLowerDecimal;

                        return convertedLowerDecimal <= convertedHigherDecimal;

                    case "System.Int64":
                        long? convertedHigherInt64 = Convert.ToInt64(higherValue);
                        long? convertedLowerInt64;

                        // Evaluate datatype of lower precedence object and returns converted Int64
                        convertedLowerInt64 = evaluateDatatypes.EvaluateInt64(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt64 <= convertedLowerInt64;

                        return convertedLowerInt64 <= convertedHigherInt64;

                    case "System.Int32":
                        int? convertedHigherInt32 = Convert.ToInt32(higherValue);
                        int? convertedLowerInt32;

                        // Evaluate datatype of lower precedence object and returns converted Int32
                        convertedLowerInt32 = evaluateDatatypes.EvaluateInt32(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt32 <= convertedLowerInt32;

                        return convertedLowerInt32 <= convertedHigherInt32;

                    case "System.Int16":
                        short? convertedHigherInt16 = Convert.ToInt16(higherValue);
                        short? convertedLowerInt16;

                        // Evaluate datatype of lower precedence object and returns converted Int16
                       convertedLowerInt16 = evaluateDatatypes.EvaluateInt16(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt16 <= convertedLowerInt16;

                        return convertedLowerInt16 <= convertedHigherInt16;

                    case "System.Byte":
                        byte? convertedHigherByte = Convert.ToByte(higherValue);
                        byte? convertedLowerByte;

                        // Evaluate datatype of lower precedence object and returns converted Byte
                        convertedLowerByte = evaluateDatatypes.EvaluateByte(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherByte <= convertedLowerByte;

                        return convertedLowerByte <= convertedHigherByte;

                    case "System.String":

                        // Less than zero strA precedes strB in the sort order.
                        // Zero strA occurs in the same position as strB in the sort order.
                        // Greater than zero strA follows strB in the sort order.
                        int result = string.Compare(Convert.ToString(leftValueObj), Convert.ToString(rightValueObj), true);
                        if (result <= 0)
                            return true;
                        return false;

                    default:
                        throw new Exception("SQLValueComparerUtil SQLLessThanOrEqual Error - Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SQLGreaterThan compares if leftValue is greater than rightValue
        /// </summary>
        /// <param name="leftValue">Object</param>
        /// <param name="rightValue">Object</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLGreaterThan<T1, T2>(T1 leftValue, T2 rightValue)
        {
            object leftValueObj = leftValue;
            object rightValueObj = rightValue;
            try
            {
                //  If one object is NULL, return NULL.
                if (leftValue is IUDDTType leftValueUDDT) { leftValueObj = leftValueUDDT.Value; }
                if (rightValue is IUDDTType rightValueUDDT) { rightValueObj = rightValueUDDT.Value; }
                if (leftValueObj is null) { return null; }
                if (rightValueObj is null) { return null; }

                string higherType;
                string lowerType;
                object higherValue;
                object lowerValue;
                bool isLeftValueHigher;

                // For objects with different datatypes, datatype precedence must be followed for conversion.
                // Returns the precedence of each object and determine which has higher precedence
                (higherType, lowerType, higherValue, lowerValue, isLeftValueHigher) =
                    evaluateDatatypes.GetPrecedence(leftValueObj, rightValueObj);

                // Evaluate the datatype of higher precedence object 
                switch (higherType)
                {
                    case "System.DateTime":
                        DateTime? convertedHigherDateTime = Convert.ToDateTime(higherValue);
                        DateTime? convertedLowerDateTime;

                        // Evaluate datatype of lower precedence object and returns converted DateTime 
                        convertedLowerDateTime =
                             evaluateDatatypes.EvaluateDateTime(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDateTime > convertedLowerDateTime;

                        return convertedLowerDateTime > convertedHigherDateTime;


                    case "System.Double":
                        double? convertedHigherDouble = Convert.ToDouble(higherValue);
                        double? convertedLowerDouble;

                        // Evaluate datatype of lower precedence object and returns converted Double 
                        convertedLowerDouble = evaluateDatatypes.EvaluateDouble(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDouble > convertedLowerDouble;

                        return convertedLowerDouble > convertedHigherDouble;

                    case "System.Decimal":
                        decimal? convertedHigherDecimal = Convert.ToDecimal(higherValue);
                        decimal? convertedLowerDecimal;

                        // Evaluate datatype of lower precedence object and returns converted Decimal 
                        convertedLowerDecimal = evaluateDatatypes.EvaluateDecimal(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDecimal > convertedLowerDecimal;

                        return convertedLowerDecimal > convertedHigherDecimal;

                    case "System.Int64":
                        long? convertedHigherInt64 = Convert.ToInt64(higherValue);
                        long? convertedLowerInt64;

                        // Evaluate datatype of lower precedence object and returns converted Int64 
                        convertedLowerInt64 = evaluateDatatypes.EvaluateInt64(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt64 > convertedLowerInt64;

                        return convertedLowerInt64 > convertedHigherInt64;

                    case "System.Int32":
                        int? convertedHigherInt32 = Convert.ToInt32(higherValue);
                        int? convertedLowerInt32;

                        // Evaluate datatype of lower precedence object and returns converted Int32 
                        convertedLowerInt32 = evaluateDatatypes.EvaluateInt32(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt32 > convertedLowerInt32;

                        return convertedLowerInt32 > convertedHigherInt32;

                    case "System.Int16":
                        short? convertedHigherInt16 = Convert.ToInt16(higherValue);
                        short? convertedLowerInt16;

                        // Evaluate datatype of lower precedence object and returns converted Int16 
                        convertedLowerInt16 =evaluateDatatypes.EvaluateInt16(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt16 > convertedLowerInt16;

                        return convertedLowerInt16 > convertedHigherInt16;

                    case "System.Byte":
                        byte? convertedHigherByte = Convert.ToByte(higherValue);
                        byte? convertedLowerByte;

                        // Evaluate datatype of lower precedence object and returns converted Byte 
                        convertedLowerByte = evaluateDatatypes.EvaluateByte(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherByte > convertedLowerByte;

                        return convertedLowerByte > convertedHigherByte;

                    case "System.String":

                        // Less than zero strA precedes strB in the sort order.
                        // Zero strA occurs in the same position as strB in the sort order.
                        // Greater than zero strA follows strB in the sort order.
                        int result = string.Compare(Convert.ToString(leftValueObj), Convert.ToString(rightValueObj), true);
                        if (result > 0)
                            return true;
                        return false;

                    default:
                        throw new Exception("SQLValueComparerUtil SQLGreaterThan Error - Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SQLGreaterThanOrEqual compares if leftValue is greater than or equal to rightValue
        /// </summary>
        /// <param name="leftValue">Object</param>
        /// <param name="rightValue">Object</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLGreaterThanOrEqual<T1, T2>(T1 leftValue, T2 rightValue)
        {
            object leftValueObj = leftValue;
            object rightValueObj = rightValue;
            try
            {
                //  If one object is NULL, return NULL.
                if (leftValue is IUDDTType leftValueUDDT) { leftValueObj = leftValueUDDT.Value; }
                if (rightValue is IUDDTType rightValueUDDT) { rightValueObj = rightValueUDDT.Value; }
                if (leftValueObj is null) { return null; }
                if (rightValueObj is null) { return null; }

                string higherType;
                string lowerType;
                object higherValue;
                object lowerValue;
                bool isLeftValueHigher;

                // For objects with different datatypes, datatype precedence must be followed for conversion.
                // Returns the precedence of each object and determine which has higher precedence
                (higherType, lowerType, higherValue, lowerValue, isLeftValueHigher) =
                    evaluateDatatypes.GetPrecedence(leftValueObj, rightValueObj);

                // Evaluate the datatype of higher precedence object 
                switch (higherType)
                {
                    case "System.DateTime":
                        DateTime? convertedHigherDateTime = Convert.ToDateTime(higherValue);
                        DateTime? convertedLowerDateTime;

                        // Evaluate datatype of lower precedence object and returns converted DateTime 
                        convertedLowerDateTime =
                            evaluateDatatypes.EvaluateDateTime(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDateTime >= convertedLowerDateTime;

                        return convertedLowerDateTime >= convertedHigherDateTime;

                    case "System.Double":
                        double? convertedHigherDouble = Convert.ToDouble(higherValue);
                        double? convertedLowerDouble;

                        // Evaluate datatype of lower precedence object and returns converted Double 
                        convertedLowerDouble = evaluateDatatypes.EvaluateDouble(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDouble >= convertedLowerDouble;

                        return convertedLowerDouble >= convertedHigherDouble;

                    case "System.Decimal":
                        decimal? convertedHigherDecimal = Convert.ToDecimal(higherValue);
                        decimal? convertedLowerDecimal;

                        // Evaluate datatype of lower precedence object and returns converted Decimal 
                        convertedLowerDecimal = evaluateDatatypes.EvaluateDecimal(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherDecimal >= convertedLowerDecimal;

                        return convertedLowerDecimal >= convertedHigherDecimal;

                    case "System.Int64":
                        long? convertedHigherInt64 = Convert.ToInt64(higherValue);
                        long? convertedLowerInt64;

                        // Evaluate datatype of lower precedence object and returns converted Int64 
                        convertedLowerInt64 = evaluateDatatypes.EvaluateInt64(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt64 >= convertedLowerInt64;

                        return convertedLowerInt64 >= convertedHigherInt64;

                    case "System.Int32":
                        int? convertedHigherInt32 = Convert.ToInt32(higherValue);
                        int? convertedLowerInt32;

                        // Evaluate datatype of lower precedence object and returns converted Int32 
                        convertedLowerInt32 = evaluateDatatypes.EvaluateInt32(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt32 >= convertedLowerInt32;

                        return convertedLowerInt32 >= convertedHigherInt32;

                    case "System.Int16":
                        short? convertedHigherInt16 = Convert.ToInt16(higherValue);
                        short? convertedLowerInt16;

                        // Evaluate datatype of lower precedence object and returns converted Int16 
                        convertedLowerInt16 = evaluateDatatypes.EvaluateInt16(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherInt16 >= convertedLowerInt16;

                        return convertedLowerInt16 >= convertedHigherInt16;

                    case "System.Byte":
                        byte? convertedHigherByte = Convert.ToByte(higherValue);
                        byte? convertedLowerByte;

                        // Evaluate datatype of lower precedence object and returns converted Byte 
                        convertedLowerByte = evaluateDatatypes.EvaluateByte(lowerValue, lowerType);

                        // Checks if leftValue has higher precedence
                        if (isLeftValueHigher)
                            return convertedHigherByte >= convertedLowerByte;

                        return convertedLowerByte >= convertedHigherByte;

                    case "System.String":

                        // Less than zero strA precedes strB in the sort order.
                        // Zero strA occurs in the same position as strB in the sort order.
                        // Greater than zero strA follows strB in the sort order.
                        int result = string.Compare(Convert.ToString(leftValueObj), Convert.ToString(rightValueObj), true);
                        if (result >= 0)
                            return true;
                        return false;

                    default:
                        throw new Exception("SQLValueComparerUtil SQLGreaterThanOrEqual Error - Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SQLBetween compares if firstValue is in between of secondValue and thirdValue
        /// </summary>
        /// <param name="firstValue">Object</param>
        /// <param name="secondValue">Object</param>
        /// <param name="thirdValue">Object</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLBetween<T1,T2,T3>(T1 firstValue, T2 secondValue, T3 thirdValue)
        {
            // IN SQL: @a between @b and @c
            // @a is the firstValue
            // @b is the secondValue
            // @c is the thirdValue
            // IN C#: @a >= @b && a <= @c

            object firstValueObj = firstValue;
            object secondValueObj = secondValue;
            object thirdValueObj = thirdValue;

            try
            {
                //  If one object is NULL, return NULL.
                if (firstValue is IUDDTType firstValueUDDT) { firstValueObj = firstValueUDDT.Value; }
                if (secondValue is IUDDTType secondValueUDDT) { secondValueObj = secondValueUDDT.Value; }
                if (thirdValue is IUDDTType thirdValueUDDT) { thirdValueObj = thirdValueUDDT.Value; }
                if (firstValueObj is null) { return null; }
                if (secondValueObj is null) { return null; }
                if (thirdValueObj is null) { return null; }

                string firstType;
                int firstTypePrecedence;

                // Get the precedence of firstValue
                (firstTypePrecedence, firstType, firstValueObj) = evaluateDatatypes.GetPrecedence(firstValueObj);

                string secondType;
                int secondTypePrecedence;

                // Get the precedence of secondValue
                (secondTypePrecedence, secondType, secondValueObj) = evaluateDatatypes.GetPrecedence(secondValueObj);

                string thirdType;
                int thirdTypePrecedence;

                // Get the precedence of thirdValue
                (thirdTypePrecedence, thirdType, thirdValueObj) = evaluateDatatypes.GetPrecedence(thirdValueObj);

                string highestType;

                // For objects with different datatypes, datatype precedence must be followed for conversion.
                // Identifies the precedence of each object and determine which has higher precedence
                if (firstTypePrecedence < secondTypePrecedence && firstTypePrecedence < thirdTypePrecedence)
                    highestType = firstType;
                else if (secondTypePrecedence < firstTypePrecedence && secondTypePrecedence < thirdTypePrecedence)
                    highestType = secondType;
                else
                    highestType = thirdType;

                // Evaluate the datatype of higher precedence object 
                switch (highestType)
                {
                    case "System.DateTime":
                        DateTime? convertedFirstDateTime;
                        DateTime? convertedSecondDateTime;
                        DateTime? convertedThirdDateTime;

                        // Evaluate datatype of firstValue object and returns converted DateTime 
                        convertedFirstDateTime = evaluateDatatypes.EvaluateDateTime(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted DateTime 
                        convertedSecondDateTime = evaluateDatatypes.EvaluateDateTime(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted DateTime 
                        convertedThirdDateTime = evaluateDatatypes.EvaluateDateTime(thirdValueObj, thirdType);

                        return convertedFirstDateTime >= convertedSecondDateTime && convertedFirstDateTime <= convertedThirdDateTime;

                    case "System.Double":
                        double? convertedFirstDouble;
                        double? convertedSecondDouble;
                        double? convertedThirdDouble;

                        // Evaluate datatype of firstValue object and returns converted Double 
                        convertedFirstDouble = evaluateDatatypes.EvaluateDouble(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Double 
                        convertedSecondDouble = evaluateDatatypes.EvaluateDouble(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Double 
                        convertedThirdDouble = evaluateDatatypes.EvaluateDouble(thirdValueObj, thirdType);

                        return convertedFirstDouble >= convertedSecondDouble && convertedFirstDouble <= convertedThirdDouble;

                    case "System.Decimal":
                        decimal? convertedFirstDecimal;
                        decimal? convertedSecondDecimal;
                        decimal? convertedThirdDecimal;

                        // Evaluate datatype of firstValue object and returns converted Decimal 
                        convertedFirstDecimal = evaluateDatatypes.EvaluateDecimal(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Decimal 
                        convertedSecondDecimal = evaluateDatatypes.EvaluateDecimal(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Decimal 
                        convertedThirdDecimal = evaluateDatatypes.EvaluateDecimal(thirdValueObj, thirdType);

                        return convertedFirstDecimal >= convertedSecondDecimal && convertedFirstDecimal <= convertedThirdDecimal;

                    case "System.Int64":
                        long? convertedFirstInt64;
                        long? convertedSecondInt64;
                        long? convertedThirdInt64;

                        // Evaluate datatype of firstValue object and returns converted Int64 
                        convertedFirstInt64 = evaluateDatatypes.EvaluateInt64(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Int64 
                        convertedSecondInt64 = evaluateDatatypes.EvaluateInt64(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Int64 
                        convertedThirdInt64 = evaluateDatatypes.EvaluateInt64(thirdValueObj, thirdType);

                        return convertedFirstInt64 >= convertedSecondInt64 && convertedFirstInt64 <= convertedThirdInt64;

                    case "System.Int32":
                        int? convertedFirstInt32;
                        int? convertedSecondInt32;
                        int? convertedThirdInt32;

                        // Evaluate datatype of firstValue object and returns converted Int32
                        convertedFirstInt32 = evaluateDatatypes.EvaluateInt32(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Int32 
                        convertedSecondInt32 = evaluateDatatypes.EvaluateInt32(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Int32
                        convertedThirdInt32 = evaluateDatatypes.EvaluateInt32(thirdValueObj, thirdType);

                        return convertedFirstInt32 >= convertedSecondInt32 && convertedFirstInt32 <= convertedThirdInt32;

                    case "System.Int16":
                        short? convertedFirstInt16;
                        short? convertedSecondInt16;
                        short? convertedThirdInt16;

                        // Evaluate datatype of firstValue object and returns converted Int16
                        convertedFirstInt16 = evaluateDatatypes.EvaluateInt16(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Int16
                        convertedSecondInt16 = evaluateDatatypes.EvaluateInt16(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Int16
                        convertedThirdInt16 = evaluateDatatypes.EvaluateInt16(thirdValueObj, thirdType);

                        return convertedFirstInt16 >= convertedSecondInt16 && convertedFirstInt16 <= convertedThirdInt16;

                    case "System.Byte":
                        byte? convertedFirstByte;
                        byte? convertedSecondByte;
                        byte? convertedThirdByte;

                        // Evaluate datatype of firstValue object and returns converted Byte
                        convertedFirstByte = evaluateDatatypes.EvaluateByte(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Byte
                        convertedSecondByte =evaluateDatatypes.EvaluateByte(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Byte
                        convertedThirdByte = evaluateDatatypes.EvaluateByte(thirdValueObj, thirdType);

                        return convertedFirstByte >= convertedSecondByte && convertedFirstByte <= convertedThirdByte;

                    case "System.String":

                        // Less than zero strA precedes strB in the sort order.
                        // Zero strA occurs in the same position as strB in the sort order.
                        // Greater than zero strA follows strB in the sort order.
                        int resultAB = string.Compare(Convert.ToString(firstValueObj), Convert.ToString(secondValueObj), true);
                        int resultAC = string.Compare(Convert.ToString(firstValueObj), Convert.ToString(thirdValueObj), true);
                        if (resultAB >= 0 && resultAC <= 0)
                            return true;
                        return false;

                    default:
                        throw new Exception("SQLValueComparerUtil SQLBetween Error - Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SQLAnd compares if leftValue and rightValue is both TRUE
        /// </summary>
        /// <param name="leftValue">Nullable Boolean</param>
        /// <param name="rightValue">Nullable Boolean</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLAnd(bool? leftValue, bool? rightValue)
        {
            if ((leftValue is true && rightValue is false)
                || (leftValue is false && rightValue is true)
                || (leftValue is false && rightValue is false)
                || (leftValue is false && rightValue is null)
                || (leftValue is null && rightValue is false))
                return false;

            if ((leftValue is true && rightValue is null)
                || (leftValue is null && rightValue is true)
                || (leftValue is null && rightValue is null))
                return null;

            // returns true if both value is true
            return true;
        }

        /// <summary>
        /// SQLOr compares if leftValue or rightValue is TRUE
        /// </summary>
        /// <param name="leftValue">Nullable Boolean</param>
        /// <param name="rightValue">Nullable Boolean</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLOr(bool? leftValue, bool? rightValue)
        {
            if ((leftValue is true && rightValue is true)
                || (leftValue is true && rightValue is false)
                || (leftValue is true && rightValue is null)
                || (leftValue is false && rightValue is true)
                || (leftValue is null && rightValue is true))
                return true;

            if ((leftValue is false && rightValue is null)
                || (leftValue is null && rightValue is false)
                || (leftValue is null && rightValue is null))
                return null;

            // returns false if both value is false
            return false;
        }

        /// <summary>
        /// SQLNot negates a condition
        /// </summary>
        /// <param name="leftValue">Nullable Boolean</param>
        /// <param name="rightValue">Nullable Boolean</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLNot(bool? value)
        {
            if (value is true)
                return false;

            if (value is false)
                return true;

            return null;
        }

        /// <summary>
        /// SQLBool
        /// </summary>
        /// <param name="value">Nullable Boolean</param>
        /// <returns>Booolean. If parameter is NULL, the result will be FALSE.</returns>
        public bool SQLBool(bool? value)
        {
            if (value is true)
                return true;

            return false;
        }

        /// <summary>
        /// SQLNotBetween compares if firstValue is not in between of secondValue and thirdValue
        /// </summary>
        /// <param name="firstValue">Object</param>
        /// <param name="secondValue">Object</param>
        /// <param name="thirdValue">Object</param>
        /// <returns>Nullable boolean. If parameter is NULL, the result will be NULL.</returns>
        public bool? SQLNotBetween<T1,T2,T3>(T1 firstValue, T2 secondValue, T3 thirdValue)
        {
            // IN SQL: @a not between @b and @c
            // @a is the firstValue
            // @b is the secondValue
            // @c is the thirdValue
            // !(@a >= @b && a <= @c)

            object firstValueObj = firstValue;
            object secondValueObj = secondValue;
            object thirdValueObj = thirdValue;

            try
            {
                //  If one object is NULL, return NULL.
                if (firstValue is IUDDTType firstValueUDDT) { firstValueObj = firstValueUDDT.Value; }
                if (secondValue is IUDDTType secondValueUDDT) { secondValueObj = secondValueUDDT.Value; }
                if (thirdValue is IUDDTType thirdValueUDDT) { thirdValueObj = thirdValueUDDT.Value; }
                if (firstValueObj is null) { return null; }
                if (secondValueObj is null) { return null; }
                if (thirdValueObj is null) { return null; }

                string firstType;
                int firstTypePrecedence;

                // Get the precedence of firstValue
                (firstTypePrecedence, firstType, firstValueObj) = evaluateDatatypes.GetPrecedence(firstValueObj);

                string secondType;
                int secondTypePrecedence;

                // Get the precedence of secondValue
                (secondTypePrecedence, secondType, secondValueObj) = evaluateDatatypes.GetPrecedence(secondValueObj);

                string thirdType;
                int thirdTypePrecedence;

                // Get the precedence of thirdValue
                (thirdTypePrecedence, thirdType, thirdValueObj) = evaluateDatatypes.GetPrecedence(thirdValueObj);

                string highestType;

                // For objects with different datatypes, datatype precedence must be followed for conversion.
                // Identifies the precedence of each object and determine which has higher precedence
                if (firstTypePrecedence < secondTypePrecedence && firstTypePrecedence < thirdTypePrecedence)
                    highestType = firstType;
                else if (secondTypePrecedence < firstTypePrecedence && secondTypePrecedence < thirdTypePrecedence)
                    highestType = secondType;
                else
                    highestType = thirdType;

                // Evaluate the datatype of higher precedence object 
                switch (highestType)
                {
                    case "System.DateTime":
                        DateTime? convertedFirstDateTime;
                        DateTime? convertedSecondDateTime;
                        DateTime? convertedThirdDateTime;

                        // Evaluate datatype of firstValue object and returns converted DateTime 
                        convertedFirstDateTime = evaluateDatatypes.EvaluateDateTime(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted DateTime 
                        convertedSecondDateTime = evaluateDatatypes.EvaluateDateTime(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted DateTime 
                        convertedThirdDateTime = evaluateDatatypes.EvaluateDateTime(thirdValueObj, thirdType);

                        return !(convertedFirstDateTime >= convertedSecondDateTime && convertedFirstDateTime <= convertedThirdDateTime);

                    case "System.Double":
                        double? convertedFirstDouble;
                        double? convertedSecondDouble;
                        double? convertedThirdDouble;

                        // Evaluate datatype of firstValue object and returns converted Double
                        convertedFirstDouble = evaluateDatatypes.EvaluateDouble(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Double
                        convertedSecondDouble = evaluateDatatypes.EvaluateDouble(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Double
                        convertedThirdDouble = evaluateDatatypes.EvaluateDouble(thirdValueObj, thirdType);

                        return
                            !(convertedFirstDouble >= convertedSecondDouble && convertedFirstDouble <= convertedThirdDouble);

                    case "System.Decimal":
                        decimal? convertedFirstDecimal;
                        decimal? convertedSecondDecimal;
                        decimal? convertedThirdDecimal;

                        // Evaluate datatype of firstValue object and returns converted Decimal 
                        convertedFirstDecimal = evaluateDatatypes.EvaluateDecimal(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Decimal 
                        convertedSecondDecimal = evaluateDatatypes.EvaluateDecimal(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Decimal 
                        convertedThirdDecimal = evaluateDatatypes.EvaluateDecimal(thirdValueObj, thirdType);

                        return !(convertedFirstDecimal >= convertedSecondDecimal && convertedFirstDecimal <= convertedThirdDecimal);

                    case "System.Int64":
                        long? convertedFirstInt64;
                        long? convertedSecondInt64;
                        long? convertedThirdInt64;

                        // Evaluate datatype of firstValue object and returns converted Int64 
                        convertedFirstInt64 = evaluateDatatypes.EvaluateInt64(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Int64 
                        convertedSecondInt64 = evaluateDatatypes.EvaluateInt64(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Int64 
                        convertedThirdInt64 = evaluateDatatypes.EvaluateInt64(thirdValueObj, thirdType);

                        return !(convertedFirstInt64 >= convertedSecondInt64 && convertedFirstInt64 <= convertedThirdInt64);

                    case "System.Int32":
                        int? convertedFirstInt32;
                        int? convertedSecondInt32;
                        int? convertedThirdInt32;

                        // Evaluate datatype of firstValue object and returns converted Int32
                        convertedFirstInt32 =evaluateDatatypes.EvaluateInt32(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Int32
                        convertedSecondInt32 = evaluateDatatypes.EvaluateInt32(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Int32
                        convertedThirdInt32 = evaluateDatatypes.EvaluateInt32(thirdValueObj, thirdType);

                        return !(convertedFirstInt32 >= convertedSecondInt32 && convertedFirstInt32 <= convertedThirdInt32);

                    case "System.Int16":
                        short? convertedFirstInt16;
                        short? convertedSecondInt16;
                        short? convertedThirdInt16;

                        // Evaluate datatype of firstValue object and returns converted Int16
                        convertedFirstInt16 =  evaluateDatatypes.EvaluateInt16(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Int16
                        convertedSecondInt16 = evaluateDatatypes.EvaluateInt16(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Int16
                        convertedThirdInt16 = evaluateDatatypes.EvaluateInt16(thirdValueObj, thirdType);

                        return !(convertedFirstInt16 >= convertedSecondInt16 && convertedFirstInt16 <= convertedThirdInt16);

                    case "System.Byte":
                        byte? convertedFirstByte;
                        byte? convertedSecondByte;
                        byte? convertedThirdByte;

                        // Evaluate datatype of firstValue object and returns converted Byte
                        convertedFirstByte =
                        evaluateDatatypes.EvaluateByte(firstValueObj, firstType);

                        // Evaluate datatype of secondValue object and returns converted Byte
                        convertedSecondByte = evaluateDatatypes.EvaluateByte(secondValueObj, secondType);

                        // Evaluate datatype of thirdValue object and returns converted Byte
                        convertedThirdByte =  evaluateDatatypes.EvaluateByte(thirdValueObj, thirdType);

                        return !(convertedFirstByte >= convertedSecondByte && convertedFirstByte <= convertedThirdByte);

                    case "System.String":

                        // Less than zero strA precedes strB in the sort order.
                        // Zero strA occurs in the same position as strB in the sort order.
                        // Greater than zero strA follows strB in the sort order.
                        int resultAB = string.Compare(Convert.ToString(firstValueObj), Convert.ToString(secondValueObj), true);
                        int resultAC = string.Compare(Convert.ToString(firstValueObj), Convert.ToString(thirdValueObj), true);
                        if (resultAB >= 0 && resultAC <= 0)
                            return false;
                        return true;

                    default:
                        throw new Exception("SQLValueComparerUtil SQLNotBetween Error - Datatype not handled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// CaseWhen changes the datatype of thenExpression or elseExpression to T type
        /// </summary>
        /// <param name="whenCondition">boolean</param>
        /// <param name="thenExpression">Object</param>
        /// <param name="elseExpression">Object</param>
        /// <returns>if whenCondition is true, it returns thenExpression else it returns elseExpression</returns>
        public T CaseWhen<T>(bool whenCondition, object thenExpression, object elseExpression = null)
        {
            object valueToReturn;

            if (whenCondition)
                valueToReturn = thenExpression;
            else
                valueToReturn = elseExpression;

            // Return default nullable value based on native datatype or UDDT if valueToReturn is null
            if (valueToReturn == null || valueToReturn is DBNull)
            {
                if (typeof(T).GetInterfaces().Contains(typeof(IUDDTType)))
                {
                    foreach (var constructorInfo in typeof(T).GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
                    {
                        try
                        {
                            return (T)constructorInfo.Invoke(new object[] { null });
                        }
                        catch
                        {
                            // ignored
                        }
                    }

                    return default(T);
                }

                return default(T);
            }

            // Change the type of valueToReturn based on <T> datatype
            if (valueToReturn is IUDDTType)
            {
                return (T)evaluateDatatypes.ChangeType(((IUDDTType)valueToReturn).Value,
                    Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
            }
            else
            {
                return (T)evaluateDatatypes.ChangeType(valueToReturn,
                    Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
            }
        }
    }
}
