//PROJECT NAME: CSIFinance
//CLASS NAME: VoidDrfAr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IVoidDrfAr
    {
        DataTable VoidDrfArSp(DraftNumType pStartDraftNum,
                              DraftNumType pEndDraftNum,
                              ref InfobarType rInfobar);
    }

    public class VoidDrfAr : IVoidDrfAr
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public VoidDrfAr(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable VoidDrfArSp(DraftNumType pStartDraftNum,
                                     DraftNumType pEndDraftNum,
                                     ref InfobarType rInfobar)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "VoidDrfArSp";

                    appDB.AddCommandParameter(cmd, "pStartDraftNum", pStartDraftNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "pEndDraftNum", pEndDraftNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "rInfobar", rInfobar, ParameterDirection.InputOutput);

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