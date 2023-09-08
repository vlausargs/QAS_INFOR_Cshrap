//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtdValidateInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtdValidateInvoice
    {
        int AppmtdValidateInvoiceSp(string PType,
                                    string PSite,
                                    string PBankCode,
                                    string PVendNum,
                                    short? PCheckSeq,
                                    string PApplyVendNum,
                                    string PInvNum,
                                    byte? PGetDeflt,
                                    byte? PValInvNum,
                                    ref decimal? PNewAmtDisc,
                                    ref decimal? PNewAmtPaid,
                                    ref decimal? PDomTcAmtPaid,
                                    ref decimal? PDomTcAmtDisc,
                                    ref string Infobar);
    }

    public class AppmtdValidateInvoice : IAppmtdValidateInvoice
    {
        readonly IApplicationDB appDB;

        public AppmtdValidateInvoice(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtdValidateInvoiceSp(string PType,
                                           string PSite,
                                           string PBankCode,
                                           string PVendNum,
                                           short? PCheckSeq,
                                           string PApplyVendNum,
                                           string PInvNum,
                                           byte? PGetDeflt,
                                           byte? PValInvNum,
                                           ref decimal? PNewAmtDisc,
                                           ref decimal? PNewAmtPaid,
                                           ref decimal? PDomTcAmtPaid,
                                           ref decimal? PDomTcAmtDisc,
                                           ref string Infobar)
        {
            AppmtdTypeType _PType = PType;
            SiteType _PSite = PSite;
            BankCodeType _PBankCode = PBankCode;
            VendNumType _PVendNum = PVendNum;
            ApCheckSeqType _PCheckSeq = PCheckSeq;
            VendNumType _PApplyVendNum = PApplyVendNum;
            InvNumType _PInvNum = PInvNum;
            FlagNyType _PGetDeflt = PGetDeflt;
            FlagNyType _PValInvNum = PValInvNum;
            AmountType _PNewAmtDisc = PNewAmtDisc;
            AmountType _PNewAmtPaid = PNewAmtPaid;
            AmountType _PDomTcAmtPaid = PDomTcAmtPaid;
            AmountType _PDomTcAmtDisc = PDomTcAmtDisc;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppmtdValidateInvoiceSp";

                appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PApplyVendNum", _PApplyVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PGetDeflt", _PGetDeflt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PValInvNum", _PValInvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PNewAmtDisc", _PNewAmtDisc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PNewAmtPaid", _PNewAmtPaid, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDomTcAmtPaid", _PDomTcAmtPaid, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDomTcAmtDisc", _PDomTcAmtDisc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PNewAmtDisc = _PNewAmtDisc;
                PNewAmtPaid = _PNewAmtPaid;
                PDomTcAmtPaid = _PDomTcAmtPaid;
                PDomTcAmtDisc = _PDomTcAmtDisc;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}

