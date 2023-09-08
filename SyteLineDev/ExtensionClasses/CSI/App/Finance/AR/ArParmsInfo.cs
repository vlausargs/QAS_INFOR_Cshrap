//PROJECT NAME: CSICustomer
//CLASS NAME: ArParmsInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArParmsInfo
    {
        int ArParmsInfoSp(ref ListAmountPercentType ReturnedCheckFeeType,
                          ref AmountType ReturnedCheckFeeValue,
                          ref ListDebitMemoAdjustmentType ReturnedCheckMethod,
                          ref InfobarType Infobar);
    }

    public class ArParmsInfo : IArParmsInfo
    {
        readonly IApplicationDB appDB;

        public ArParmsInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArParmsInfoSp(ref ListAmountPercentType ReturnedCheckFeeType,
                                 ref AmountType ReturnedCheckFeeValue,
                                 ref ListDebitMemoAdjustmentType ReturnedCheckMethod,
                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArParmsInfoSp";

                appDB.AddCommandParameter(cmd, "ReturnedCheckFeeType", ReturnedCheckFeeType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ReturnedCheckFeeValue", ReturnedCheckFeeValue, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ReturnedCheckMethod", ReturnedCheckMethod, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
