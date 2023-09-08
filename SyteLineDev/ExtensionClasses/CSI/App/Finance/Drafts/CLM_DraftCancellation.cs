//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_DraftCancellation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Drafts
{
    public interface ICLM_DraftCancellation
    {
        DataTable CLM_DraftCancellationSp(HighLowCharType pStartCustNum,
                                          HighLowCharType pEndCustNum,
                                          DraftNumType pStartDraftNum,
                                          DraftNumType pEndDraftNum,
                                          Flag pCommit,
                                          ref InfobarType Infobar);
    }

    public class CLM_DraftCancellation : ICLM_DraftCancellation
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_DraftCancellation(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_DraftCancellationSp(HighLowCharType pStartCustNum,
                                                 HighLowCharType pEndCustNum,
                                                 DraftNumType pStartDraftNum,
                                                 DraftNumType pEndDraftNum,
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
                    cmd.CommandText = "CLM_DraftCancellationSp";

                    appDB.AddCommandParameter(cmd, "pStartCustNum", pStartCustNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pEndCustNum", pEndCustNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pStartDraftNum", pStartDraftNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pEndDraftNum", pEndDraftNum, ParameterDirection.Input);
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