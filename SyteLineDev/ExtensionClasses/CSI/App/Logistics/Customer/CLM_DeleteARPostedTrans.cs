//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_DeleteARPostedTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICLM_DeleteARPostedTrans
    {
        DataTable CLM_DeleteARPostedTransSp(DateType pThruDate,
                                            InfobarType pStateCycle,
                                            HighLowCharType pStartCustNum,
                                            HighLowCharType pEndCustNum,
                                            Flag pCommit,
                                            ref InfobarType Infobar);
    }

    public class CLM_DeleteARPostedTrans : ICLM_DeleteARPostedTrans
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_DeleteARPostedTrans(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_DeleteARPostedTransSp(DateType pThruDate,
                                                   InfobarType pStateCycle,
                                                   HighLowCharType pStartCustNum,
                                                   HighLowCharType pEndCustNum,
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
                    cmd.CommandText = "CLM_DeleteARPostedTransSp";

                    appDB.AddCommandParameter(cmd, "pThruDate", pThruDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pStateCycle", pStateCycle, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pStartCustNum", pStartCustNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pEndCustNum", pEndCustNum, ParameterDirection.Input);
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
