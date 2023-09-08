//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBConfirmMap.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultiFSBConfirmMap
    {
        int MultiFSBConfirmMapSp(FSBChartOfAcctNameType Name,
                                 ref InfobarType Infobar);
    }

    public class MultiFSBConfirmMap : IMultiFSBConfirmMap
    {
        readonly IApplicationDB appDB;

        public MultiFSBConfirmMap(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultiFSBConfirmMapSp(FSBChartOfAcctNameType Name,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultiFSBConfirmMapSp";

                appDB.AddCommandParameter(cmd, "Name", Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
