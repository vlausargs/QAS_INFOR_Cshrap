using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IDateTimeUtil
    {
        DateTime EmptyValue { get; }
        DateTime Now();

        T Year<T>(string date);

        T Month<T>(string date);

        T Day<T>(string date);

        T Year<T>(DateTime? date);

        T Month<T>(DateTime? date);

        T Day<T>(DateTime? date);

        int IsDate(string date);

        int? DateDiff<T1, T2>(string identifier, T1 dateParm1, T2 dateParm2);

        DateTime? DateAdd<T>(string identifier, int? datePartParm, T dateParm);

        string DateName<T>(string identifier, T dateParm);

        int? DatePart<T>(string identifier, T dateParm);

        string[] DateFormatDictionary();

        DateTime? ConvertObjectToDateTime(object date, string type);

        DateTimeOffset? ConvertToDateTimeOffset(string input);

        TimeSpan? ConvertToTimeSpan(string input);

        string ConvertToString(DateTime? dateTimeToConvert, string format);
    }
}
