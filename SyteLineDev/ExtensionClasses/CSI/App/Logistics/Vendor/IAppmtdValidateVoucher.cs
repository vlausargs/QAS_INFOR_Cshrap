//PROJECT NAME: Logistics
//CLASS NAME: IAppmtdValidateVoucher.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtdValidateVoucher
    {
            (int? ReturnCode,
            string PApplyVend,
            string PName,
            DateTime? PDueDate,
            string PGrnNum,
            decimal? ForAmtDisc,
            decimal? ForAmtPaid,
            decimal? DomAmtDisc,
            decimal? DomAmtPaid,
            decimal? ExchRate,
            string AptrxpCurrCode,
            string PromptMsg,
            string PromptButtons,
            string Infobar) 
        AppmtdValidateVoucherSp(
            string PType,
            int? PVoucher,
            string PSite,
            string PBankCode,
            string PVendNum,
            int? PCheckSeq,
            string PApplyVend,
            string PName,
            DateTime? PDueDate,
            string PGrnNum,
            decimal? ForAmtDisc,
            decimal? ForAmtPaid,
            decimal? DomAmtDisc,
            decimal? DomAmtPaid,
            decimal? ExchRate,
            string AptrxpCurrCode,
            string PromptMsg,
            string PromptButtons,
            string Infobar);
    }
}

