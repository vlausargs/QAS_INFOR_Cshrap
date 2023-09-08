using CSI.Data.Functions;
using System;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface ITransactionDate
    {
        DateTime GetSQLDateWhenNull(DateTime? Date);
    }

    public class TransactionDate : ITransactionDate
    {
        readonly IGetSQLDateTime iGetSQLDateTime;

        public TransactionDate(IGetSQLDateTime iGetSQLDateTime)
        {
            this.iGetSQLDateTime = iGetSQLDateTime;
        }

        public DateTime GetSQLDateWhenNull(DateTime? Date)
        {
            if (Date is null)
            {
                var SQLDateTime = iGetSQLDateTime.GetSQLDateTimeSp(Date);
                Date = SQLDateTime.DateTime;
            }
            return Date.Value;
        }
    }
}
