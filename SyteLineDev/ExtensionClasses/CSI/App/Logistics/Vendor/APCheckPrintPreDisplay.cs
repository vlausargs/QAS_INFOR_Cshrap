//PROJECT NAME: CSIVendor
//CLASS NAME: APCheckPrintPreDisplay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAPCheckPrintPreDisplay
    {
        int APCheckPrintPreDisplaySp(string PayType,
                                     ref string BankCode,
                                     ref int? NextCheckNumber,
                                     ref string PEFTBankcode,
                                     ref string PEFTFormat,
                                     ref string PEFTUserName,
                                     ref string PEFTUserNumber,
                                     ref byte? PPrintManualRemitAdvice,
                                     ref byte? PPrintEFTRemitAdvice,
                                     ref byte? PPrintWireRemitAdvice,
                                     ref byte? PPrintDraftRemitAdvice,
                                     ref string Infobar);
    }

    public class APCheckPrintPreDisplay : IAPCheckPrintPreDisplay
    {
        readonly IApplicationDB appDB;

        public APCheckPrintPreDisplay(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int APCheckPrintPreDisplaySp(string PayType,
                                            ref string BankCode,
                                            ref int? NextCheckNumber,
                                            ref string PEFTBankcode,
                                            ref string PEFTFormat,
                                            ref string PEFTUserName,
                                            ref string PEFTUserNumber,
                                            ref byte? PPrintManualRemitAdvice,
                                            ref byte? PPrintEFTRemitAdvice,
                                            ref byte? PPrintWireRemitAdvice,
                                            ref byte? PPrintDraftRemitAdvice,
                                            ref string Infobar)
        {
            LongList _PayType = PayType;
            BankCodeType _BankCode = BankCode;
            GlCheckNumType _NextCheckNumber = NextCheckNumber;
            BankCodeType _PEFTBankcode = PEFTBankcode;
            EFTFormatType _PEFTFormat = PEFTFormat;
            EFTUserNameType _PEFTUserName = PEFTUserName;
            EFTUserNumberType _PEFTUserNumber = PEFTUserNumber;
            ListYesNoType _PPrintManualRemitAdvice = PPrintManualRemitAdvice;
            ListYesNoType _PPrintEFTRemitAdvice = PPrintEFTRemitAdvice;
            ListYesNoType _PPrintWireRemitAdvice = PPrintWireRemitAdvice;
            ListYesNoType _PPrintDraftRemitAdvice = PPrintDraftRemitAdvice;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APCheckPrintPreDisplaySp";

                appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NextCheckNumber", _NextCheckNumber, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PEFTBankcode", _PEFTBankcode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PEFTFormat", _PEFTFormat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PEFTUserName", _PEFTUserName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PEFTUserNumber", _PEFTUserNumber, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PPrintManualRemitAdvice", _PPrintManualRemitAdvice, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PPrintEFTRemitAdvice", _PPrintEFTRemitAdvice, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PPrintWireRemitAdvice", _PPrintWireRemitAdvice, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PPrintDraftRemitAdvice", _PPrintDraftRemitAdvice, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                BankCode = _BankCode;
                NextCheckNumber = _NextCheckNumber;
                PEFTBankcode = _PEFTBankcode;
                PEFTFormat = _PEFTFormat;
                PEFTUserName = _PEFTUserName;
                PEFTUserNumber = _PEFTUserNumber;
                PPrintManualRemitAdvice = _PPrintManualRemitAdvice;
                PPrintEFTRemitAdvice = _PPrintEFTRemitAdvice;
                PPrintWireRemitAdvice = _PPrintWireRemitAdvice;
                PPrintDraftRemitAdvice = _PPrintDraftRemitAdvice;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
