//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_DraftPurge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Drafts
{
    public interface ICLM_DraftPurge
    {
        DataTable CLM_DraftPurgeSp(IntType pStartDraftNum,
                                   IntType pEndDraftNum,
                                   InfobarType pStatus,
                                   Flag pCommit,
                                   ref InfobarType Infobar);
    }

    public class CLM_DraftPurge : ICLM_DraftPurge
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_DraftPurge(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_DraftPurgeSp(IntType pStartDraftNum,
                                          IntType pEndDraftNum,
                                          InfobarType pStatus,
                                          Flag pCommit,
                                          ref InfobarType Infobar)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_DraftPurgeSp";

                    appDB.AddCommandParameter(cmd, "pStartDraftNum", pStartDraftNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pEndDraftNum", pEndDraftNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pStatus", pStatus, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pCommit", pCommit, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

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