//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_PostedVchTrnxByVucher.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSCLM_PostedVchTrnxByVucher
    {
        DataTable CHSCLM_PostedVchTrnxByVucherSp(GenericMedCodeType StartingVoucherNumber,
                                                 GenericMedCodeType EndingVoucherNumber,
                                                 DateType Trans_Date,
                                                 FlagNyType Rubric,
                                                 RowPointerType SessionId,
                                                 ref InfobarType Infobar);
    }

    public class CHSCLM_PostedVchTrnxByVucher : ICHSCLM_PostedVchTrnxByVucher
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CHSCLM_PostedVchTrnxByVucher(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CHSCLM_PostedVchTrnxByVucherSp(GenericMedCodeType StartingVoucherNumber,
                                                        GenericMedCodeType EndingVoucherNumber,
                                                        DateType Trans_Date,
                                                        FlagNyType Rubric,
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
                    cmd.CommandText = "CHSCLM_PostedVchTrnxByVucherSp";

                    appDB.AddCommandParameter(cmd, "StartingVoucherNumber", StartingVoucherNumber, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "EndingVoucherNumber", EndingVoucherNumber, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Trans_Date", Trans_Date, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Rubric", Rubric, ParameterDirection.Input);
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

