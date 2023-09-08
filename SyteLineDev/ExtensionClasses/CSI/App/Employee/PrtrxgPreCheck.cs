//PROJECT NAME: CSIEmployee
//CLASS NAME: PrtrxgPreCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPrtrxgPreCheck
    {
        int PrtrxgPreCheckSp(ref DateType PStartDate,
                             ref DateType PEndDate,
                             ref LongListType PIncPayFreq,
                             ref ListYesNoType PJobTrx,
                             ref ListYesNoType PTimeAttend,
                             ref ListYesNoType PPrComm,
                             ref DateType PCheckDate,
                             ref InfobarType PromptMsg,
                             ref Infobar PromptButtons,
                             ref InfobarType Infobar);
    }

    public class PrtrxgPreCheck : IPrtrxgPreCheck
    {
        readonly IApplicationDB appDB;

        public PrtrxgPreCheck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PrtrxgPreCheckSp(ref DateType PStartDate,
                                    ref DateType PEndDate,
                                    ref LongListType PIncPayFreq,
                                    ref ListYesNoType PJobTrx,
                                    ref ListYesNoType PTimeAttend,
                                    ref ListYesNoType PPrComm,
                                    ref DateType PCheckDate,
                                    ref InfobarType PromptMsg,
                                    ref Infobar PromptButtons,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PrtrxgPreCheckSp";

                appDB.AddCommandParameter(cmd, "PStartDate", PStartDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PEndDate", PEndDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PIncPayFreq", PIncPayFreq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PJobTrx", PJobTrx, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PTimeAttend", PTimeAttend, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PPrComm", PPrComm, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PCheckDate", PCheckDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
