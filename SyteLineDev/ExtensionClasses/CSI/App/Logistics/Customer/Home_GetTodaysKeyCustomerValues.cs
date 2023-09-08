//PROJECT NAME: CSICustomer
//CLASS NAME: Home_GetTodaysKeyCustomerValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHome_GetTodaysKeyCustomerValues
    {
        int Home_GetTodaysKeyCustomerValuesSp(ref AmountType LateAmount,
                                              ref AmountType BookingAmount,
                                              ref AmountType ReturnAmount);
    }

    public class Home_GetTodaysKeyCustomerValues : IHome_GetTodaysKeyCustomerValues
    {
        readonly IApplicationDB appDB;

        public Home_GetTodaysKeyCustomerValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int Home_GetTodaysKeyCustomerValuesSp(ref AmountType LateAmount,
                                                     ref AmountType BookingAmount,
                                                     ref AmountType ReturnAmount)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Home_GetTodaysKeyCustomerValuesSp";

                appDB.AddCommandParameter(cmd, "LateAmount", LateAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BookingAmount", BookingAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ReturnAmount", ReturnAmount, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
