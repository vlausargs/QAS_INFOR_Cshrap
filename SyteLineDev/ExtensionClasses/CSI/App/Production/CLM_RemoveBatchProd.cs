//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_RemoveBatchProd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICLM_RemoveBatchProd
    {
        DataTable CLM_RemoveBatchProdSp(LongListType ProcSel,
                                        IntType SBatchID,
                                        IntType EBatchID,
                                        StringType SBatchDef,
                                        StringType EBatchDef,
                                        ref InfobarType Infobar);
    }

    public class CLM_RemoveBatchProd : ICLM_RemoveBatchProd
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_RemoveBatchProd(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_RemoveBatchProdSp(LongListType ProcSel,
                                               IntType SBatchID,
                                               IntType EBatchID,
                                               StringType SBatchDef,
                                               StringType EBatchDef,
                                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CLM_RemoveBatchProdSp";

                appDB.AddCommandParameter(cmd, "ProcSel", ProcSel, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SBatchID", SBatchID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EBatchID", EBatchID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SBatchDef", SBatchDef, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EBatchDef", EBatchDef, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
