//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_PostedVchTrnxSummary.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSCLM_PostedVchTrnxSummary
    {
        DataTable CHSCLM_PostedVchTrnxSummarySp(FiscalYearType FiscalYear,
                                                FinPeriodType Period,
                                                ListYesNoType DisplayAll,
                                                SortMethodType SortMethod,
                                                AcctOnlyType AcctFrom,
                                                PertotSortFieldType Unit1From,
                                                PertotSortFieldType Unit2From,
                                                PertotSortFieldType Unit3From,
                                                PertotSortFieldType Unit4From,
                                                AcctOnlyType AcctTo,
                                                PertotSortFieldType Unit1To,
                                                PertotSortFieldType Unit2To,
                                                PertotSortFieldType Unit3To,
                                                PertotSortFieldType Unit4To,
                                                RowPointerType SessionId,
                                                ref InfobarType Infobar);
    }

    public class CHSCLM_PostedVchTrnxSummary : ICHSCLM_PostedVchTrnxSummary
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CHSCLM_PostedVchTrnxSummary(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CHSCLM_PostedVchTrnxSummarySp(FiscalYearType FiscalYear,
                                                       FinPeriodType Period,
                                                       ListYesNoType DisplayAll,
                                                       SortMethodType SortMethod,
                                                       AcctOnlyType AcctFrom,
                                                       PertotSortFieldType Unit1From,
                                                       PertotSortFieldType Unit2From,
                                                       PertotSortFieldType Unit3From,
                                                       PertotSortFieldType Unit4From,
                                                       AcctOnlyType AcctTo,
                                                       PertotSortFieldType Unit1To,
                                                       PertotSortFieldType Unit2To,
                                                       PertotSortFieldType Unit3To,
                                                       PertotSortFieldType Unit4To,
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
                    cmd.CommandText = "CHSCLM_PostedVchTrnxSummarySp";

                    appDB.AddCommandParameter(cmd, "FiscalYear", FiscalYear, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Period", Period, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "DisplayAll", DisplayAll, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "SortMethod", SortMethod, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "AcctFrom", AcctFrom, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit1From", Unit1From, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit2From", Unit2From, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit3From", Unit3From, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit4From", Unit4From, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "AcctTo", AcctTo, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit1To", Unit1To, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit2To", Unit2To, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit3To", Unit3To, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Unit4To", Unit4To, ParameterDirection.Input);
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
