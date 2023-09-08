//PROJECT NAME: CSICustomer
//CLASS NAME: Customer360_GetOverviewValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICustomer360_GetOverviewValues
    {
        int Customer360_GetOverviewValuesSp(string CustNum,
                                            ref decimal? AvailableLimit,
                                            ref decimal? LateOrders,
                                            ref decimal? BookingAmount);
    }

    public class Customer360_GetOverviewValues : ICustomer360_GetOverviewValues
    {
        readonly IApplicationDB appDB;

        public Customer360_GetOverviewValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int Customer360_GetOverviewValuesSp(string CustNum,
                                                   ref decimal? AvailableLimit,
                                                   ref decimal? LateOrders,
                                                   ref decimal? BookingAmount)
        {
            CustNumType _CustNum = CustNum;
            AmountType _AvailableLimit = AvailableLimit;
            AmountType _LateOrders = LateOrders;
            AmountType _BookingAmount = BookingAmount;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Customer360_GetOverviewValuesSp";

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AvailableLimit", _AvailableLimit, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LateOrders", _LateOrders, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BookingAmount", _BookingAmount, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                AvailableLimit = _AvailableLimit;
                LateOrders = _LateOrders;
                BookingAmount = _BookingAmount;

                return Severity;
            }
        }
    }
}
