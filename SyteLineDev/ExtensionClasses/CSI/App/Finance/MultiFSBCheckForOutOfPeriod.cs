//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBCheckForOutOfPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultiFSBCheckForOutOfPeriod
    {
        int MultiFSBCheckForOutOfPeriodSp(FSBNameType FSBName,
                                          RowPointerType PSessionID,
                                          ref ListYesNoType OutOfPeriod,
                                          ref ListYesNoType Closed,
                                          ref FiscalYearType FiscalYear,
                                          ref InfobarType Infobar);
    }

    public class MultiFSBCheckForOutOfPeriod : IMultiFSBCheckForOutOfPeriod
    {
        readonly IApplicationDB appDB;

        public MultiFSBCheckForOutOfPeriod(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultiFSBCheckForOutOfPeriodSp(FSBNameType FSBName,
                                                 RowPointerType PSessionID,
                                                 ref ListYesNoType OutOfPeriod,
                                                 ref ListYesNoType Closed,
                                                 ref FiscalYearType FiscalYear,
                                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultiFSBCheckForOutOfPeriodSp";

                appDB.AddCommandParameter(cmd, "FSBName", FSBName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutOfPeriod", OutOfPeriod, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Closed", Closed, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FiscalYear", FiscalYear, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
