//PROJECT NAME: CSICustomer
//CLASS NAME: ARPaymentDistributeChargebacks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IARPaymentDistributeChargebacks
    {
        int ARPaymentDistributeChargebacksSp(CustNumType PCustNum,
                                             CustPayTypeType PType,
                                             ArCheckNumType PCheckNum,
                                             InvNumType PInvNum,
                                             RowPointerType ArpmtdRowpointer,
                                             CurrCodeType ArpmtdForCurrCode,
                                             ExchRateType ArpmtdExchRate,
                                             SiteType ArpmtdSite,
                                             DateType ArpmtRecptDate,
                                             ref InfobarType Infobar);
    }

    public class ARPaymentDistributeChargebacks : IARPaymentDistributeChargebacks
    {
        readonly IApplicationDB appDB;

        public ARPaymentDistributeChargebacks(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ARPaymentDistributeChargebacksSp(CustNumType PCustNum,
                                                    CustPayTypeType PType,
                                                    ArCheckNumType PCheckNum,
                                                    InvNumType PInvNum,
                                                    RowPointerType ArpmtdRowpointer,
                                                    CurrCodeType ArpmtdForCurrCode,
                                                    ExchRateType ArpmtdExchRate,
                                                    SiteType ArpmtdSite,
                                                    DateType ArpmtRecptDate,
                                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ARPaymentDistributeChargebacksSp";

                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PType", PType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCheckNum", PCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PInvNum", PInvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArpmtdRowpointer", ArpmtdRowpointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArpmtdForCurrCode", ArpmtdForCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArpmtdExchRate", ArpmtdExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArpmtdSite", ArpmtdSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArpmtRecptDate", ArpmtRecptDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
