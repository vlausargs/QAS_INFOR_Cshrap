//PROJECT NAME: CSIFinance
//CLASS NAME: GLYearEndClosingInputCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IGLYearEndClosingInputCheck
    {
        int GLYearEndClosingInputCheckSp(JournalIdType CurId,
                                         AcctType IncomeSummaryAccount,
                                         Flag DeleteCurrentJournalEntries,
                                         Flag UnitCodeDetail,
                                         DateType FiscalYearBegDate,
                                         DateType FiscalYearEndDate,
                                         ref InfobarType Infobar);
    }

    public class GLYearEndClosingInputCheck : IGLYearEndClosingInputCheck
    {
        readonly IApplicationDB appDB;

        public GLYearEndClosingInputCheck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GLYearEndClosingInputCheckSp(JournalIdType CurId,
                                                AcctType IncomeSummaryAccount,
                                                Flag DeleteCurrentJournalEntries,
                                                Flag UnitCodeDetail,
                                                DateType FiscalYearBegDate,
                                                DateType FiscalYearEndDate,
                                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GLYearEndClosingInputCheckSp";

                appDB.AddCommandParameter(cmd, "CurId", CurId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IncomeSummaryAccount", IncomeSummaryAccount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DeleteCurrentJournalEntries", DeleteCurrentJournalEntries, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UnitCodeDetail", UnitCodeDetail, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FiscalYearBegDate", FiscalYearBegDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FiscalYearEndDate", FiscalYearEndDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}