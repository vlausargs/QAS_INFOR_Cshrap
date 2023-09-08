//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_ShowLedger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSCLM_ShowLedger
    {
        DataTable CHSCLM_ShowLedgerSp(DateType BegDate,
                                      DateType EndDate,
                                      GenericMedCodeType BegCHVounum,
                                      GenericMedCodeType EndCHVounum,
                                      ref InfobarType InfoBar);
    }

    public class CHSCLM_ShowLedger : ICHSCLM_ShowLedger
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CHSCLM_ShowLedger(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CHSCLM_ShowLedgerSp(DateType BegDate,
                                             DateType EndDate,
                                             GenericMedCodeType BegCHVounum,
                                             GenericMedCodeType EndCHVounum,
                                             ref InfobarType InfoBar)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CHSCLM_ShowLedgerSp";

                    appDB.AddCommandParameter(cmd, "BegDate", BegDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "EndDate", EndDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "BegCHVounum", BegCHVounum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "EndCHVounum", EndCHVounum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "InfoBar", InfoBar, ParameterDirection.InputOutput);

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

