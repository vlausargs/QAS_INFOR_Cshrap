//PROJECT NAME: CSICustomer
//CLASS NAME: CustomerDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICustomerDueDate
    {
        int CustomerDueDateSp(string CustNum,
                              DateTime? CloseDate,
                              ref DateTime? DueDate);
    }

    public class CustomerDueDate : ICustomerDueDate
    {
        readonly IApplicationDB appDB;

        public CustomerDueDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CustomerDueDateSp(string CustNum,
                                     DateTime? CloseDate,
                                     ref DateTime? DueDate)
        {
            CustNumType _CustNum = CustNum;
            DateType _CloseDate = CloseDate;
            DateType _DueDate = DueDate;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CustomerDueDateSp";

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CloseDate", _CloseDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                DueDate = _DueDate;

                return Severity;
            }
        }
    }
}
