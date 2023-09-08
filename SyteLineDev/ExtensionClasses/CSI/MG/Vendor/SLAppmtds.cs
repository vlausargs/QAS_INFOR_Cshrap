//PROJECT NAME: VendorExt
//CLASS NAME: SLAppmtds.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using CSI.Finance.AP;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Vendor
{
    [IDOExtensionClass("SLAppmtds")]
    public class SLAppmtds : CSIExtensionClassBase
    {


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AppmtdLeaveTypeSp(string PSite,
                                      string PType,
                                      string PVendNum,
                                      string PBankCode,
                                      short? PCheckSeq,
                                      decimal? PDiscAmt,
                                      ref int? PSeq,
                                      ref string PAcct,
                                      ref string PAcctUnit1,
                                      ref string PAcctUnit2,
                                      ref string PAcctUnit3,
                                      ref string PAcctUnit4,
                                      ref string PAcctDesc,
                                      ref string Infobar,
                                      ref byte? PAcctIsControl)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAppmtdLeaveTypeExt = new AppmtdLeaveTypeFactory().Create(appDb);

                int Severity = iAppmtdLeaveTypeExt.AppmtdLeaveTypeSp(PSite,
                                                                     PType,
                                                                     PVendNum,
                                                                     PBankCode,
                                                                     PCheckSeq,
                                                                     PDiscAmt,
                                                                     ref PSeq,
                                                                     ref PAcct,
                                                                     ref PAcctUnit1,
                                                                     ref PAcctUnit2,
                                                                     ref PAcctUnit3,
                                                                     ref PAcctUnit4,
                                                                     ref PAcctDesc,
                                                                     ref Infobar,
                                                                     ref PAcctIsControl);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
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
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAppmtdValidAppmtExt = new AppmtdValidAppmtFactory().Create(appDb);

                int Severity = iAppmtdValidAppmtExt.AppmtdValidAppmtSp(VendNum,
                                                                       Level,
                                                                       ref PayType,
                                                                       ref CheckNum,
                                                                       ref CheckSeq,
                                                                       ref CheckDate,
                                                                       ref BankCode,
                                                                       ref DueDate,
                                                                       ref VendName,
                                                                       ref CurrCode,
                                                                       ref ExchRate,
                                                                       ref ForCheckAmt,
                                                                       ref DomCheckAmt,
                                                                       ref ForApplied,
                                                                       ref DomApplied,
                                                                       ref ForRemaining,
                                                                       ref DomRemaining,
                                                                       ref CurrAmtFormat,
                                                                       ref PayHold,
                                                                       ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
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
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAppmtdValidateInvoiceExt = new AppmtdValidateInvoiceFactory().Create(appDb);

                int Severity = iAppmtdValidateInvoiceExt.AppmtdValidateInvoiceSp(PType,
                                                                                 PSite,
                                                                                 PBankCode,
                                                                                 PVendNum,
                                                                                 PCheckSeq,
                                                                                 PApplyVendNum,
                                                                                 PInvNum,
                                                                                 PGetDeflt,
                                                                                 PValInvNum,
                                                                                 ref PNewAmtDisc,
                                                                                 ref PNewAmtPaid,
                                                                                 ref PDomTcAmtPaid,
                                                                                 ref PDomTcAmtDisc,
                                                                                 ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AppmtdValidateSiteSp(string PSite,
                                        string PType,
                                        string PVendNum,
                                        string PBankCode,
                                        short? PCheckSeq,
                                        decimal? PDiscAmt,
                                        string PCurrCode,
                                        ref string PAcct,
                                        ref string PAcctUnit1,
                                        ref string PAcctUnit2,
                                        ref string PAcctUnit3,
                                        ref string PAcctUnit4,
                                        ref string PAcctDesc,
                                        ref string Infobar,
                                        ref byte? PAcctIsControl)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAppmtdValidateSiteExt = new AppmtdValidateSiteFactory().Create(appDb);

                int Severity = iAppmtdValidateSiteExt.AppmtdValidateSiteSp(PSite,
                                                                           PType,
                                                                           PVendNum,
                                                                           PBankCode,
                                                                           PCheckSeq,
                                                                           PDiscAmt,
                                                                           PCurrCode,
                                                                           ref PAcct,
                                                                           ref PAcctUnit1,
                                                                           ref PAcctUnit2,
                                                                           ref PAcctUnit3,
                                                                           ref PAcctUnit4,
                                                                           ref PAcctDesc,
                                                                           ref Infobar,
                                                                           ref PAcctIsControl);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AppmtdValidateVoucherSp(string PType,
                                           int? PVoucher,
                                           string PSite,
                                           string PBankCode,
                                           string PVendNum,
                                           short? PCheckSeq,
                                           ref string PApplyVend,
                                           ref string PName,
                                           ref DateTime? PDueDate,
                                           ref string PGrnNum,
                                           ref decimal? ForAmtDisc,
                                           ref decimal? ForAmtPaid,
                                           ref decimal? DomAmtDisc,
                                           ref decimal? DomAmtPaid,
                                           ref decimal? ExchRate,
                                           ref string AptrxpCurrCode,
                                           ref string PromptMsg,
                                           ref string PromptButtons,
                                           ref string Infobar)
        {
            var iAppmtdValidateVoucherExt = new AppmtdValidateVoucherFactory().Create(this, true);
            var result = iAppmtdValidateVoucherExt.AppmtdValidateVoucherSp(PType,
                PVoucher,
                PSite,
                PBankCode,
                PVendNum,
                PCheckSeq,
                PApplyVend,
                PName,
                PDueDate,
                PGrnNum,
                ForAmtDisc,
                ForAmtPaid,
                DomAmtDisc,
                DomAmtPaid,
                ExchRate,
                AptrxpCurrCode,
                PromptMsg,
                PromptButtons,
                Infobar);

            PApplyVend = result.PApplyVend;
            PName = result.PName;
            PDueDate = result.PDueDate;
            PGrnNum = result.PGrnNum;
            ForAmtDisc = result.ForAmtDisc;
            ForAmtPaid = result.ForAmtPaid;
            DomAmtDisc = result.DomAmtDisc;
            DomAmtPaid = result.DomAmtPaid;
            ExchRate = result.ExchRate;
            AptrxpCurrCode = result.AptrxpCurrCode;
            PromptMsg = result.PromptMsg;
            PromptButtons = result.PromptButtons;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }


        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable AppmtgDoProcessSp(string ExOptszSiteGroup,
                                           DateTime? ExOptprPaymentDate,
                                           string ExOptprPaymentType,
                                           string ExOptgoInvDueDisc,
                                           string ExOptdfDiscMethod,
                                           byte? ExOptgoInclCommissions,
                                           byte? ExOptdfDelPaydis,
                                           string ExBegVendNum,
                                           string ExEndVendNum,
                                           string ExBegBankCode,
                                           string ExEndBankCode,
                                           DateTime? ExBegAgeDate,
                                           DateTime? ExEndAgeDate,
                                           byte? ExOverPaymentBankCode,
                                           string ExPaymentBankCode,
                                           string THPaymentNumberPrefix)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iAppmtgDoProcessExt = new AppmtgDoProcessFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iAppmtgDoProcessExt.AppmtgDoProcessSp(ExOptszSiteGroup,
                                                                     ExOptprPaymentDate,
                                                                     ExOptprPaymentType,
                                                                     ExOptgoInvDueDisc,
                                                                     ExOptdfDiscMethod,
                                                                     ExOptgoInclCommissions,
                                                                     ExOptdfDelPaydis,
                                                                     ExBegVendNum,
                                                                     ExEndVendNum,
                                                                     ExBegBankCode,
                                                                     ExEndBankCode,
                                                                     ExBegAgeDate,
                                                                     ExEndAgeDate,
                                                                     ExOverPaymentBankCode,
                                                                     ExPaymentBankCode,
                                                                     THPaymentNumberPrefix);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AppmtgSp(ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAppmtgExt = new AppmtgFactory().Create(appDb);

                int Severity = iAppmtgExt.AppmtgSp(ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CreateWhtSp(string VendNum,
                               ref string WHTType,
                               ref string TaxID,
                               ref string CompanyName,
                               ref string Address1,
                               ref string Address2,
                               ref string Address3,
                               ref string Address4,
                               ref string PostZip)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCreateWhtExt = new CreateWhtFactory().Create(appDb);

                int Severity = iCreateWhtExt.CreateWhtSp(VendNum,
                                                         ref WHTType,
                                                         ref TaxID,
                                                         ref CompanyName,
                                                         ref Address1,
                                                         ref Address2,
                                                         ref Address3,
                                                         ref Address4,
                                                         ref PostZip);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetAppmtgDoProcessMessageSp(ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetAppmtgDoProcessMessageExt = new GetAppmtgDoProcessMessageFactory().Create(appDb);

                int Severity = iGetAppmtgDoProcessMessageExt.GetAppmtgDoProcessMessageSp(ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetAppmtsDefaultsForVendorSp(string PVendNum,
                                                ref string PVendName,
                                                ref string PPayType,
                                                ref int? PCheckNum,
                                                ref short? PCheckSeq,
                                                ref DateTime? PCheckDate,
                                                ref DateTime? PDueDate,
                                                ref string PCurrCode,
                                                ref decimal? PExchRate,
                                                ref decimal? PForCheckAmt,
                                                ref decimal? PDomCheckAmt,
                                                ref decimal? PForApplied,
                                                ref decimal? PDomApplied,
                                                ref decimal? PForRemaining,
                                                ref decimal? PDomRemaining,
                                                ref string PBankCode,
                                                ref byte? PPayHold,
                                                ref string PTaxRegNum1,
                                                ref string PBanCurrCode,
                                                ref string PInfobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetAppmtsDefaultsForVendorExt = new GetAppmtsDefaultsForVendorFactory().Create(appDb);

                int Severity = iGetAppmtsDefaultsForVendorExt.GetAppmtsDefaultsForVendorSp(PVendNum,
                                                                                           ref PVendName,
                                                                                           ref PPayType,
                                                                                           ref PCheckNum,
                                                                                           ref PCheckSeq,
                                                                                           ref PCheckDate,
                                                                                           ref PDueDate,
                                                                                           ref PCurrCode,
                                                                                           ref PExchRate,
                                                                                           ref PForCheckAmt,
                                                                                           ref PDomCheckAmt,
                                                                                           ref PForApplied,
                                                                                           ref PDomApplied,
                                                                                           ref PForRemaining,
                                                                                           ref PDomRemaining,
                                                                                           ref PBankCode,
                                                                                           ref PPayHold,
                                                                                           ref PTaxRegNum1,
                                                                                           ref PBanCurrCode,
                                                                                           ref PInfobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetAPTaxInfoSp(ref byte? EnableTax1,
                                  ref byte? EnableTax2)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetAPTaxInfoExt = new GetAPTaxInfoFactory().Create(appDb);

                int Severity = iGetAPTaxInfoExt.GetAPTaxInfoSp(ref EnableTax1,
                                                               ref EnableTax2);

                return Severity;
            }
        }










        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TH_THGenerateNewVendInvSeqSp([Optional, DefaultParameterValue(null)] string VendorNum,
                                                                                 [Optional] int? voucher,
                                                                                 [Optional] DateTime? InvDate,
                                                                                 ref string Newvendinv,
                                                                                 ref string Newwhtseq,
                                                                                 [Optional] Guid? ThapptcdRp)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTHGenerateNewVendInvSeqExt = new THGenerateNewVendInvSeqFactory().Create(appDb);

                var result = iTHGenerateNewVendInvSeqExt.THGenerateNewVendInvSeqSp(VendorNum,
                                                                                   voucher,
                                                                                   InvDate,
                                                                                   Newvendinv,
                                                                                   Newwhtseq,
                                                                                   ThapptcdRp);

                int Severity = result.ReturnCode.Value;
                Newvendinv = result.Newvendinv;
                Newwhtseq = result.Newwhtseq;
                return Severity;
            }
        }



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetDefaultAPTaxAdjustSp(int? Voucher,
        decimal? DisAmt,
        ref decimal? DfltTax1Val,
        ref decimal? DfltTax2Val)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetDefaultAPTaxAdjustExt = new GetDefaultAPTaxAdjustFactory().Create(appDb);

                var result = iGetDefaultAPTaxAdjustExt.GetDefaultAPTaxAdjustSp(Voucher,
                DisAmt,
                DfltTax1Val,
                DfltTax2Val);

                int Severity = result.ReturnCode.Value;
                DfltTax1Val = result.DfltTax1Val;
                DfltTax2Val = result.DfltTax2Val;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int THAGetPurcAcctSp(ref string Acct,
        ref string Unit1,
        ref string Unit2,
        ref string Unit3,
        ref string Unit4,
        ref string Desc,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTHAGetPurcAcctExt = new THAGetPurcAcctFactory().Create(appDb);

                var result = iTHAGetPurcAcctExt.THAGetPurcAcctSp(Acct,
                Unit1,
                Unit2,
                Unit3,
                Unit4,
                Desc,
                Infobar);

                int Severity = result.ReturnCode.Value;
                Acct = result.Acct;
                Unit1 = result.Unit1;
                Unit2 = result.Unit2;
                Unit3 = result.Unit3;
                Unit4 = result.Unit4;
                Desc = result.Desc;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int THAGetTaxAcctsSp(string TaxCode,
        string pSite,
        string pType,
        string pVendNum,
        decimal? pDiscAmt,
        ref string rChartAcct,
        ref string rAccessUnit1,
        ref string rAccessUnit2,
        ref string rAccessUnit3,
        ref string rAccessUnit4,
        ref string rDescription,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTHAGetTaxAcctsExt = new THAGetTaxAcctsFactory().Create(appDb);

                var result = iTHAGetTaxAcctsExt.THAGetTaxAcctsSp(TaxCode,
                pSite,
                pType,
                pVendNum,
                pDiscAmt,
                rChartAcct,
                rAccessUnit1,
                rAccessUnit2,
                rAccessUnit3,
                rAccessUnit4,
                rDescription,
                Infobar);

                int Severity = result.ReturnCode.Value;
                rChartAcct = result.rChartAcct;
                rAccessUnit1 = result.rAccessUnit1;
                rAccessUnit2 = result.rAccessUnit2;
                rAccessUnit3 = result.rAccessUnit3;
                rAccessUnit4 = result.rAccessUnit4;
                rDescription = result.rDescription;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int THAGetTaxDataSp(string TaxCode,
        decimal? ForAmtPaid,
        string CurrCode,
        ref decimal? TaxAmount,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTHAGetTaxDataExt = new THAGetTaxDataFactory().Create(appDb);

                var result = iTHAGetTaxDataExt.THAGetTaxDataSp(TaxCode,
                ForAmtPaid,
                CurrCode,
                TaxAmount,
                Infobar);

                int Severity = result.ReturnCode.Value;
                TaxAmount = result.TaxAmount;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int THAValidateTaxCodeSp(string TaxCode,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTHAValidateTaxCodeExt = new THAValidateTaxCodeFactory().Create(appDb);

                var result = iTHAValidateTaxCodeExt.THAValidateTaxCodeSp(TaxCode,
                Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateAppmtdTypeSp(string Type,
        string PayType,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateAppmtdTypeExt = new ValidateAppmtdTypeFactory().Create(appDb);

                var result = iValidateAppmtdTypeExt.ValidateAppmtdTypeSp(Type,
                PayType,
                Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateAPTaxAdjustSp(int? Voucher,
        decimal? DisAmt,
        int? TaxNum,
        decimal? Tax1,
        decimal? Tax2,
        ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateAPTaxAdjustExt = new ValidateAPTaxAdjustFactory().Create(appDb);

                var result = iValidateAPTaxAdjustExt.ValidateAPTaxAdjustSp(Voucher,
                DisAmt,
                TaxNum,
                Tax1,
                Tax2,
                InfoBar);

                int Severity = result.ReturnCode.Value;
                InfoBar = result.InfoBar;
                return Severity;
            }
        }






        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetChartInfoSp(string pChartAcct,
        ref string rChartType,
        ref string rAccessUnit1,
        ref string rAccessUnit2,
        ref string rAccessUnit3,
        ref string rAccessUnit4,
        ref string rDescription,
        ref string Infobar,
        [Optional] string Site,
        ref int? rIsControl)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iGetChartInfoExt = new GetChartInfoFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iGetChartInfoExt.GetChartInfoSp(pChartAcct,
                rChartType,
                rAccessUnit1,
                rAccessUnit2,
                rAccessUnit3,
                rAccessUnit4,
                rDescription,
                Infobar,
                Site,
                rIsControl);

                int Severity = result.ReturnCode.Value;
                rChartType = result.rChartType;
                rAccessUnit1 = result.rAccessUnit1;
                rAccessUnit2 = result.rAccessUnit2;
                rAccessUnit3 = result.rAccessUnit3;
                rAccessUnit4 = result.rAccessUnit4;
                rDescription = result.rDescription;
                Infobar = result.Infobar;
                rIsControl = result.rIsControl;
                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EFTImportAppmtdSp(string VendNum,
        string InvNum,
        int? Voucher,
        string Site,
        string BankCode,
        decimal? DetailAmount,
        DateTime? EffectiveDate,
        int? CheckSeq,
        ref Guid? RefRowPointer,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iEFTImportAppmtdExt = new EFTImportAppmtdFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iEFTImportAppmtdExt.EFTImportAppmtdSp(VendNum,
                InvNum,
                Voucher,
                Site,
                BankCode,
                DetailAmount,
                EffectiveDate,
                CheckSeq,
                RefRowPointer,
                Infobar);

                int Severity = result.ReturnCode.Value;
                RefRowPointer = result.RefRowPointer;
                Infobar = result.Infobar;
                return Severity;
            }
        }
    }
}
