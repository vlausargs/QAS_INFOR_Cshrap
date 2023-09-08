//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBLedgerPostingForJourDisplay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultiFSBLedgerPostingForJourDisplay
    {
        int MultiFSBLedgerPostingForJourDisplaySp(FSBNameType FSBName,
                                                  ref DateType RStartDate,
                                                  ref DateType REndDate,
                                                  ref InfobarType Infobar,
                                                  ref FiscalYearType StartingFiscalYear,
                                                  ref FiscalYearType EndingFiscalYear,
                                                  ref DateType FiscalYearStartDate,
                                                  ref DateType FiscalYearEndDate,
                                                  ref FlagNyType AvailChinFin);
    }

    public class MultiFSBLedgerPostingForJourDisplay : IMultiFSBLedgerPostingForJourDisplay
    {
        readonly IApplicationDB appDB;

        public MultiFSBLedgerPostingForJourDisplay(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultiFSBLedgerPostingForJourDisplaySp(FSBNameType FSBName,
                                                         ref DateType RStartDate,
                                                         ref DateType REndDate,
                                                         ref InfobarType Infobar,
                                                         ref FiscalYearType StartingFiscalYear,
                                                         ref FiscalYearType EndingFiscalYear,
                                                         ref DateType FiscalYearStartDate,
                                                         ref DateType FiscalYearEndDate,
                                                         ref FlagNyType AvailChinFin)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultiFSBLedgerPostingForJourDisplaySp";

                appDB.AddCommandParameter(cmd, "FSBName", FSBName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RStartDate", RStartDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "REndDate", REndDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "StartingFiscalYear", StartingFiscalYear, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EndingFiscalYear", EndingFiscalYear, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FiscalYearStartDate", FiscalYearStartDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FiscalYearEndDate", FiscalYearEndDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AvailChinFin", AvailChinFin, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}