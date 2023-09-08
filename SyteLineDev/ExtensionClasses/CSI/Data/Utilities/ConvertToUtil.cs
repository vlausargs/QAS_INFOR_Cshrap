using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CSI.Data.Utilities
{
    /// <summary>
    /// Wrappers for Convert methods used in C#izer 
    /// </summary>
    public class ConvertToUtil : IConvertToUtil
    {
        readonly IDateTimeUtil dateTimeUtil;

        public ConvertToUtil(IDateTimeUtil dateTimeUtil)
        {
            this.dateTimeUtil = dateTimeUtil;
        }

        /// <summary>
        /// Wrapper for Convert.ToDecimal() method 
        /// </summary>
        /// <param name="value">Object to be converted</param>
        public decimal? ToDecimal<T>(T value)
        {
            if (value == null)
                return null;

            if (value is IUDDTType uDDTType)
                return uDDTType.Value == null ? default(decimal?) : Convert.ToDecimal(uDDTType.Value);
            else
                return Convert.ToDecimal(value);
        }

        /// <summary>
        /// Wrapper for Convert.ToInt32() method 
        /// </summary>
        /// <param name="value">Object to be converted</param>
        public int? ToInt32<T>(T value)
        {
            if (value == null)
                return null;

            if (value is IUDDTType uDDTType)
                return uDDTType.Value == null ? default(int?) : Convert.ToInt32(uDDTType.Value);
            else
                return Convert.ToInt32(value);
        }

        /// <summary>
        /// Wrapper for Convert.ToInt64() method 
        /// </summary>
        /// <param name="value">Object to be converted</param>
        public long? ToInt64<T>(T value)
        {
            if (value == null)
                return null;

            if (value is IUDDTType uDDTType)
                return uDDTType.Value == null ? default(long?) : Convert.ToInt64(uDDTType.Value);
            else
                return Convert.ToInt64(value);
        }

        /// <summary>
        /// Wrapper for Convert.ToBoolean() method 
        /// </summary>
        /// <param name="value">Object to be converted</param>
        public bool? ToBoolean<T>(T value)
        {
            if (value == null)
                return null;

            if (value is IUDDTType uDDTType)
                return uDDTType.Value == null ? default(bool?) : Convert.ToBoolean(uDDTType.Value);
            else
                return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Wrapper for Convert.ToDateTime() method 
        /// </summary>
        /// <param name="value">Object to be converted</param>
        public DateTime? ToDateTime<T>(T value)
        {
            object pendingConvertValue = value;
            if (value is IUDDTType uDDTType) pendingConvertValue = uDDTType.Value;
            if (pendingConvertValue == null) return null;
            DateTime convertedDateTime;
            string[] formats = dateTimeUtil.DateFormatDictionary();
            if (pendingConvertValue.GetType() == typeof(DateTime?) || pendingConvertValue.GetType() == typeof(DateTime))
                return dateTimeUtil.ConvertObjectToDateTime(pendingConvertValue, "System.DateTime");
            if (DateTime.TryParseExact(pendingConvertValue.ToString(), formats, DateTimeFormatInfo.InvariantInfo,
                       DateTimeStyles.AllowTrailingWhite, out convertedDateTime))
                return convertedDateTime;
            if (DateTime.TryParse(pendingConvertValue.ToString(), out convertedDateTime))
                return convertedDateTime;
            return null;
        }

        /// <summary>
        /// Wrapper for Convert.ToString() method 
        /// </summary>
        /// <param name="value">Object to be converted</param>
        /// <returns>string value</returns>
        public string ToString<T>(T value)
        {
            if (value == null)
                return null;

            if (value is IUDDTType uDDTType)
                return uDDTType.Value == null ? null : Convert.ToString(uDDTType.Value);
            else
                return Convert.ToString(value);
        }

        /// <summary>
        /// Wrapper for Convert.ToString() method 
        /// </summary>
        /// <param name="value">Object to be converted</param>
        /// <param name="style">Style for converting money to string</param>
        /// <returns>string value</returns>
        public string ToString<T>(T value, object style)
        {
            object newValue = value;

            if (value == null)
                return null;

            if (value is IUDDTType uDDTType)
            {
                if  (uDDTType.Value == null)
                        return null;
                newValue = uDDTType.Value;
            }

            string styleConverted = Convert.ToString(style);
            string valueConverted;

            if (int.TryParse(styleConverted, out int intStyle))
            {
                if (intStyle == 0)
                {
                    valueConverted = Convert.ToDecimal(newValue).ToString("###0.00");
                }
                else if (intStyle == 2)
                {
                    valueConverted = Convert.ToDecimal(newValue).ToString();
                }
                else
                {
                    valueConverted = Convert.ToDecimal(newValue).ToString("#,##0.00");
                }
            }
            else
            {
                valueConverted = Convert.ToDecimal(newValue).ToString("#,##0.00");
            }

            return valueConverted;
        }

        /// <summary>
        /// Wrapper for Convert.ToGuid() method 
        /// </summary>
        /// <param name="value">Object to be converted</param>
        /// <returns>string value</returns>
        public Guid? ToGuid<T>(T value)
        {
            if (value is IUDDTType uddt)
            {
                if(uddt.Value==null)
                    return null;
            }
            if (value == null)
                return null;

            Guid outGuid = Guid.NewGuid();

            if (value is IUDDTType uDDTType)
                Guid.TryParse(Convert.ToString(uDDTType.Value), out outGuid);
            else
                 Guid.TryParse(Convert.ToString(value), out outGuid);

            return outGuid;

        }
    }
}
