//PROJECT NAME: CSICustomer
//CLASS NAME: Home_GetTodaysKeyControllerValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHome_GetTodaysKeyControllerValues
    {
        int Home_GetTodaysKeyControllerValuesSp(ref decimal? BookingAmount,
                                                ref decimal? ShipmentAmount,
                                                ref decimal? InvoicedAmount);
    }

    public class Home_GetTodaysKeyControllerValues : IHome_GetTodaysKeyControllerValues
    {
        readonly IApplicationDB appDB;

        public Home_GetTodaysKeyControllerValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int Home_GetTodaysKeyControllerValuesSp(ref decimal? BookingAmount,
                                                       ref decimal? ShipmentAmount,
                                                       ref decimal? InvoicedAmount)
        {
            AmountType _BookingAmount = BookingAmount;
            AmountType _ShipmentAmount = ShipmentAmount;
            AmountType _InvoicedAmount = InvoicedAmount;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Home_GetTodaysKeyControllerValuesSp";

                appDB.AddCommandParameter(cmd, "BookingAmount", _BookingAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ShipmentAmount", _ShipmentAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InvoicedAmount", _InvoicedAmount, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                BookingAmount = _BookingAmount;
                ShipmentAmount = _ShipmentAmount;
                InvoicedAmount = _InvoicedAmount;

                return Severity;
            }
        }
    }
}
