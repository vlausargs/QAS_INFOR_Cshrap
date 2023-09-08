//PROJECT NAME: CSIFinance
//CLASS NAME: Home_GetTodaysKeyExecutiveValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IHome_GetTodaysKeyExecutiveValues
    {
        int Home_GetTodaysKeyExecutiveValuesSp(SiteGroupType SiteGroup,
                                               ref AmountType BookingAmount,
                                               ref AmountType ReceiptAmount,
                                               ref AmountType POFundAmount);
    }

    public class Home_GetTodaysKeyExecutiveValues : IHome_GetTodaysKeyExecutiveValues
    {
        readonly IApplicationDB appDB;

        public Home_GetTodaysKeyExecutiveValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int Home_GetTodaysKeyExecutiveValuesSp(SiteGroupType SiteGroup,
                                                      ref AmountType BookingAmount,
                                                      ref AmountType ReceiptAmount,
                                                      ref AmountType POFundAmount)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Home_GetTodaysKeyExecutiveValuesSp";

                appDB.AddCommandParameter(cmd, "SiteGroup", SiteGroup, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BookingAmount", BookingAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ReceiptAmount", ReceiptAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "POFundAmount", POFundAmount, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}