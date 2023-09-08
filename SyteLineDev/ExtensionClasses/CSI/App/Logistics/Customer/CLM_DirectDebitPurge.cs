//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_DirectDebitPurge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICLM_DirectDebitPurge
    {
        DataTable CLM_DirectDebitPurgeSp(DirectDebitNumType pStartDirectDebitNum,
                                         DirectDebitNumType pEndDirectDebitNum,
                                         InfobarType pStatus,
                                         ListYesNoType pCommit,
                                         ref InfobarType Infobar);
    }

    public class CLM_DirectDebitPurge : ICLM_DirectDebitPurge
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_DirectDebitPurge(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_DirectDebitPurgeSp(DirectDebitNumType pStartDirectDebitNum,
                                                DirectDebitNumType pEndDirectDebitNum,
                                                InfobarType pStatus,
                                                ListYesNoType pCommit,
                                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CLM_DirectDebitPurgeSp";

                appDB.AddCommandParameter(cmd, "pStartDirectDebitNum", pStartDirectDebitNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndDirectDebitNum", pEndDirectDebitNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStatus", pStatus, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCommit", pCommit, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
