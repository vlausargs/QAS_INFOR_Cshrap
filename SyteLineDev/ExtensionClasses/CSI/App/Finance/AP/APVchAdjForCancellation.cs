﻿//PROJECT NAME: CSIVendor
//CLASS NAME: APVchAdjForCancellation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AP
{
    public interface IAPVchAdjForCancellation
    {
        int APVchAdjForCancellationSp(VendNumType VendNum,
                                      VoucherType Voucher,
                                      ref PoNumType PoNum,
                                      ref VendInvNumType InvNum,
                                      ref DueDaysType DueDays,
                                      ref ProxDayType ProxDay,
                                      ref DateType DueDate,
                                      ref DiscDaysType DiscDays,
                                      ref DateType DiscDate,
                                      ref ApDiscType DiscPct,
                                      ref AcctType ApAcct,
                                      ref UnitCode1Type ApAcctUnit1,
                                      ref UnitCode2Type ApAcctUnit2,
                                      ref UnitCode3Type ApAcctUnit3,
                                      ref UnitCode4Type ApAcctUnit4,
                                      ref TaxCodeType TaxCode1,
                                      ref TaxCodeType TaxCode2,
                                      ref CurrCodeType CurrCode,
                                      ref ExchRateType ExchRate,
                                      ref ListYesNoType FixedRate,
                                      ref GrnNumType GrnNum,
                                      ref DescriptionType ChartDescription,
                                      ref SiteType BuilderPoOrigSite,
                                      ref BuilderPoNumType BuilderPoNum,
                                      ref SiteType BuilderVoucherOrigSite,
                                      ref BuilderVoucherType BuilderVoucher,
                                      ref AmountType PurchAmt,
                                      ref AmountType Freight,
                                      ref AmountType Duty_amt,
                                      ref AmountType BrokerageAmt,
                                      ref AmountType InsuranceAmt,
                                      ref AmountType LocFrtAmt,
                                      ref AmountType MiscCharges,
                                      ref AmountType SalesTax,
                                      ref AmountType SalesTax2,
                                      ref AmountType InvAmt,
                                      ref AmountType NonDiscAmt,
                                      ref AmountType DiscAmt,
                                      ref InfobarType Infobar);
    }

    public class APVchAdjForCancellation : IAPVchAdjForCancellation
    {
        readonly IApplicationDB appDB;

        public APVchAdjForCancellation(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int APVchAdjForCancellationSp(VendNumType VendNum,
                                             VoucherType Voucher,
                                             ref PoNumType PoNum,
                                             ref VendInvNumType InvNum,
                                             ref DueDaysType DueDays,
                                             ref ProxDayType ProxDay,
                                             ref DateType DueDate,
                                             ref DiscDaysType DiscDays,
                                             ref DateType DiscDate,
                                             ref ApDiscType DiscPct,
                                             ref AcctType ApAcct,
                                             ref UnitCode1Type ApAcctUnit1,
                                             ref UnitCode2Type ApAcctUnit2,
                                             ref UnitCode3Type ApAcctUnit3,
                                             ref UnitCode4Type ApAcctUnit4,
                                             ref TaxCodeType TaxCode1,
                                             ref TaxCodeType TaxCode2,
                                             ref CurrCodeType CurrCode,
                                             ref ExchRateType ExchRate,
                                             ref ListYesNoType FixedRate,
                                             ref GrnNumType GrnNum,
                                             ref DescriptionType ChartDescription,
                                             ref SiteType BuilderPoOrigSite,
                                             ref BuilderPoNumType BuilderPoNum,
                                             ref SiteType BuilderVoucherOrigSite,
                                             ref BuilderVoucherType BuilderVoucher,
                                             ref AmountType PurchAmt,
                                             ref AmountType Freight,
                                             ref AmountType Duty_amt,
                                             ref AmountType BrokerageAmt,
                                             ref AmountType InsuranceAmt,
                                             ref AmountType LocFrtAmt,
                                             ref AmountType MiscCharges,
                                             ref AmountType SalesTax,
                                             ref AmountType SalesTax2,
                                             ref AmountType InvAmt,
                                             ref AmountType NonDiscAmt,
                                             ref AmountType DiscAmt,
                                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APVchAdjForCancellationSp";

                appDB.AddCommandParameter(cmd, "VendNum", VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Voucher", Voucher, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PoNum", PoNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InvNum", InvNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DueDays", DueDays, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ProxDay", ProxDay, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DueDate", DueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DiscDays", DiscDays, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DiscDate", DiscDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DiscPct", DiscPct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApAcct", ApAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApAcctUnit1", ApAcctUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApAcctUnit2", ApAcctUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApAcctUnit3", ApAcctUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApAcctUnit4", ApAcctUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1", TaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2", TaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCode", CurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ExchRate", ExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FixedRate", FixedRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "GrnNum", GrnNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ChartDescription", ChartDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BuilderPoOrigSite", BuilderPoOrigSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BuilderPoNum", BuilderPoNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BuilderVoucherOrigSite", BuilderVoucherOrigSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BuilderVoucher", BuilderVoucher, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PurchAmt", PurchAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Freight", Freight, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Duty_amt", Duty_amt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BrokerageAmt", BrokerageAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InsuranceAmt", InsuranceAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocFrtAmt", LocFrtAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "MiscCharges", MiscCharges, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SalesTax", SalesTax, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SalesTax2", SalesTax2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InvAmt", InvAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NonDiscAmt", NonDiscAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DiscAmt", DiscAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
