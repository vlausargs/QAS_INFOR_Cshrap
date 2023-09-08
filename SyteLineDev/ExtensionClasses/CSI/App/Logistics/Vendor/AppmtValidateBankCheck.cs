//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtValidateBankCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtValidateBankCheck
    {
        int AppmtValidateBankCheckSp(string PBankCode,
                                     string PVendNum,
                                     ref string Infobar,
                                     ref byte? pDomBank,
                                     ref string PBankCurrCode);
    }

    public class AppmtValidateBankCheck : IAppmtValidateBankCheck
    {
        readonly IApplicationDB appDB;

        public AppmtValidateBankCheck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtValidateBankCheckSp(string PBankCode,
                                            string PVendNum,
                                            ref string Infobar,
                                            ref byte? pDomBank,
                                            ref string PBankCurrCode)
        {
            BankCodeType _PBankCode = PBankCode;
            VendNumType _PVendNum = PVendNum;
            InfobarType _Infobar = Infobar;
            ListYesNoType _pDomBank = pDomBank;
            CurrCodeType _PBankCurrCode = PBankCurrCode;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppmtValidateBankCheckSp";

                appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pDomBank", _pDomBank, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PBankCurrCode", _PBankCurrCode, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;
                pDomBank = _pDomBank;
                PBankCurrCode = _PBankCurrCode;

                return Severity;
            }
        }
    }
}
