using System;
using System.Globalization;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Utilities
{
    public class DateTimeUtil : IDateTimeUtil
    {
        readonly IDataTypeUtil dataTypeUtil;
        public DateTime EmptyValue 
        { 
            get 
            {
                return DateTime.Parse("1900-01-01 00:00:00.000");
            }
        }
        public DateTimeUtil(IDataTypeUtil dataTypeUtil)
        {
            this.dataTypeUtil = dataTypeUtil;
        }

        public DateTime Now()
        {
            return DateTime.Now;
        }

        public T Year<T>(string date)
        {
            int mon = DateTime.Parse(date).Year;
            return (T)ChangeType(mon, typeof(T));
        }

        public T Year<T>(DateTime? date)
        {
            int mon;
            if (date == null)
                return default(T);
            else
                mon = date.Value.Year;
            return (T)ChangeType(mon, typeof(T));
        }

        public T Month<T>(string date)
        {
            int mon = DateTime.Parse(date).Month;
            return (T)ChangeType(mon, typeof(T));
        }

        public T Month<T>(DateTime? date)
        {
            int mon;
            if (date == null)
                return default(T);
            else
                mon = date.Value.Month;
            return (T)ChangeType(mon, typeof(T));
        }

        public T Day<T>(string date)
        {
            int mon = DateTime.Parse(date).Day;
            return (T)ChangeType(mon, typeof(T));
        }

        public T Day<T>(DateTime? date)
        {
            int mon;
            if (date == null)
                return default(T);
            else
                mon = date.Value.Day;
            return (T)ChangeType(mon, typeof(T));
        }

        public int IsDate(string date)
        {
            if (DateTime.TryParse(date, out DateTime result))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int? DateDiff<T1,T2>(string identifier, T1 dateParm1, T2 dateParm2)
        {
            try
            {
                if (dateParm1 == null || dateParm2 == null)
                    return null;

                DateTime? date1 = ConvertObjectToDateTime(dateParm1, dateParm1.GetType().FullName);
                DateTime? date2 = ConvertObjectToDateTime(dateParm2, dateParm2.GetType().FullName);

                DateTime? d1 = null;
                DateTime? d2 = null;
                TimeSpan ts;

                switch (identifier)
                {
                    case "Year":
                        return date2.Value.Year - date1.Value.Year;
                    case "Month":
                        return (date2.Value.Month - date1.Value.Month) + (12 * (date2.Value.Year - date1.Value.Year));
                    case "Day":
                    case "Weekday":
                        d1 = new DateTime(date1.Value.Year, date1.Value.Month, date1.Value.Day);
                        d2 = new DateTime(date2.Value.Year, date2.Value.Month, date2.Value.Day);
                        ts = d2.Value - d1.Value;
                        return (int)ts.TotalDays;
                    case "Hour":
                        d1 = new DateTime(date1.Value.Year, date1.Value.Month, date1.Value.Day, date1.Value.Hour, 0, 0);
                        d2 = new DateTime(date2.Value.Year, date2.Value.Month, date2.Value.Day, date2.Value.Hour, 0, 0);
                        ts = d2.Value - d1.Value;
                        return (int)ts.TotalHours;
                    case "Minute":
                        d1 = new DateTime(date1.Value.Year, date1.Value.Month, date1.Value.Day, date1.Value.Hour, date1.Value.Minute, 0);
                        d2 = new DateTime(date2.Value.Year, date2.Value.Month, date2.Value.Day, date2.Value.Hour, date2.Value.Minute, 0);
                        ts = d2.Value - d1.Value;
                        return (int)ts.TotalMinutes;
                    case "Second":
                        d1 = new DateTime(date1.Value.Year, date1.Value.Month, date1.Value.Day, date1.Value.Hour, date1.Value.Minute, date1.Value.Second);
                        d2 = new DateTime(date2.Value.Year, date2.Value.Month, date2.Value.Day, date2.Value.Hour, date2.Value.Minute, date2.Value.Second);
                        ts = d2.Value - d1.Value;
                        return (int)ts.TotalSeconds;
                    case "Millisecond":
                        ts = date2.Value - date1.Value;
                        return (int)ts.TotalMilliseconds;
                    default:
                        throw new Exception("DateTimeUtil DateDiff Error - Invalid identifier");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DateTime? DateAdd<T>(string identifier, int? datePartParm, T dateParm)
        {
            try
            {
                int datePart = datePartParm ?? 0;

                if (dateParm == null)
                    return null;

                DateTime? date = ConvertObjectToDateTime(dateParm, dateParm.GetType().FullName);

                switch (identifier)
                {
                    case "Year":
                        return date.Value.AddYears(datePart);
                    case "Month":
                        return date.Value.AddMonths(datePart);
                    case "Day":
                    case "Weekday":
                        return date.Value.AddDays(datePart);
                    case "Hour":
                        return date.Value.AddHours(datePart);
                    case "Minute":
                        return date.Value.AddMinutes(datePart);
                    case "Second":
                        return date.Value.AddSeconds(datePart);
                    case "Millisecond":
                        return date.Value.AddMilliseconds(datePart);
                    default:
                        throw new Exception("DateTimeUtil DateAdd Error - Invalid identifier");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DateName<T>(string identifier, T dateParm)
        {
            try
            {
                if (dateParm == null)
                    return null;

                DateTime? date = ConvertObjectToDateTime(dateParm, dateParm.GetType().FullName);

                switch (identifier)
                {
                    case "Year":
                        return date.Value.Year.ToString();
                    case "Month":
                        return date.Value.ToString("MMMM", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    case "Day":
                        return date.Value.Day.ToString();
                    case "Weekday":
                        return date.Value.DayOfWeek.ToString();
                    case "Hour":
                        return date.Value.Hour.ToString();
                    case "Minute":
                        return date.Value.Minute.ToString();
                    case "Second":
                        return date.Value.Second.ToString();
                    case "Millisecond":
                        return date.Value.Millisecond.ToString();
                    default:
                        throw new Exception("DateTimeUtil DateName Error - Invalid identifier");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int? DatePart<T>(string identifier, T dateParm)
        {
            try
            {
                if (dateParm == null)
                    return null;

                DateTime? date = ConvertObjectToDateTime(dateParm, dateParm.GetType().FullName);

                switch (identifier)
                {
                    case "Year":
                        return date.Value.Year;
                    case "Month":
                        return date.Value.Month;
                    case "Day":
                        return date.Value.Day;
                    case "Weekday":
                        return Convert.ToInt32(date.Value.DayOfWeek) + 1;
                    case "Hour":
                        return date.Value.Hour;
                    case "Minute":
                        return date.Value.Minute;
                    case "Second":
                        return date.Value.Second;
                    case "Millisecond":
                        return date.Value.Millisecond;
                    default:
                        throw new Exception("DateTimeUtil DateName Error - Invalid identifier");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string[] DateFormatDictionary()
        {
            string[] formats = {
                    "MMM dd yyyy hh:mmtt"
                     , "MMM dd yyyy hh:mmtt"
                     , "MM/dd/yy"
                     , "MM/dd/yyyy"
                     , "M/d/yyyy"
                     , "MM/dd/yyyy hh:mm:ss tt"
                     , "MM/dd/yyyy hh tt"
                     , "MM/dd/yyyy h tt" 
                     , "MM/dd/yyyy hh:mm tt" 
                     , "MM/dd/yyyy h:mm tt"
                     , "M/d/yyyy h:mm:ss tt"
                     , "M/dd/yyyy hh:mm:ss"
                     , "MM/dd/yyyy h:mm:ss tt"
                     , "MM/dd/yyyy HH:mm:ss"
                     , "MM/dd/yyyy HH:mm"
                     , "yy.MM.dd"
                     , "yyyy.MM.dd"
                     , "yyyy-MM-dd"
                     , "dd/MM/yy"
                     , "dd/MM/yyyy"
                     , "dd.MM.yy"
                     , "dd.MM.yyyy"
                     , "dd-MM-yy"
                     , "dd-MM-yyyy"
                     , "dd MMM yy"
                     , "dd MMM yyyy"
                     , "MMM dd, yy"
                     , "MMM dd, yyyy"
                     , "hh:mi:ss"
                     , "hh:mi:ss"
                     , "MMM dd yyyy hh:mm:ss.ffftt"
                     , "MMM dd yyyy hh:mm:ss.ffftt"
                     , "MM-dd-yy"
                     , "MM-dd-yyyy"
                     , "yy/MM/dd"
                     , "yyyy/MM/dd"
                     , "yyMMdd"
                     , "yyyyMMdd"
                     , "dd MMM yyyy HH:mm:ss:fff"
                     , "dd MMM yyyy HH:mm:ss:fff"
                     , "HH:mm:ss.fff"
                     , "HH:mm:ss.fff"
                     , "yyyy-MM-dd HH:mm:ss"
                     , "yyyy-MM-dd HH:mm:ss"
                     , "yyyy-MM-dd HH:mm:ss.fff"
                     , "yyyy-MM-dd HH:mm:ss.fff"
                     , "yyyy-MM-ddThh:mm:ss.fff"
                     , "yyyy-MM-ddThh:mm:ss.fffz"
            };

            return formats;
        }

        public DateTime? ConvertObjectToDateTime(object date, string type)
        {
            if (date == null)
                return null;
            try
            {
                bool isUDDT = dataTypeUtil.IsUDDT(type);

                if (isUDDT)
                {
                    type = dataTypeUtil.GetCSType(type);
                    date = (date as IUDDTType)?.Value;
                }

                switch (type)
                {
                    case "System.DateTime":
                        return (DateTime?)date;
                    case "System.String":
                        DateTime convertedDate;
                        string[] formats = DateFormatDictionary();

                        if (DateTime.TryParseExact(date.ToString(), formats,  DateTimeFormatInfo.InvariantInfo,
                                   DateTimeStyles.AllowTrailingWhite, out convertedDate))
                            return convertedDate;
                        if(DateTime.TryParse(date.ToString(), out convertedDate))
                            return convertedDate;

                        throw new Exception("Invalid DateTime format");
                    case "System.Double":
                    case "System.Decimal":
                    case "System.Int32":
                    case "System.Int16":
                    case "System.Int64":
                    case "System.Byte":
                        // Plus 2: SQL uses zero-date as 1900-01-01, in C# it uses 1899-12-30
                        return DateTime.FromOADate(Convert.ToDouble(date) + 2);

                    default:
                        throw new Exception("Invalid DateTime format");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DateTimeUtil Error - " + ex.Message);
            }
        }

        public DateTimeOffset? ConvertToDateTimeOffset(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return null;
            }

            input = input.Trim(new char[] { ' ', '\"' });
            string[] valueList = input.Split(new char[] { ' ' });
            if (valueList.Length < 2)
            {
                return null;
            }

            string dateValue = valueList[0];
            string timeValue = valueList[1];

            DateTime date;
            DateTime.TryParse(dateValue + " " + timeValue, out date);
            
            TimeSpan timeSpan = new TimeSpan();
            if (valueList.Length > 2)
            {
                string timeZone = valueList[2];
                string[] timeZoneList = timeZone.Split(new char[] { ':' });
                int hours = 0, minutes = 0, seconds = 0;
                hours = Convert.ToInt32(timeZoneList[0]);
                minutes = Convert.ToInt32(timeZoneList[1]);
                if (timeZoneList.Length >= 3)
                {
                    seconds = Convert.ToInt32(timeZoneList[2]);
                }

                timeSpan = new TimeSpan(hours, minutes, seconds);
            }
            
            DateTimeOffset dateTimeOffset = new DateTimeOffset(date, timeSpan);

            return dateTimeOffset;
        }

        public TimeSpan? ConvertToTimeSpan(string input)
        {
            TimeSpan? timeSpan = null;
            if(string.IsNullOrEmpty(input))
            {
                return null;
            }

            input = input.Trim(new char[] { ' ', '\"' });
            string[] valueList = input.Split(new char[] { ':', '.' });

            int hours = 0, minutes = 0;
            int seconds = 0, milliseconds = 0;
            
            if(valueList.Length < 2)
            {
                return null;
            }

            hours = Convert.ToInt32(valueList[0]);
            minutes = Convert.ToInt32(valueList[1]);
            timeSpan = new TimeSpan(hours, minutes, 0);

            if (valueList.Length == 3)
            {
                seconds = Convert.ToInt32(valueList[2]);
                timeSpan = new TimeSpan(hours, minutes, seconds);
            }
            else if (valueList.Length == 4)
            {
                seconds = Convert.ToInt32(valueList[2]);
                milliseconds = Convert.ToInt32(valueList[3]);
                timeSpan = new TimeSpan(0, hours, minutes, seconds, milliseconds);
            }

            return timeSpan;
        }

        public string ConvertToString(DateTime? dateTimeToConvert, string format)
        {
            if (dateTimeToConvert == null)
            {
                return null;
            }

            return ((DateTime)dateTimeToConvert).ToString(format);
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
    }
}
