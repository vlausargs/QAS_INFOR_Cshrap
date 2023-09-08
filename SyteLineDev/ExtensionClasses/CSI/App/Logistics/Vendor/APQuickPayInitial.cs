//PROJECT NAME: CSIVendor
//CLASS NAME: APQuickPayInitial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAPQuickPayInitial
    {
        int APQuickPayInitialSp(string pBankCode,
                                string pVendNum,
                                string pPayType,
                                int? pCheckNum,
                                short? pCheckSeq,
                                DateTime? pCheckDate,
                                string pVendBankCode,
                                string pVendCurr,
                                string pParmsCurr,
                                ref byte? pEuroFixed,
                                ref decimal? pForApplied,
                                ref decimal? pDomApplied,
                                ref string pBankCurr,
                                ref byte? pDomBank,
                                ref DateTime? pDueDate,
                                ref string Infobar);
    }

    public class APQuickPayInitial : IAPQuickPayInitial
    {
        readonly IApplicationDB appDB;

        public APQuickPayInitial(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int APQuickPayInitialSp(string pBankCode,
                                       string pVendNum,
                                       string pPayType,
                                       int? pCheckNum,
                                       short? pCheckSeq,
                                       DateTime? pCheckDate,
                                       string pVendBankCode,
                                       string pVendCurr,
                                       string pParmsCurr,
                                       ref byte? pEuroFixed,
                                       ref decimal? pForApplied,
                                       ref decimal? pDomApplied,
                                       ref string pBankCurr,
                                       ref byte? pDomBank,
                                       ref DateTime? pDueDate,
                                       ref string Infobar)
        {
            BankCodeType _pBankCode = pBankCode;
            VendNumType _pVendNum = pVendNum;
            AppmtPayTypeType _pPayType = pPayType;
            ApCheckNumType _pCheckNum = pCheckNum;
            ApCheckSeqType _pCheckSeq = pCheckSeq;
            DateType _pCheckDate = pCheckDate;
            BankCodeType _pVendBankCode = pVendBankCode;
            CurrCodeType _pVendCurr = pVendCurr;
            CurrCodeType _pParmsCurr = pParmsCurr;
            ListYesNoType _pEuroFixed = pEuroFixed;
            AmountType _pForApplied = pForApplied;
            AmountType _pDomApplied = pDomApplied;
            CurrCodeType _pBankCurr = pBankCurr;
            ListYesNoType _pDomBank = pDomBank;
            DateType _pDueDate = pDueDate;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APQuickPayInitialSp";

                appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pVendNum", _pVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pPayType", _pPayType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCheckNum", _pCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCheckSeq", _pCheckSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCheckDate", _pCheckDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pVendBankCode", _pVendBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pVendCurr", _pVendCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pParmsCurr", _pParmsCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEuroFixed", _pEuroFixed, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pForApplied", _pForApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pDomApplied", _pDomApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pBankCurr", _pBankCurr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pDomBank", _pDomBank, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pDueDate", _pDueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                pEuroFixed = _pEuroFixed;
                pForApplied = _pForApplied;
                pDomApplied = _pDomApplied;
                pBankCurr = _pBankCurr;
                pDomBank = _pDomBank;
                pDueDate = _pDueDate;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
