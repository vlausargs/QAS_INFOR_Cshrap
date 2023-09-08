//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtdValidAppmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtdValidAppmt
    {
        int AppmtdValidAppmtSp(string VendNum,
                               string Level,
                               ref string PayType,
                               ref int? CheckNum,
                               ref short? CheckSeq,
                               ref DateTime? CheckDate,
                               ref string BankCode,
                               ref DateTime? DueDate,
                               ref string VendName,
                               ref string CurrCode,
                               ref decimal? ExchRate,
                               ref decimal? ForCheckAmt,
                               ref decimal? DomCheckAmt,
                               ref decimal? ForApplied,
                               ref decimal? DomApplied,
                               ref decimal? ForRemaining,
                               ref decimal? DomRemaining,
                               ref string CurrAmtFormat,
                               ref byte? PayHold,
                               ref string Infobar);
    }

    public class AppmtdValidAppmt : IAppmtdValidAppmt
    {
        readonly IApplicationDB appDB;

        public AppmtdValidAppmt(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtdValidAppmtSp(string VendNum,
                                      string Level,
                                      ref string PayType,
                                      ref int? CheckNum,
                                      ref short? CheckSeq,
                                      ref DateTime? CheckDate,
                                      ref string BankCode,
                                      ref DateTime? DueDate,
                                      ref string VendName,
                                      ref string CurrCode,
                                      ref decimal? ExchRate,
                                      ref decimal? ForCheckAmt,
                                      ref decimal? DomCheckAmt,
                                      ref decimal? ForApplied,
                                      ref decimal? DomApplied,
                                      ref decimal? ForRemaining,
                                      ref decimal? DomRemaining,
                                      ref string CurrAmtFormat,
                                      ref byte? PayHold,
                                      ref string Infobar)
        {
            VendNumType _VendNum = VendNum;
            StringType _Level = Level;
            AppmtPayTypeType _PayType = PayType;
            ApCheckNumType _CheckNum = CheckNum;
            ApCheckSeqType _CheckSeq = CheckSeq;
            DateType _CheckDate = CheckDate;
            BankCodeType _BankCode = BankCode;
            DateType _DueDate = DueDate;
            NameType _VendName = VendName;
            CurrCodeType _CurrCode = CurrCode;
            ExchRateType _ExchRate = ExchRate;
            AmountType _ForCheckAmt = ForCheckAmt;
            AmountType _DomCheckAmt = DomCheckAmt;
            AmountType _ForApplied = ForApplied;
            AmountType _DomApplied = DomApplied;
            AmountType _ForRemaining = ForRemaining;
            AmountType _DomRemaining = DomRemaining;
            InputMaskType _CurrAmtFormat = CurrAmtFormat;
            ListYesNoType _PayHold = PayHold;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppmtdValidAppmtSp";

                appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CheckSeq", _CheckSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VendName", _VendName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ForCheckAmt", _ForCheckAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DomCheckAmt", _DomCheckAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ForApplied", _ForApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DomApplied", _DomApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ForRemaining", _ForRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DomRemaining", _DomRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrAmtFormat", _CurrAmtFormat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PayHold", _PayHold, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PayType = _PayType;
                CheckNum = _CheckNum;
                CheckSeq = _CheckSeq;
                CheckDate = _CheckDate;
                BankCode = _BankCode;
                DueDate = _DueDate;
                VendName = _VendName;
                CurrCode = _CurrCode;
                ExchRate = _ExchRate;
                ForCheckAmt = _ForCheckAmt;
                DomCheckAmt = _DomCheckAmt;
                ForApplied = _ForApplied;
                DomApplied = _DomApplied;
                ForRemaining = _ForRemaining;
                DomRemaining = _DomRemaining;
                CurrAmtFormat = _CurrAmtFormat;
                PayHold = _PayHold;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
