//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_ReturnedChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface ICLM_ReturnedChecks
    {
        DataTable CLM_ReturnedChecksSp(BankCodeType BankCode,
                                       StringType Process,
                                       ListYesNoType ProcessReturnedCheck,
                                       ListYesNoType ProcessReturnedCheckDeposit);
    }

    public class CLM_ReturnedChecks : ICLM_ReturnedChecks
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_ReturnedChecks(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_ReturnedChecksSp(BankCodeType BankCode,
                                              StringType Process,
                                              ListYesNoType ProcessReturnedCheck,
                                              ListYesNoType ProcessReturnedCheckDeposit)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_ReturnedChecksSp";

                    appDB.AddCommandParameter(cmd, "BankCode", BankCode, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Process", Process, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ProcessReturnedCheck", ProcessReturnedCheck, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ProcessReturnedCheckDeposit", ProcessReturnedCheckDeposit, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}