//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadSystemVouchers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSCLM_LoadSystemVouchers
    {
        DataTable CHSCLM_LoadSystemVouchersSp();
    }

    public class CHSCLM_LoadSystemVouchers : ICHSCLM_LoadSystemVouchers
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CHSCLM_LoadSystemVouchers(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CHSCLM_LoadSystemVouchersSp()
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CHSCLM_LoadSystemVouchersSp";

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

