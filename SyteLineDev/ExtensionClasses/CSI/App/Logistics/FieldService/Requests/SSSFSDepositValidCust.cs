//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDepositValidCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSDepositValidCust
    {
        int SSSFSDepositValidCustSp(CustNumType CustNum,
                                    ref AmountType DepositAmt,
                                    ref InfobarType Infobar,
                                    ref InputMaskType CurAmtFormat,
                                    ref InputMaskType CurCstPriceFormat);
    }

    public class SSSFSDepositValidCust : ISSSFSDepositValidCust
    {
        readonly IApplicationDB appDB;

        public SSSFSDepositValidCust(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSDepositValidCustSp(CustNumType CustNum,
                                           ref AmountType DepositAmt,
                                           ref InfobarType Infobar,
                                           ref InputMaskType CurAmtFormat,
                                           ref InputMaskType CurCstPriceFormat)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSDepositValidCustSp";

                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DepositAmt", DepositAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurAmtFormat", CurAmtFormat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurCstPriceFormat", CurCstPriceFormat, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
