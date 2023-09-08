//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtGetCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtGetCheck
    {
        int AppmtGetCheckSp(string PBankCode,
                            int? PCheckNum,
                            string PVendNum,
                            string PPayType,
                            ref decimal? PForCheckAmt,
                            ref decimal? PDomCheckAmt,
                            ref decimal? PExchRate,
                            ref DateTime? PCheckDate,
                            ref string PRef,
                            ref string Infobar);
    }

    public class AppmtGetCheck : IAppmtGetCheck
    {
        readonly IApplicationDB appDB;

        public AppmtGetCheck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtGetCheckSp(string PBankCode,
                                   int? PCheckNum,
                                   string PVendNum,
                                   string PPayType,
                                   ref decimal? PForCheckAmt,
                                   ref decimal? PDomCheckAmt,
                                   ref decimal? PExchRate,
                                   ref DateTime? PCheckDate,
                                   ref string PRef,
                                   ref string Infobar)
        {
            BankCodeType _PBankCode = PBankCode;
            ApCheckNumType _PCheckNum = PCheckNum;
            VendNumType _PVendNum = PVendNum;
            LongListType _PPayType = PPayType;
            AmountType _PForCheckAmt = PForCheckAmt;
            AmountType _PDomCheckAmt = PDomCheckAmt;
            ExchRateType _PExchRate = PExchRate;
            DateTimeType _PCheckDate = PCheckDate;
            ReferenceType _PRef = PRef;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppmtGetCheckSp";

                appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PForCheckAmt", _PForCheckAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDomCheckAmt", _PDomCheckAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PCheckDate", _PCheckDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PRef", _PRef, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PForCheckAmt = _PForCheckAmt;
                PDomCheckAmt = _PDomCheckAmt;
                PExchRate = _PExchRate;
                PCheckDate = _PCheckDate;
                PRef = _PRef;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
