//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtRecptDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtRecptDate
    {
        int ArpmtRecptDateSp(CustNumType PCustNum,
                             CurrCodeType PBankCurrCode,
                             ArCheckNumType PCheckNum,
                             ArpmtTypeType PType,
                             DateType PRecptDate,
                             AmountType PDomCheckAmt,
                             ref LongListType POpenType,
                             ref LongListType POpenCode,
                             ref DateType PDueDate,
                             ref ExchRateType PExchRate,
                             ref InfobarType Infobar);
    }

    public class ArpmtRecptDate : IArpmtRecptDate
    {
        readonly IApplicationDB appDB;

        public ArpmtRecptDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtRecptDateSp(CustNumType PCustNum,
                                    CurrCodeType PBankCurrCode,
                                    ArCheckNumType PCheckNum,
                                    ArpmtTypeType PType,
                                    DateType PRecptDate,
                                    AmountType PDomCheckAmt,
                                    ref LongListType POpenType,
                                    ref LongListType POpenCode,
                                    ref DateType PDueDate,
                                    ref ExchRateType PExchRate,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtRecptDateSp";

                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCurrCode", PBankCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCheckNum", PCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PType", PType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRecptDate", PRecptDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDomCheckAmt", PDomCheckAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "POpenType", POpenType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "POpenCode", POpenCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDueDate", PDueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PExchRate", PExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
