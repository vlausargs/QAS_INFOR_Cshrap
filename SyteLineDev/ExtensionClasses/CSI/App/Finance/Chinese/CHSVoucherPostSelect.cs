//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSVoucherPostSelect.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSVoucherPostSelect
    {
        DataTable CHSVoucherPostSelectSp(TransNatType TypeCodeFrom,
                                         TransNatType TypeCodeTo,
                                         GenericMedCodeType VoucherNoFrom,
                                         GenericMedCodeType VoucherNoTo,
                                         DateType TransDateFrom,
                                         DateType TransDateTo,
                                         UsernameType UserName);
    }

    public class CHSVoucherPostSelect : ICHSVoucherPostSelect
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CHSVoucherPostSelect(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CHSVoucherPostSelectSp(TransNatType TypeCodeFrom,
                                                TransNatType TypeCodeTo,
                                                GenericMedCodeType VoucherNoFrom,
                                                GenericMedCodeType VoucherNoTo,
                                                DateType TransDateFrom,
                                                DateType TransDateTo,
                                                UsernameType UserName)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CHSVoucherPostSelectSp";

                    appDB.AddCommandParameter(cmd, "TypeCodeFrom", TypeCodeFrom, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "TypeCodeTo", TypeCodeTo, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "VoucherNoFrom", VoucherNoFrom, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "VoucherNoTo", VoucherNoTo, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "TransDateFrom", TransDateFrom, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "TransDateTo", TransDateTo, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "UserName", UserName, ParameterDirection.Input);

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
