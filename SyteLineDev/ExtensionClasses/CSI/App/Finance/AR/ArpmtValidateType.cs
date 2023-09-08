//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtValidateType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtValidateType
    {
        int ArpmtValidateTypeSp(ArpmtTypeType PType,
                                CustNumType PCustNum,
                                ArCheckNumType PCheckNum,
                                ref DateType PRecptDate,
                                ref AmountType PForCheckAmt,
                                ref ExchRateType PExchRate,
                                ref DateType PDueDate,
                                ref InfobarType PInfobar);
    }

    public class ArpmtValidateType : IArpmtValidateType
    {
        readonly IApplicationDB appDB;

        public ArpmtValidateType(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtValidateTypeSp(ArpmtTypeType PType,
                                       CustNumType PCustNum,
                                       ArCheckNumType PCheckNum,
                                       ref DateType PRecptDate,
                                       ref AmountType PForCheckAmt,
                                       ref ExchRateType PExchRate,
                                       ref DateType PDueDate,
                                       ref InfobarType PInfobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtValidateTypeSp";

                appDB.AddCommandParameter(cmd, "PType", PType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCheckNum", PCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRecptDate", PRecptDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PForCheckAmt", PForCheckAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PExchRate", PExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDueDate", PDueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PInfobar", PInfobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
