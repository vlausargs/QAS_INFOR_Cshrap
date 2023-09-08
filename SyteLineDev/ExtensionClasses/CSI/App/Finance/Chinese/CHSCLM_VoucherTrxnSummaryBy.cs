//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_VoucherTrxnSummaryBy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSCLM_VoucherTrxnSummaryBy
    {
        DataTable CHSCLM_VoucherTrxnSummaryByAc(FiscalYearType FiscalYear,
                                                FinPeriodType Period,
                                                SortMethodType SortMethod,
                                                AcctType Acct,
                                                UnitCode1Type Unit1,
                                                UnitCode2Type Unit2,
                                                UnitCode3Type Unit3,
                                                UnitCode4Type Unit4,
                                                CurrCodeType CurrCode,
                                                RowPointerType SessionId,
                                                ref InfobarType Infobar);
    }

    public class CHSCLM_VoucherTrxnSummaryBy : ICHSCLM_VoucherTrxnSummaryBy
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CHSCLM_VoucherTrxnSummaryBy(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CHSCLM_VoucherTrxnSummaryByAc(FiscalYearType FiscalYear,
                                                       FinPeriodType Period,
                                                       SortMethodType SortMethod,
                                                       AcctType Acct,
                                                       UnitCode1Type Unit1,
                                                       UnitCode2Type Unit2,
                                                       UnitCode3Type Unit3,
                                                       UnitCode4Type Unit4,
                                                       CurrCodeType CurrCode,
                                                       RowPointerType SessionId,
                                                       ref InfobarType Infobar)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CHSCLM_VoucherTrxnSummaryByAc";

                    appDB.AddCommandParameter(cmd, "FiscalYear", FiscalYear, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Period", Period, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "SortMethod", SortMethod, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Acct", Acct, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit1", Unit1, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit2", Unit2, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit3", Unit3, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit4", Unit4, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "CurrCode", CurrCode, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "SessionId", SessionId, ParameterDirection.Input);
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