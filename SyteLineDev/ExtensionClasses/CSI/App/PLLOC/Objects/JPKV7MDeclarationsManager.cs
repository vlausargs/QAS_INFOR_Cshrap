using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Functions;
using CSI.MG;
using PLLOC.Objects;
using PLLOC.Interfaces;
using System.Xml;
using System.IO;
using System.Globalization;
using CSI.Data.CRUD;
using CSI.Admin;
using CSI.Data;

namespace PLLOC.Objects
{
    public class JPKV7MDeclarationsManager : IJPKV7MDeclarationsManager
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IRptVATManager rptVATManager;
        readonly IRptVATValuesFromSp rptVATValuesFromSp;
        readonly IJPKV7MDeclarationsFactory jPKV7MDeclarationsFactory;
        readonly IIsAddonAvailable IsAddonAvailable;
        readonly IIsFeatureActive IsFeatureActive;
        readonly IMathUtil mathUtil;

        private int FeatureActiveRS9249 => this.IsFeatureRS9249Active();

        public JPKV7MDeclarationsManager(
        IApplicationDB appDB,
        IRptVATManager rptVATManager,
        IBunchedLoadCollection bunchedLoadCollection,
        ICollectionLoadRequestFactory collectionLoadRequestFactory,
        IJPKV7MDeclarationsFactory jPKV7MDeclarationsFactory,
        IRptVATValuesFromSp rptVATValuesFromSp,
        IIsAddonAvailable IsAddonAvailable,
        IIsFeatureActive IsFeatureActive,
        IMathUtil mathUtil)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.rptVATManager = rptVATManager;
            this.jPKV7MDeclarationsFactory = jPKV7MDeclarationsFactory;
            this.rptVATValuesFromSp = rptVATValuesFromSp;
            this.IsAddonAvailable = IsAddonAvailable;
            this.IsFeatureActive = IsFeatureActive;
            this.mathUtil = mathUtil;
        }

        public IJPKV7MDeclarations Process(DateTime BeginTaxDate, DateTime EndTaxDate, byte? TaxJurTaxSystem, byte? ExOptszShowDetail, string TaxJurTaxJur, short? TaxDateStartingOffset, short? TaxDateEndingOffset, string ExOptgoJournalId, byte? DisplayHeader, string BGSessionId, int? TaskId, string pSite, string BGUser, string SortBy, byte? ExcludeNullLineNum, byte? ExcludeJournalEntries, string PLVATFormVariant, string Confirmation, decimal P39, decimal P49, decimal P50, decimal P52, decimal P54, byte P540, byte P55, byte P56, byte P560, byte P57, byte P58, byte P59, decimal P60, string P61, byte P63, byte P64, byte P65, byte P66, byte P660, byte P67, decimal P68, decimal P69, string PORDZU)
        {
            if (!rptVATManager.IsPopulatedJPK7MSalesRegister || !rptVATManager.IsPopulatedJPKV7MPurchaseRegister)
            {
                var dtRpt_VATSp = rptVATValuesFromSp.GetRpt_VATSp(TaxJurTaxSystem, ExOptszShowDetail, TaxJurTaxJur, BeginTaxDate, EndTaxDate,
                TaxDateStartingOffset, TaxDateEndingOffset, ExOptgoJournalId, DisplayHeader, BGSessionId, TaskId, pSite, BGUser, SortBy, ExcludeNullLineNum, ExcludeJournalEntries);
                var dtCLM_VatProceduralMarkingsSp = rptVATValuesFromSp.GetCLM_VatProceduralMarkingsSp(BeginTaxDate, EndTaxDate);

                var setResultToRPTVATManager = rptVATValuesFromSp.SetResultToRPTVATManager(dtRpt_VATSp, dtCLM_VatProceduralMarkingsSp);
            }

            IList<IJPK7MSalesRegister> salesRegisters = this.rptVATManager.GetJPK7MSalesRegister();
            IList<IJPKV7MPurchaseRegister> purchaseRegisters = this.rptVATManager.GetJPKV7MPurchaseRegister();

            var jPKV7MDeclarations = SaveManualEntryValues(Confirmation, P39, P49, P50, P52, P54, P540, P55, P56, P560, P57, P58, P59, P60, P61, P63,
                P64, P65, P66, P660, P67, P68, P69, PORDZU);

            if (rptVATManager.IsPopulatedJPK7MSalesRegister)
            {
                //P10-P38
                jPKV7MDeclarations = ComputePSumValuesForSalesRegister(salesRegisters, jPKV7MDeclarations);
            }

            if (rptVATManager.IsPopulatedJPKV7MPurchaseRegister)
            {
                //P40-P48
                jPKV7MDeclarations = ComputePSumValuesForPurchaseRegister(purchaseRegisters, jPKV7MDeclarations);
            }

            string formVariant = PLVATFormVariant ?? "";
            //P51, P53, P62
            jPKV7MDeclarations = ComputePConditionalValues(jPKV7MDeclarations, formVariant);

            jPKV7MDeclarations = RoundPValues(jPKV7MDeclarations);

            return jPKV7MDeclarations;
        }

        public IJPKV7MDeclarations Process(string Confirmation, decimal P39, decimal P49, decimal P50, decimal P52, decimal P54, byte P540, byte P55, byte P56, byte P560, byte P57, byte P58, byte P59, decimal P60, string P61, byte P63, byte P64, byte P65, byte P66, byte P660, byte P67, decimal P68, decimal P69, string PORDZU, string declarationCommitmentType, string declarationFormCode, string declarationSchemaVersion, string declarationSystemCode, string declarationTaxCode, string variantDeclarationForm, string pLVATFormVariant)
        {
            IList<IJPK7MSalesRegister> salesRegisters = this.rptVATManager.GetJPK7MSalesRegister();
            IList<IJPKV7MPurchaseRegister> purchaseRegisters = this.rptVATManager.GetJPKV7MPurchaseRegister();


            var jPKV7MDeclarations = SaveManualEntryValues(Confirmation, P39, P49, P50, P52, P54, P540, P55, P56, P560, P57, P58, P59, P60, P61, P63,
                P64, P65, P66, P660, P67, P68, P69, PORDZU,
                declarationCommitmentType, declarationFormCode, declarationSchemaVersion, declarationSystemCode, declarationTaxCode, variantDeclarationForm);


            if (rptVATManager.IsPopulatedJPK7MSalesRegister)
            {
                //P10-P38
                jPKV7MDeclarations = ComputePSumValuesForSalesRegister(salesRegisters, jPKV7MDeclarations);
            }

            if (rptVATManager.IsPopulatedJPKV7MPurchaseRegister)
            {
                //P40-P48
                jPKV7MDeclarations = ComputePSumValuesForPurchaseRegister(purchaseRegisters, jPKV7MDeclarations);
            }

            string formVariant = pLVATFormVariant ?? "";

            //P51, P53, P62
            jPKV7MDeclarations = ComputePConditionalValues(jPKV7MDeclarations, formVariant);

            jPKV7MDeclarations = RoundPValues(jPKV7MDeclarations);

            return jPKV7MDeclarations;
        }

        private IJPKV7MDeclarations SaveManualEntryValues(string Confirmation, decimal P39, decimal P49, decimal P50, decimal P52, decimal P54,
                      byte P540, byte? P55, byte? P56, byte P560, byte? P57, byte? P58, byte? P59, decimal P60, string P61, byte? P63,
                      byte? P64, byte? P65, byte? P66, byte? P660, byte? P67, decimal P68, decimal P69, string PORDZU,
                      string declarationCommitmentType="", string declarationFormCode = "", string declarationSchemaVersion = "", string declarationSystemCode = "", string declarationTaxCode = "", string variantDeclarationForm = "")
        {
            var jPKV7MDeclarations = jPKV7MDeclarationsFactory.Create(declarationCommitmentType, declarationFormCode, declarationSchemaVersion, declarationSystemCode, declarationTaxCode, variantDeclarationForm,confirmation: Confirmation, p39: P39, p49: P49, p50: P50, p52: P52, p54: P54, p540: P540, p55: P55, p56: P56, p560: P560, p57: P57, p58: P58, p59: P59, p60: P60, p61: P61, p63: P63, p64: P64, p65: P65, p66: P66, p660: P660, p67: P67, p68: P68, p69: P69, pORDZU: PORDZU);

            return jPKV7MDeclarations;
        }
        private IJPKV7MDeclarations ComputePSumValuesForSalesRegister(IList<IJPK7MSalesRegister> registers, IJPKV7MDeclarations jPKV7MDeclarations)
        {
            decimal P10 = 0;
            decimal P11 = 0;
            decimal P12 = 0;
            decimal P13 = 0;
            decimal P14 = 0;
            decimal P15 = 0;
            decimal P16 = 0;
            decimal P17 = 0;
            decimal P18 = 0;
            decimal P19 = 0;
            decimal P20 = 0;
            decimal P21 = 0;
            decimal P22 = 0;
            decimal P23 = 0;
            decimal P24 = 0;
            decimal P25 = 0;
            decimal P26 = 0;
            decimal P27 = 0;
            decimal P28 = 0;
            decimal P29 = 0;
            decimal P30 = 0;
            decimal P31 = 0;
            decimal P32 = 0;
            decimal P33 = 0;
            decimal P34 = 0;
            decimal P35 = 0;
            decimal P36 = 0;
            decimal P37 = 0;
            decimal P38 = 0;

            foreach (var register in registers)
            {
                P10 = P10 + register.K10;
                P11 = P11 + register.K11;
                P12 = P12 + register.K12;
                P13 = P13 + register.K13;
                P14 = P14 + register.K14;
                P15 = P15 + register.K15;
                P16 = P16 + register.K16;
                P17 = P17 + register.K17;
                P18 = P18 + register.K18;
                P19 = P19 + register.K19;
                P20 = P20 + register.K20;
                P21 = P21 + register.K21;
                P22 = P22 + register.K22;
                P23 = P23 + register.K23;
                P24 = P24 + register.K24;
                P25 = P25 + register.K25;
                P26 = P26 + register.K26;
                P27 = P27 + register.K27;
                P28 = P28 + register.K28;
                P29 = P29 + register.K29;
                P30 = P30 + register.K30;
                P31 = P31 + register.K31;
                P32 = P32 + register.K32;
                P33 = P33 + register.K33;
                P34 = P34 + register.K34;
                P35 = P35 + register.K35;
                P36 = P36 + register.K36;
            }
            var jPKV7MDeclarationsSalesRegisters = jPKV7MDeclarationsFactory.Create(jPKV7MDeclarations.DeclarationCommitmentType, jPKV7MDeclarations.DeclarationFormCode, jPKV7MDeclarations.DeclarationSchemaVersion, jPKV7MDeclarations.DeclarationSystemCode, jPKV7MDeclarations.DeclarationTaxCode, jPKV7MDeclarations.VariantDeclarationForm, jPKV7MDeclarations.Confirmation, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, jPKV7MDeclarations.P39, jPKV7MDeclarations.P40, jPKV7MDeclarations.P41, jPKV7MDeclarations.P42, jPKV7MDeclarations.P43, jPKV7MDeclarations.P44, jPKV7MDeclarations.P45, jPKV7MDeclarations.P46, jPKV7MDeclarations.P47, jPKV7MDeclarations.P48, jPKV7MDeclarations.P49, jPKV7MDeclarations.P50, jPKV7MDeclarations.P51, jPKV7MDeclarations.P52, jPKV7MDeclarations.P53, jPKV7MDeclarations.P54, jPKV7MDeclarations.P540, jPKV7MDeclarations.P55, jPKV7MDeclarations.P56, jPKV7MDeclarations.P560, jPKV7MDeclarations.P57, jPKV7MDeclarations.P58, jPKV7MDeclarations.P59, jPKV7MDeclarations.P60, jPKV7MDeclarations.P61, jPKV7MDeclarations.P62, jPKV7MDeclarations.P63, jPKV7MDeclarations.P64, jPKV7MDeclarations.P65, jPKV7MDeclarations.P66, jPKV7MDeclarations.P660, jPKV7MDeclarations.P67, jPKV7MDeclarations.P68, jPKV7MDeclarations.P69, jPKV7MDeclarations.PORDZU);
            IJPKV7MDeclarations jPKV7MDeclarationsForCalc = RoundPValues(jPKV7MDeclarationsSalesRegisters);
            //Total amount of tax base. Sum of amounts from P_10, P_11, P_13, P_15, P_17, P_19, P_21, P_22, P_23, P_25, P_27, P_29, P_31
            P37 = jPKV7MDeclarationsForCalc.P10 + jPKV7MDeclarationsForCalc.P11 + jPKV7MDeclarationsForCalc.P13 + jPKV7MDeclarationsForCalc.P15 + jPKV7MDeclarationsForCalc.P17 + jPKV7MDeclarationsForCalc.P19 + jPKV7MDeclarationsForCalc.P21 + jPKV7MDeclarationsForCalc.P22 + jPKV7MDeclarationsForCalc.P23 + jPKV7MDeclarationsForCalc.P25 + jPKV7MDeclarationsForCalc.P27 + jPKV7MDeclarationsForCalc.P29 + jPKV7MDeclarationsForCalc.P31;

            //Total amount of tax due. Sum of amounts from P_16, P_18, P_20, P_24, P_26, P_28, P_30, P_32, P_33, P_34 reduced by the amount from P_35 and P_36
            P38 = (jPKV7MDeclarationsForCalc.P16 + jPKV7MDeclarationsForCalc.P18 + jPKV7MDeclarationsForCalc.P20 + jPKV7MDeclarationsForCalc.P24 + jPKV7MDeclarationsForCalc.P26 + jPKV7MDeclarationsForCalc.P28 + jPKV7MDeclarationsForCalc.P30 + jPKV7MDeclarationsForCalc.P32 + jPKV7MDeclarationsForCalc.P33 + jPKV7MDeclarationsForCalc.P34) - (jPKV7MDeclarationsForCalc.P35 + jPKV7MDeclarationsForCalc.P36);
            //string declarationCommitmentType = "", string declarationFormCode = "", string declarationSchemaVersion = "", string declarationSystemCode = "", string declarationTaxCode = "", string variantDeclarationForm = "",
            jPKV7MDeclarationsSalesRegisters = jPKV7MDeclarationsFactory.Create(jPKV7MDeclarations.DeclarationCommitmentType, jPKV7MDeclarations.DeclarationFormCode, jPKV7MDeclarations.DeclarationSchemaVersion, jPKV7MDeclarations.DeclarationSystemCode, jPKV7MDeclarations.DeclarationTaxCode, jPKV7MDeclarations.VariantDeclarationForm,jPKV7MDeclarations.Confirmation, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, jPKV7MDeclarations.P39, jPKV7MDeclarations.P40, jPKV7MDeclarations.P41, jPKV7MDeclarations.P42, jPKV7MDeclarations.P43, jPKV7MDeclarations.P44, jPKV7MDeclarations.P45, jPKV7MDeclarations.P46, jPKV7MDeclarations.P47, jPKV7MDeclarations.P48, jPKV7MDeclarations.P49, jPKV7MDeclarations.P50, jPKV7MDeclarations.P51, jPKV7MDeclarations.P52, jPKV7MDeclarations.P53, jPKV7MDeclarations.P54, jPKV7MDeclarations.P540, jPKV7MDeclarations.P55, jPKV7MDeclarations.P56, jPKV7MDeclarations.P560, jPKV7MDeclarations.P57, jPKV7MDeclarations.P58, jPKV7MDeclarations.P59, jPKV7MDeclarations.P60, jPKV7MDeclarations.P61, jPKV7MDeclarations.P62, jPKV7MDeclarations.P63, jPKV7MDeclarations.P64, jPKV7MDeclarations.P65, jPKV7MDeclarations.P66, jPKV7MDeclarations.P660, jPKV7MDeclarations.P67, jPKV7MDeclarations.P68, jPKV7MDeclarations.P69, jPKV7MDeclarations.PORDZU);

            return jPKV7MDeclarationsSalesRegisters;
        }

        private IJPKV7MDeclarations ComputePSumValuesForPurchaseRegister(IList<IJPKV7MPurchaseRegister> registers, IJPKV7MDeclarations jPKV7MDeclarations)
        {
            decimal P40 = 0;
            decimal P41 = 0;
            decimal P42 = 0;
            decimal P43 = 0;
            decimal P44 = 0;
            decimal P45 = 0;
            decimal P46 = 0;
            decimal P47 = 0;
            decimal P48 = 0;

            foreach (var register in registers)
            {
                P40 = P40 + register.K40;
                P41 = P41 + register.K41;
                P42 = P42 + register.K42;
                P43 = P43 + register.K43;
                P44 = P44 + register.K44;
                P45 = P45 + register.K45;
                P46 = P46 + register.K46;
                P47 = P47 + register.K47;
            }

            var jPKV7MDeclarationsPurchaseRegister = jPKV7MDeclarationsFactory.Create(jPKV7MDeclarations.DeclarationCommitmentType, jPKV7MDeclarations.DeclarationFormCode, jPKV7MDeclarations.DeclarationSchemaVersion, jPKV7MDeclarations.DeclarationSystemCode, jPKV7MDeclarations.DeclarationTaxCode, jPKV7MDeclarations.VariantDeclarationForm, jPKV7MDeclarations.Confirmation, jPKV7MDeclarations.P10, jPKV7MDeclarations.P11, jPKV7MDeclarations.P12, jPKV7MDeclarations.P13, jPKV7MDeclarations.P14, jPKV7MDeclarations.P15, jPKV7MDeclarations.P16, jPKV7MDeclarations.P17, jPKV7MDeclarations.P18, jPKV7MDeclarations.P19, jPKV7MDeclarations.P20, jPKV7MDeclarations.P21, jPKV7MDeclarations.P22, jPKV7MDeclarations.P23, jPKV7MDeclarations.P24, jPKV7MDeclarations.P25, jPKV7MDeclarations.P26, jPKV7MDeclarations.P27, jPKV7MDeclarations.P28, jPKV7MDeclarations.P29, jPKV7MDeclarations.P30, jPKV7MDeclarations.P31, jPKV7MDeclarations.P32, jPKV7MDeclarations.P33, jPKV7MDeclarations.P34, jPKV7MDeclarations.P35, jPKV7MDeclarations.P36, jPKV7MDeclarations.P37, jPKV7MDeclarations.P38, jPKV7MDeclarations.P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, jPKV7MDeclarations.P49, jPKV7MDeclarations.P50, jPKV7MDeclarations.P51, jPKV7MDeclarations.P52, jPKV7MDeclarations.P53, jPKV7MDeclarations.P54, jPKV7MDeclarations.P540, jPKV7MDeclarations.P55, jPKV7MDeclarations.P56, jPKV7MDeclarations.P560, jPKV7MDeclarations.P57, jPKV7MDeclarations.P58, jPKV7MDeclarations.P59, jPKV7MDeclarations.P60, jPKV7MDeclarations.P61, jPKV7MDeclarations.P62, jPKV7MDeclarations.P63, jPKV7MDeclarations.P64, jPKV7MDeclarations.P65, jPKV7MDeclarations.P66, jPKV7MDeclarations.P660, jPKV7MDeclarations.P67, jPKV7MDeclarations.P68, jPKV7MDeclarations.P69, jPKV7MDeclarations.PORDZU);
            IJPKV7MDeclarations jPKV7MDeclarationsForCalc = RoundPValues(jPKV7MDeclarationsPurchaseRegister);
            //Total amount of input tax to be deducted. Sum of amounts from P_39, P_41, P_43, P_44, P_45, P_46 and P_47
            P48 = jPKV7MDeclarations.P39 + jPKV7MDeclarationsForCalc.P41 + jPKV7MDeclarationsForCalc.P43 + jPKV7MDeclarationsForCalc.P44 + jPKV7MDeclarationsForCalc.P45 + jPKV7MDeclarationsForCalc.P46 + jPKV7MDeclarationsForCalc.P47;

            jPKV7MDeclarationsPurchaseRegister = jPKV7MDeclarationsFactory.Create(jPKV7MDeclarations.DeclarationCommitmentType, jPKV7MDeclarations.DeclarationFormCode, jPKV7MDeclarations.DeclarationSchemaVersion, jPKV7MDeclarations.DeclarationSystemCode, jPKV7MDeclarations.DeclarationTaxCode, jPKV7MDeclarations.VariantDeclarationForm, jPKV7MDeclarations.Confirmation, jPKV7MDeclarations.P10, jPKV7MDeclarations.P11, jPKV7MDeclarations.P12, jPKV7MDeclarations.P13, jPKV7MDeclarations.P14, jPKV7MDeclarations.P15, jPKV7MDeclarations.P16, jPKV7MDeclarations.P17, jPKV7MDeclarations.P18, jPKV7MDeclarations.P19, jPKV7MDeclarations.P20, jPKV7MDeclarations.P21, jPKV7MDeclarations.P22, jPKV7MDeclarations.P23, jPKV7MDeclarations.P24, jPKV7MDeclarations.P25, jPKV7MDeclarations.P26, jPKV7MDeclarations.P27, jPKV7MDeclarations.P28, jPKV7MDeclarations.P29, jPKV7MDeclarations.P30, jPKV7MDeclarations.P31, jPKV7MDeclarations.P32, jPKV7MDeclarations.P33, jPKV7MDeclarations.P34, jPKV7MDeclarations.P35, jPKV7MDeclarations.P36, jPKV7MDeclarations.P37, jPKV7MDeclarations.P38, jPKV7MDeclarations.P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, jPKV7MDeclarations.P49, jPKV7MDeclarations.P50, jPKV7MDeclarations.P51, jPKV7MDeclarations.P52, jPKV7MDeclarations.P53, jPKV7MDeclarations.P54, jPKV7MDeclarations.P540, jPKV7MDeclarations.P55, jPKV7MDeclarations.P56, jPKV7MDeclarations.P560, jPKV7MDeclarations.P57, jPKV7MDeclarations.P58, jPKV7MDeclarations.P59, jPKV7MDeclarations.P60, jPKV7MDeclarations.P61, jPKV7MDeclarations.P62, jPKV7MDeclarations.P63, jPKV7MDeclarations.P64, jPKV7MDeclarations.P65, jPKV7MDeclarations.P66, jPKV7MDeclarations.P660, jPKV7MDeclarations.P67, jPKV7MDeclarations.P68, jPKV7MDeclarations.P69, jPKV7MDeclarations.PORDZU);

            return jPKV7MDeclarationsPurchaseRegister;
        }

        private IJPKV7MDeclarations ComputePConditionalValues(IJPKV7MDeclarations jPKV7MDeclarations, string pLVATFormVariant)
        {

            decimal P51 = 0;
            decimal P53 = 0;
            decimal P62 = 0;

            //The amount of tax to be paid to the tax office, If the difference between P_38 and P_48 is greater than 0, then P_51 = P_38 - P_48 - P_49 - P_50, otherwise 0 should be shown.
            P51 = jPKV7MDeclarations.P38 - jPKV7MDeclarations.P48 > 0 ? jPKV7MDeclarations.P38 - jPKV7MDeclarations.P48 - jPKV7MDeclarations.P49 - jPKV7MDeclarations.P50 : 0;

            if(FeatureActiveRS9249 == 1 && pLVATFormVariant.Equals("2"))
            {
                //If P_51> 0 then P_53 = 0 otherwise if (P_48 + P_49 + P_52) - P_38> = 0 then the calculation P_53 = P_48 - P_38 + P_49 + P_50 + P_52 otherwise 0
                if (jPKV7MDeclarations.P51 > 0)
                {
                    P53 = 0;
                }
                else if((jPKV7MDeclarations.P48 + jPKV7MDeclarations.P49 + jPKV7MDeclarations.P50 + jPKV7MDeclarations.P52) - jPKV7MDeclarations.P38 >= 0)
                {
                    P53 = jPKV7MDeclarations.P48 - jPKV7MDeclarations.P38 + jPKV7MDeclarations.P49 + jPKV7MDeclarations.P50 + jPKV7MDeclarations.P52;
                }
                else
                {
                    P53 = 0;
                }
            }
            else
            {
                //The amount of excess of input tax over due. If the difference in amounts between P_48 and P_38 is greater than or equal to 0, then P_53 = P_48 - P_38 + P_52, otherwise 0 should be shown.
                P53 = jPKV7MDeclarations.P48 - jPKV7MDeclarations.P38 >= 0 ? jPKV7MDeclarations.P48 - jPKV7MDeclarations.P38 + jPKV7MDeclarations.P52 : 0;
            }

            P62 = P53 - jPKV7MDeclarations.P54;
            var jPKV7MDeclarationsPConditionalValues = jPKV7MDeclarationsFactory.Create(jPKV7MDeclarations.DeclarationCommitmentType, jPKV7MDeclarations.DeclarationFormCode, jPKV7MDeclarations.DeclarationSchemaVersion, jPKV7MDeclarations.DeclarationSystemCode, jPKV7MDeclarations.DeclarationTaxCode, jPKV7MDeclarations.VariantDeclarationForm, jPKV7MDeclarations.Confirmation, jPKV7MDeclarations.P10, jPKV7MDeclarations.P11, jPKV7MDeclarations.P12, jPKV7MDeclarations.P13, jPKV7MDeclarations.P14, jPKV7MDeclarations.P15, jPKV7MDeclarations.P16, jPKV7MDeclarations.P17, jPKV7MDeclarations.P18, jPKV7MDeclarations.P19, jPKV7MDeclarations.P20, jPKV7MDeclarations.P21, jPKV7MDeclarations.P22, jPKV7MDeclarations.P23, jPKV7MDeclarations.P24, jPKV7MDeclarations.P25, jPKV7MDeclarations.P26, jPKV7MDeclarations.P27, jPKV7MDeclarations.P28, jPKV7MDeclarations.P29, jPKV7MDeclarations.P30, jPKV7MDeclarations.P31, jPKV7MDeclarations.P32, jPKV7MDeclarations.P33, jPKV7MDeclarations.P34, jPKV7MDeclarations.P35, jPKV7MDeclarations.P36, jPKV7MDeclarations.P37, jPKV7MDeclarations.P38, jPKV7MDeclarations.P39, jPKV7MDeclarations.P40, jPKV7MDeclarations.P41, jPKV7MDeclarations.P42, jPKV7MDeclarations.P43, jPKV7MDeclarations.P44, jPKV7MDeclarations.P45, jPKV7MDeclarations.P46, jPKV7MDeclarations.P47, jPKV7MDeclarations.P48, jPKV7MDeclarations.P49, jPKV7MDeclarations.P50, P51, jPKV7MDeclarations.P52, P53, jPKV7MDeclarations.P54, jPKV7MDeclarations.P540, jPKV7MDeclarations.P55, jPKV7MDeclarations.P56, jPKV7MDeclarations.P560, jPKV7MDeclarations.P57, jPKV7MDeclarations.P58, jPKV7MDeclarations.P59, jPKV7MDeclarations.P60, jPKV7MDeclarations.P61, P62, jPKV7MDeclarations.P63, jPKV7MDeclarations.P64, jPKV7MDeclarations.P65, jPKV7MDeclarations.P66, jPKV7MDeclarations.P660, jPKV7MDeclarations.P67, jPKV7MDeclarations.P68, jPKV7MDeclarations.P69, jPKV7MDeclarations.PORDZU);

            return jPKV7MDeclarationsPConditionalValues;
        }
        private IJPKV7MDeclarations RoundPValues(IJPKV7MDeclarations jPKV7MDeclarations)
        {
            int decimalPlaces = 0;
            decimal P10 = mathUtil.Round<decimal>(jPKV7MDeclarations.P10, decimalPlaces);
            decimal P11 = mathUtil.Round<decimal>(jPKV7MDeclarations.P11, decimalPlaces);
            decimal P12 = mathUtil.Round<decimal>(jPKV7MDeclarations.P12, decimalPlaces);
            decimal P13 = mathUtil.Round<decimal>(jPKV7MDeclarations.P13, decimalPlaces);
            decimal P14 = mathUtil.Round<decimal>(jPKV7MDeclarations.P14, decimalPlaces);
            decimal P15 = mathUtil.Round<decimal>(jPKV7MDeclarations.P15, decimalPlaces);
            decimal P16 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P16), decimalPlaces);
            decimal P17 = mathUtil.Round<decimal>(jPKV7MDeclarations.P17, decimalPlaces);
            decimal P18 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P18), decimalPlaces);
            decimal P19 = mathUtil.Round<decimal>(jPKV7MDeclarations.P19, decimalPlaces);
            decimal P20 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P20), decimalPlaces);
            decimal P21 = mathUtil.Round<decimal>(jPKV7MDeclarations.P21, decimalPlaces);
            decimal P22 = mathUtil.Round<decimal>(jPKV7MDeclarations.P22, decimalPlaces);
            decimal P23 = mathUtil.Round<decimal>(jPKV7MDeclarations.P23, decimalPlaces);
            decimal P24 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P24), decimalPlaces);
            decimal P25 = mathUtil.Round<decimal>(jPKV7MDeclarations.P25, decimalPlaces);
            decimal P26 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P26), decimalPlaces);
            decimal P27 = mathUtil.Round<decimal>(jPKV7MDeclarations.P27, decimalPlaces);
            decimal P28 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P28), decimalPlaces);
            decimal P29 = mathUtil.Round<decimal>(jPKV7MDeclarations.P29, decimalPlaces);
            decimal P30 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P30), decimalPlaces);
            decimal P31 = mathUtil.Round<decimal>(jPKV7MDeclarations.P31, decimalPlaces);
            decimal P32 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P32), decimalPlaces);
            decimal P33 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P33), decimalPlaces);
            decimal P34 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P34), decimalPlaces);
            decimal P35 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P35), decimalPlaces);
            decimal P36 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P36), decimalPlaces);
            decimal P37 = mathUtil.Round<decimal>(jPKV7MDeclarations.P37, decimalPlaces);
            decimal P38 = mathUtil.Round<decimal>(mathUtil.Abs<decimal>(jPKV7MDeclarations.P38), decimalPlaces);
            decimal P39 = mathUtil.Round<decimal>(jPKV7MDeclarations.P39, decimalPlaces);
            decimal P40 = mathUtil.Round<decimal>(jPKV7MDeclarations.P40, decimalPlaces);
            decimal P41 = mathUtil.Round<decimal>(jPKV7MDeclarations.P41, decimalPlaces);
            decimal P42 = mathUtil.Round<decimal>(jPKV7MDeclarations.P42, decimalPlaces);
            decimal P43 = mathUtil.Round<decimal>(jPKV7MDeclarations.P43, decimalPlaces);
            decimal P44 = mathUtil.Round<decimal>(jPKV7MDeclarations.P44, decimalPlaces);
            decimal P45 = mathUtil.Round<decimal>(jPKV7MDeclarations.P45, decimalPlaces);
            decimal P46 = mathUtil.Round<decimal>(jPKV7MDeclarations.P46, decimalPlaces);
            decimal P47 = mathUtil.Round<decimal>(jPKV7MDeclarations.P47, decimalPlaces);
            decimal P48 = mathUtil.Round<decimal>(jPKV7MDeclarations.P48, decimalPlaces);
            decimal P49 = mathUtil.Round<decimal>(jPKV7MDeclarations.P49, decimalPlaces);
            decimal P50 = mathUtil.Round<decimal>(jPKV7MDeclarations.P50, decimalPlaces);
            decimal P51 = mathUtil.Round<decimal>(jPKV7MDeclarations.P51, decimalPlaces);
            decimal P52 = mathUtil.Round<decimal>(jPKV7MDeclarations.P52, decimalPlaces);
            decimal P53 = mathUtil.Round<decimal>(jPKV7MDeclarations.P53, decimalPlaces);
            decimal P54 = mathUtil.Round<decimal>(jPKV7MDeclarations.P54, decimalPlaces);
            decimal P60 = mathUtil.Round<decimal>(jPKV7MDeclarations.P60, decimalPlaces);
            decimal P62 = mathUtil.Round<decimal>(jPKV7MDeclarations.P62, decimalPlaces);
            decimal P68 = mathUtil.Round<decimal>(Convert.ToDecimal(jPKV7MDeclarations.P68), decimalPlaces);
            decimal P69 = mathUtil.Round<decimal>(Convert.ToDecimal(jPKV7MDeclarations.P69), decimalPlaces);

            var jPKV7MDeclarationsRoundPValues = jPKV7MDeclarationsFactory.Create(jPKV7MDeclarations.DeclarationCommitmentType, jPKV7MDeclarations.DeclarationFormCode, jPKV7MDeclarations.DeclarationSchemaVersion, jPKV7MDeclarations.DeclarationSystemCode, jPKV7MDeclarations.DeclarationTaxCode, jPKV7MDeclarations.VariantDeclarationForm, jPKV7MDeclarations.Confirmation, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, jPKV7MDeclarations.P540, jPKV7MDeclarations.P55, jPKV7MDeclarations.P56, jPKV7MDeclarations.P560, jPKV7MDeclarations.P57, jPKV7MDeclarations.P58, jPKV7MDeclarations.P59, P60, jPKV7MDeclarations.P61, P62, jPKV7MDeclarations.P63, jPKV7MDeclarations.P64, jPKV7MDeclarations.P65, jPKV7MDeclarations.P66, jPKV7MDeclarations.P660, jPKV7MDeclarations.P67, P68, P69, jPKV7MDeclarations.PORDZU);

            return jPKV7MDeclarationsRoundPValues;
        }

        private int IsFeatureRS9249Active()
        {
            string ProductNameRS9249 = "CSI";
            string FeatureIDRS9249 = "RS9249";
            int? IsFeatureActive = this.IsFeatureActive.IsFeatureActiveFn(ProductNameRS9249, FeatureIDRS9249);
            int FeatureRS9249Active = 0;

            if (IsFeatureActive == 1 && this.IsAddonAvailable.IsAddonAvailableFn("PolandCountryPack") == 1)
            {
                FeatureRS9249Active = 1;
            }
            return FeatureRS9249Active;
        }
    }
}
