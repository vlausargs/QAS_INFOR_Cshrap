//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadBankBook.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSCLM_LoadBankBook
    {
        DataTable CHSCLM_LoadBankBookSp(BankCodeType PBankCode,
                                        DateType PDateFrom,
                                        DateType PDateTo);
    }

    public class CHSCLM_LoadBankBook : ICHSCLM_LoadBankBook
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CHSCLM_LoadBankBook(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CHSCLM_LoadBankBookSp(BankCodeType PBankCode,
                                               DateType PDateFrom,
                                               DateType PDateTo)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CHSCLM_LoadBankBookSp";

                    appDB.AddCommandParameter(cmd, "PBankCode", PBankCode, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PDateFrom", PDateFrom, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PDateTo", PDateTo, ParameterDirection.Input);

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
