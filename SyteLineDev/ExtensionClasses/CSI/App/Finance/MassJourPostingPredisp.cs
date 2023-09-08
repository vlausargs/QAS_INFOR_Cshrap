//PROJECT NAME: CSIFinance
//CLASS NAME: MassJourPostingPredisp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMassJourPostingPredisp
    {
        int MassJourPostingPredispSP(ref DateType RStartDate,
                                     ref DateType REndDate,
                                     ref DateType FiscalYearStartDate,
                                     ref DateType FiscalYearEndDate,
                                     ref FiscalYearType FiscalYear,
                                     ref InfobarType ROutOfRange,
                                     ref InfobarType RToPost,
                                     ref InfobarType RToPrint,
                                     ref InfobarType RPosted,
                                     ref InfobarType REmpty,
                                     ref InfobarType Infobar,
                                     ref FlagNyType AvailChinFin);
    }

    public class MassJourPostingPredisp : IMassJourPostingPredisp
    {
        readonly IApplicationDB appDB;

        public MassJourPostingPredisp(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MassJourPostingPredispSP(ref DateType RStartDate,
                                            ref DateType REndDate,
                                            ref DateType FiscalYearStartDate,
                                            ref DateType FiscalYearEndDate,
                                            ref FiscalYearType FiscalYear,
                                            ref InfobarType ROutOfRange,
                                            ref InfobarType RToPost,
                                            ref InfobarType RToPrint,
                                            ref InfobarType RPosted,
                                            ref InfobarType REmpty,
                                            ref InfobarType Infobar,
                                            ref FlagNyType AvailChinFin)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MassJourPostingPredispSP";

                appDB.AddCommandParameter(cmd, "RStartDate", RStartDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "REndDate", REndDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FiscalYearStartDate", FiscalYearStartDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FiscalYearEndDate", FiscalYearEndDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FiscalYear", FiscalYear, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ROutOfRange", ROutOfRange, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RToPost", RToPost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RToPrint", RToPrint, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RPosted", RPosted, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "REmpty", REmpty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AvailChinFin", AvailChinFin, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

