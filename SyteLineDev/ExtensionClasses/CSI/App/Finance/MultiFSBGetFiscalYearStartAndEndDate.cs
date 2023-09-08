//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBGetFiscalYearStartAndEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultiFSBGetFiscalYearStartAndEndDate
    {
        int MultiFSBGetFiscalYearStartAndEndDateSp(FSBNameType FSBName,
                                                   FiscalYearType FiscalYear,
                                                   ref DateType FiscalYearStartDate,
                                                   ref DateType FiscalYearEndDate,
                                                   ref InfobarType Infobar);
    }

    public class MultiFSBGetFiscalYearStartAndEndDate : IMultiFSBGetFiscalYearStartAndEndDate
    {
        readonly IApplicationDB appDB;

        public MultiFSBGetFiscalYearStartAndEndDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultiFSBGetFiscalYearStartAndEndDateSp(FSBNameType FSBName,
                                                          FiscalYearType FiscalYear,
                                                          ref DateType FiscalYearStartDate,
                                                          ref DateType FiscalYearEndDate,
                                                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultiFSBGetFiscalYearStartAndEndDateSp";

                appDB.AddCommandParameter(cmd, "FSBName", FSBName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FiscalYear", FiscalYear, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FiscalYearStartDate", FiscalYearStartDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FiscalYearEndDate", FiscalYearEndDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
