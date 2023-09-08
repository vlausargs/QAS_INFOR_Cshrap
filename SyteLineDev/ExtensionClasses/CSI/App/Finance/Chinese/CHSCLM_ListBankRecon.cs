//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_ListBankRecon.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSCLM_ListBankRecon
    {
        DataTable CHSCLM_ListBankReconSp(RowPointerType PSessionID);
    }

    public class CHSCLM_ListBankRecon : ICHSCLM_ListBankRecon
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CHSCLM_ListBankRecon(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CHSCLM_ListBankReconSp(RowPointerType PSessionID)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CHSCLM_ListBankReconSp";

                    appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);

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
