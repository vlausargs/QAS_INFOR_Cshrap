using System;
using System.Data.SqlTypes;
using System.Globalization;
using CSI.Data.SQL.UDDT;
using System.Reflection;
namespace CSI.Data.Utilities
{
    public class MathUtil : IMathUtil
    {
        //IMathUtil mathUtil;
        readonly IDataTypeUtil dataTypeUtil;

        //public MathUtil(IMathUtil mathUtil, IDataTypeUtil dataTypeUtil)
        public MathUtil(IDataTypeUtil dataTypeUtil)
        {
            //this.mathUtil = mathUtil;
            this.dataTypeUtil = dataTypeUtil;
        }

        public T Ceiling<T>(object input)
        {
            ///For null values
            if (input == null || input is DBNull)
            {
                return default(T);
            }

            var inputuddtBaseType = string.Empty;
            var inputtype = input.GetType();
            var inputisUDDT = dataTypeUtil.IsUDDT(inputtype.FullName);
            var methodTypeisUDDT = dataTypeUtil.IsUDDT(typeof(T).FullName);

            double convertedinput = default(double);

            if (inputisUDDT)
            {
                inputuddtBaseType = dataTypeUtil.GetCSType(inputtype.FullName);
                input = (input as IUDDTType)?.Value;
            }

            convertedinput = ChangeType<double>(input, inputtype, inputuddtBaseType);

            return (T)ChangeType(Math.Ceiling(convertedinput), Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
        }

        public T Floor<T>(object input)
        {
            ///For null values
            if (input == null || input is DBNull)
            {
                return default(T);
            }

            var inputuddtBaseType = string.Empty;
            var inputtype = input.GetType();
            var inputisUDDT = dataTypeUtil.IsUDDT(inputtype.FullName);
            var methodTypeisUDDT = dataTypeUtil.IsUDDT(typeof(T).FullName);

            double convertedinput = default(double);

            if (inputisUDDT)
            {
                inputuddtBaseType = dataTypeUtil.GetCSType(inputtype.FullName);
                input = (input as IUDDTType)?.Value;
            }

            convertedinput = ChangeType<double>(input, inputtype, inputuddtBaseType);

            return (T)ChangeType(Math.Floor(convertedinput), Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
        }

        public T Abs<T>(object input)
        {
            ///For null values
            if (input == null || input is DBNull)
            {
                return default(T);
            }

            var inputuddtBaseType = string.Empty;
            var inputtype = input.GetType();
            var inputisUDDT = dataTypeUtil.IsUDDT(inputtype.FullName);
            var methodTypeisUDDT = dataTypeUtil.IsUDDT(typeof(T).FullName);

            double convertedinput = default(double);

            if (inputisUDDT)
            {
                inputuddtBaseType = dataTypeUtil.GetCSType(inputtype.FullName);
                input = (input as IUDDTType)?.Value;
            }

            convertedinput = ChangeType<double>(input, inputtype, inputuddtBaseType);

            return (T)ChangeType(Math.Abs(convertedinput), Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
        }

        public T Exp<T>(object input)
        {
            ///For null values
            if (input == null || input is DBNull)
            {
                return default(T);
            }

            var inputuddtBaseType = string.Empty;
            var inputtype = input.GetType();
            var inputisUDDT = dataTypeUtil.IsUDDT(inputtype.FullName);
            var methodTypeisUDDT = dataTypeUtil.IsUDDT(typeof(T).FullName);

            double convertedinput = default(double);

            if (inputisUDDT)
            {
                inputuddtBaseType = dataTypeUtil.GetCSType(inputtype.FullName);
                input = (input as IUDDTType)?.Value;
            }

            convertedinput = ChangeType<double>(input, inputtype, inputuddtBaseType);

            return (T)ChangeType(Math.Exp(convertedinput), Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
        }

        public T Sqrt<T>(object input)
        {
            ///For null values
            if (input == null || input is DBNull)
            {
                return default(T);
            }

            var inputuddtBaseType = string.Empty;
            var inputtype = input.GetType();
            var inputisUDDT = dataTypeUtil.IsUDDT(inputtype.FullName);
            var methodTypeisUDDT = dataTypeUtil.IsUDDT(typeof(T).FullName);

            double convertedinput = default(double);

            if (inputisUDDT)
            {
                inputuddtBaseType = dataTypeUtil.GetCSType(inputtype.FullName);
                input = (input as IUDDTType)?.Value;
            }

            convertedinput = ChangeType<double>(input, inputtype, inputuddtBaseType);

            return (T)ChangeType(Math.Sqrt(convertedinput), Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
        }

        public T Pow<T>(object inputNumber, object inputDigits)
        {
            ///For null values
            if (inputNumber == null || inputNumber is DBNull ||
                inputDigits == null || inputDigits is DBNull)
            {
                return default(T);
            }

            var inputuddtBaseType = string.Empty;
            var inputtype = inputNumber.GetType();
            var inputisUDDT = dataTypeUtil.IsUDDT(inputtype.FullName);

            var input2uddtBaseType = string.Empty;
            var input2type = inputDigits.GetType();
            var input2isUDDT = dataTypeUtil.IsUDDT(input2type.FullName);

            var methodTypeisUDDT = dataTypeUtil.IsUDDT(typeof(T).FullName);

            double convertedinput = default(double);
            double convertedinput2 = default(double);

            if (inputisUDDT)
            {
                inputuddtBaseType = dataTypeUtil.GetCSType(inputtype.FullName);
                inputNumber = (inputNumber as IUDDTType)?.Value;
            }

            if (input2isUDDT)
            {
                input2uddtBaseType = dataTypeUtil.GetCSType(input2type.FullName);
                inputDigits = (inputDigits as IUDDTType)?.Value;
            }


            // For input1
            convertedinput = ChangeType<double>(inputNumber, inputtype, inputuddtBaseType);

            // For input2
            convertedinput2 = ChangeType<double>(inputDigits, input2type, input2uddtBaseType);

            return (T)ChangeType(Math.Pow(convertedinput, convertedinput2), Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
        }

        public T Round<T>(object inputNumber, object inputDigits, object truncateAfterRound = null)
        {
            //For null values
            if (inputNumber == null || inputNumber is DBNull ||
                inputDigits == null || inputDigits is DBNull)
            {
                return default(T);
            }

            var inputuddtBaseType = string.Empty;
            var inputtype = inputNumber.GetType();
            var inputisUDDT = dataTypeUtil.IsUDDT(inputtype.FullName);

            var input2uddtBaseType = string.Empty;
            var input2type = inputDigits.GetType();
            var input2isUDDT = dataTypeUtil.IsUDDT(input2type.FullName);

            var methodTypeisUDDT = dataTypeUtil.IsUDDT(typeof(T).FullName);

            double convertedinput = default(double);
            decimal roundOutput = default(decimal);
            int convertedinput2Int = default(int);
            int convertedinput3Int = default(int);

            if (inputisUDDT)
            {
                inputuddtBaseType = dataTypeUtil.GetCSType(inputtype.FullName);
                inputNumber = (inputNumber as IUDDTType)?.Value;
            }

            if (input2isUDDT)
            {
                input2uddtBaseType = dataTypeUtil.GetCSType(input2type.FullName);
                inputDigits = (inputDigits as IUDDTType)?.Value;
            }

            // convert input1
            convertedinput = ChangeType<double>(inputNumber, inputtype, inputuddtBaseType);

            //Convert input2
            convertedinput2Int = ChangeType<int>(inputDigits, input2type, input2uddtBaseType);

            //Convert Input3 if any
            if (truncateAfterRound == null || truncateAfterRound is DBNull)
                convertedinput3Int = 0;
            else
            {
                var input3uddtBaseType = string.Empty;
                var input3type = truncateAfterRound.GetType();
                var input3isUDDT = dataTypeUtil.IsUDDT(input3type.FullName);

                if (input3isUDDT)
                {
                    input3uddtBaseType = dataTypeUtil.GetCSType(input3type.FullName);
                    truncateAfterRound = (truncateAfterRound as IUDDTType)?.Value;
                }

                //Convert input3

                if (input3type == typeof(string) || input3uddtBaseType == "System.String")
                {
                    bool outputtype = ((string)truncateAfterRound).Contains(".") ? true : false;

                    if (outputtype)
                    {
                        if (decimal.TryParse((string)truncateAfterRound, out decimal output))
                            convertedinput3Int = decimal.ToInt32(output);
                    }
                    else
                    {
                        if (int.TryParse((string)truncateAfterRound, out int output) && !string.IsNullOrEmpty((string)truncateAfterRound))
                            convertedinput3Int = output;
                    }
                }
                else
                {
                    convertedinput3Int = ChangeType<int>(truncateAfterRound, input3type, input3uddtBaseType);
                }
            }

            //Round or Truncate
            if (convertedinput3Int == 0)
            {
                //To the Right or left of the Decimal Point
                if (convertedinput2Int > 0)
                {
                    roundOutput = Math.Round((decimal)convertedinput, convertedinput2Int, MidpointRounding.AwayFromZero);
                }
                else
                {
                    convertedinput2Int *= -1;
                    roundOutput = (decimal)convertedinput - (decimal)convertedinput % (decimal)Math.Pow(10, convertedinput2Int);

                    decimal fiveToTheNthPower = 5 * (decimal)Math.Pow(10, convertedinput2Int - 1);
                    decimal valuesBeforeTheNthPower = (decimal)convertedinput % (decimal)Math.Pow(10, convertedinput2Int);

                    //If Rounding Results in increment
                    if (valuesBeforeTheNthPower >= fiveToTheNthPower)
                    {
                        roundOutput += (decimal)Math.Pow(10, convertedinput2Int);
                    }
                    else if (valuesBeforeTheNthPower <= fiveToTheNthPower * -1)
                    {
                        roundOutput -= (decimal) Math.Pow(10, convertedinput2Int);
                    }
                }
            }
            else
            {
                convertedinput2Int *= -1;
                roundOutput = (decimal)convertedinput - (decimal)convertedinput % (decimal)Math.Pow(10, convertedinput2Int);
            }

            return (T)ChangeType(roundOutput, Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
        }

        private object ChangeType(object value, Type conversion)
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

        private T ChangeType<T>(object input, Type inputtype, string inputuddtBaseType)
        {
            if (inputtype == typeof(string) || inputuddtBaseType == "System.String")
            {
                if (double.TryParse((string)input, out double output) || (string)input == string.Empty)
                    return (T)ChangeType(output, typeof(T));
                else
                    return default(T);
            }
            else
                return (T)ChangeType(input, typeof(T));
        }
    }
}
