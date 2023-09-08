//PROJECT NAME: CSIEmployee
//CLASS NAME: ScanForMissingDECode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IScanForMissingDECode
    {
        int ScanForMissingDECodeSp(DateType YearStartDate,
                                   DateType YearEndDate,
                                   ref InfobarType PromptMsg,
                                   ref InfobarType PromptButtons);
    }

    public class ScanForMissingDECode : IScanForMissingDECode
    {
        readonly IApplicationDB appDB;

        public ScanForMissingDECode(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ScanForMissingDECodeSp(DateType YearStartDate,
                                          DateType YearEndDate,
                                          ref InfobarType PromptMsg,
                                          ref InfobarType PromptButtons)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ScanForMissingDECodeSp";

                appDB.AddCommandParameter(cmd, "YearStartDate", YearStartDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "YearEndDate", YearEndDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
