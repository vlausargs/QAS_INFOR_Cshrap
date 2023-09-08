//PROJECT NAME: CSICustomer
//CLASS NAME: ArBalanceHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArBalanceHistory
    {
        int ArBalanceHistorySp(CustNumType ParamBegCustNum,
                               CustNumType ParamEndCustNum,
                               DateType ParamThruDate,
                               FlagNyType ParamResetPeriod,
                               ref InfobarType Infobar,
                               ref IntType ParamRecCount,
                               DateOffsetType ThruDateOffset);
    }

    public class ArBalanceHistory : IArBalanceHistory
    {
        readonly IApplicationDB appDB;

        public ArBalanceHistory(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArBalanceHistorySp(CustNumType ParamBegCustNum,
                                      CustNumType ParamEndCustNum,
                                      DateType ParamThruDate,
                                      FlagNyType ParamResetPeriod,
                                      ref InfobarType Infobar,
                                      ref IntType ParamRecCount,
                                      DateOffsetType ThruDateOffset)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArBalanceHistorySp";

                appDB.AddCommandParameter(cmd, "ParamBegCustNum", ParamBegCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ParamEndCustNum", ParamEndCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ParamThruDate", ParamThruDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ParamResetPeriod", ParamResetPeriod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ParamRecCount", ParamRecCount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ThruDateOffset", ThruDateOffset, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
