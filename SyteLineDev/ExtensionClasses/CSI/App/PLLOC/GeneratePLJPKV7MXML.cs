using CSI.Data.Functions;
using CSI.MG;
using System;
using PLLOC.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using CSI.Data.Utilities;
using CSI.Data;
using CSI.Admin;
using System.Linq;

namespace CSI.PLLOC
{
    public interface IGeneratePLJPKV7MXML
    {
        (int? Severity, string Infobar) Process(string Infobar, DateTime BeginTaxDate,
                        DateTime EndTaxDate,
                        string LogicalFolder,
                        string Filename,
                        string SubmissionMode,
                        string Confirmation,
                        decimal P39,
                        decimal P49,
                        decimal P50,
                        decimal P52,
                        decimal P54,
                        byte P540,
                        byte P55,
                        byte P56,
                        byte P560,
                        byte P57,
                        byte P58,
                        byte P59,
                        decimal P60,
                        string P61,
                        byte P63,
                        byte P64,
                        byte P65,
                        byte P66,
                        byte P660,
                        byte P67,
                        decimal P68,
                        decimal P69,
                        string Justification,
                        string PLVATSystemCode,
                        string PLVATStructureVersion,
                        string PLVATFormVariant,
                        string PLVATOfficeCode,
                        string PLVATDeclarationCode,
                        string PLVATDeclarationSystem,
                        string PLVATDeclarationTaxCode,
                        string PLVATDeclarationCommitment,
                        string PLVATDeclarationSchemaVersion,
                        string PLVATDeclarationVariant,
                        string PLVATPhone,
                        string PLVATEmailAddr,
                        byte? TaxJurTaxSystem = null,
                        byte? ExOptszShowDetail = null,
                        string TaxJurTaxJur = null,
                        short? TaxDateStartingOffset = null,
                        short? TaxDateEndingOffset = null,
                        string ExOptgoJournalId = null,
                        byte? DisplayHeader = null,
                        string BGSessionId = null,
                        int? TaskId = null,
                        string pSite = null,
                        string BGUser = null,
                        string SortBy = null,
                        byte? ExcludenullLineNum = (byte)0,
                        byte? ExcludeJournalEntries = null,
                        string TaxRegNum = null);
    }
    public class GeneratePLJPKV7MXML : IGeneratePLJPKV7MXML
    {
        readonly IMsgApp msgApp;

        (IJPKV7MHeader CreateHeader, IJPKV7MEntity1 CreateEntity1) pLJPKVATHeaderViews;
        readonly IJPKV7MDeclarationsManager jPKV7MDeclarationsManager;
        readonly IRptVATManager rptVATManager;
        readonly IXMLFileToServerManager XMLFileToServerManager;
        readonly IXmlTextWriterUtil xmlTextWriterUtil;

        readonly IRptVATValuesFromSp rptVATValuesFromSp;
        readonly IPLJPKVATHeaderViewsFactory pLJPKVATHeaderViewsFactory;

        readonly IRptVATValuesFromSpCRUD rptVATValuesFromSpCRUD;
        readonly IIsAddonAvailable IsAddonAvailable;
        readonly IIsFeatureActive IsFeatureActive;

        private readonly IStringUtil stringUtil;
        private const string elementPrefix = "tns:";
        private const string rootElement = "JPK";
        private const string datetimeFormat = "yyyy-MM-dd'T'HH:mm:ss'Z'";
        private const string dateFormat = "yyyy-MM-dd";

        private const string amountFormat = "F";
        private const string entityrole = "Podatnik";
        private const string tnsnamespace1 = @"http://crd.gov.pl/wzor/2020/05/08/9393/";
        private const string xsinamespace1 = @"http://www.w3.org/2001/XMLSchema-instance";
        private const string etdnamespace1 = @"http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2020/03/11/eD/DefinicjeTypy/";

        private const string tnsnamespace2 = @"http://crd.gov.pl/wzor/2021/12/27/11148/";
        private const string xsinamespace2 = @"http://www.w3.org/2001/XMLSchema-instance";
        private const string etdnamespace2 = @"http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2021/06/08/eD/DefinicjeTypy/";

        private int FeatureActiveRS9249 => this.IsFeatureRS9249Active();
        public GeneratePLJPKV7MXML(
        IPLJPKVATHeaderViewsFactory pLJPKVATHeaderViewsFactory,
        IJPKV7MDeclarationsManager jPKV7MDeclarationsManager,
        IRptVATManager rptVATManager,
        IXMLFileToServerManager XMLFileToServerManager,
        IXmlTextWriterUtil xmlTextWriterUtil,
        IRptVATValuesFromSp rptVATValuesFromSp,
        IMsgApp msgApp,
        IRptVATValuesFromSpCRUD rptVATValuesFromSpCRUD,
        IIsAddonAvailable IsAddonAvailable,
        IIsFeatureActive IsFeatureActive,
        IStringUtil stringUtil)
        {
            this.pLJPKVATHeaderViewsFactory = pLJPKVATHeaderViewsFactory;
            this.jPKV7MDeclarationsManager = jPKV7MDeclarationsManager;
            this.rptVATManager = rptVATManager;
            this.XMLFileToServerManager = XMLFileToServerManager;
            this.xmlTextWriterUtil = xmlTextWriterUtil;
            this.rptVATValuesFromSp = rptVATValuesFromSp;
            this.msgApp = msgApp;
            this.rptVATValuesFromSpCRUD = rptVATValuesFromSpCRUD;
            this.IsAddonAvailable = IsAddonAvailable;
            this.IsFeatureActive = IsFeatureActive;
            this.stringUtil = stringUtil;
        }

        public (int? Severity, string Infobar) Process(string Infobar, DateTime BeginTaxDate, DateTime EndTaxDate, string LogicalFolder, string Filename, string SubmissionMode, string Confirmation, decimal P39, decimal P49, decimal P50, decimal P52, decimal P54, byte P540, byte P55, byte P56, byte P560, byte P57, byte P58, byte P59, decimal P60, string P61, byte P63, byte P64, byte P65, byte P66, byte P660, byte P67, decimal P68, decimal P69, string Justification, string PLVATSystemCode, string PLVATStructureVersion, string PLVATFormVariant, string PLVATOfficeCode, string PLVATDeclarationCode, string PLVATDeclarationSystem, string PLVATDeclarationTaxCode, string PLVATDeclarationCommitment, string PLVATDeclarationSchemaVersion, string PLVATDeclarationVariant, string PLVATPhone, string PLVATEmailAddr, byte? TaxJurTaxSystem, byte? ExOptszShowDetail, string TaxJurTaxJur, short? TaxDateStartingOffset, short? TaxDateEndingOffset, string ExOptgoJournalId, byte? DisplayHeader, string BGSessionId, int? TaskId, string pSite, string BGUser, string SortBy, byte? ExcludeNullLineNum, byte? ExcludeJournalEntries, string TaxRegNum)
        {
            int? result = 0;
            int? severity = 0;
            var writer = xmlTextWriterUtil;

            string[] FormVariantCondition = { "1", "2"};

            bool isJPKTaxParametersComplete = FeatureActiveRS9249 == 1 ?
                IsJPKTaxParametersComplete(PLVATSystemCode, PLVATStructureVersion, PLVATFormVariant, PLVATOfficeCode, PLVATDeclarationCode, PLVATDeclarationSystem, PLVATDeclarationTaxCode, PLVATDeclarationCommitment, PLVATDeclarationSchemaVersion, PLVATDeclarationVariant, PLVATPhone, PLVATEmailAddr)
                : IsJPKTaxParametersComplete(PLVATSystemCode, PLVATStructureVersion, PLVATFormVariant, PLVATOfficeCode, PLVATDeclarationCode, PLVATDeclarationSystem, PLVATDeclarationTaxCode, PLVATDeclarationCommitment, PLVATDeclarationSchemaVersion, PLVATDeclarationVariant);

            if (!isJPKTaxParametersComplete)
            {
                var msgJPKExportXMLIncompleteTaxParameterSetup = msgApp.MsgAppSp(null, "JPKExportXMLIncompleteTaxParameterSetup", null);
                Infobar = msgJPKExportXMLIncompleteTaxParameterSetup.Infobar;
                severity = msgJPKExportXMLIncompleteTaxParameterSetup.ReturnCode;

                return (severity, Infobar);
            }

            if (FeatureActiveRS9249 == 1 && !FormVariantCondition.AsEnumerable().Any(a => a == PLVATFormVariant))
            {
                var JPKExportXMLFormVariantValidation = msgApp.MsgAppSp(null, "JPKExportXMLFormVariantValidation", null);
                Infobar = JPKExportXMLFormVariantValidation.Infobar;
                severity = JPKExportXMLFormVariantValidation.ReturnCode;

                return (severity, Infobar);
            }

            pLJPKVATHeaderViews = FeatureActiveRS9249 == 1?
                pLJPKVATHeaderViewsFactory.Create(pSite, TaxRegNum, PLVATSystemCode, PLVATStructureVersion, PLVATFormVariant, PLVATOfficeCode, PLVATPhone, PLVATEmailAddr, SubmissionMode, BeginTaxDate, EndTaxDate) :
                pLJPKVATHeaderViewsFactory.Create(pSite, TaxRegNum, PLVATSystemCode, PLVATStructureVersion, PLVATFormVariant, PLVATOfficeCode, SubmissionMode, BeginTaxDate, EndTaxDate);

            var dtRpt_VATSp = rptVATValuesFromSp.GetRpt_VATSp(TaxJurTaxSystem, ExOptszShowDetail, TaxJurTaxJur, BeginTaxDate, EndTaxDate,
                TaxDateStartingOffset, TaxDateEndingOffset, ExOptgoJournalId, DisplayHeader, BGSessionId, TaskId, pSite, BGUser, SortBy, ExcludeNullLineNum, ExcludeJournalEntries);
            var dtCLM_VatProceduralMarkingsSp = rptVATValuesFromSp.GetCLM_VatProceduralMarkingsSp(BeginTaxDate, EndTaxDate);
            var setResultToRPTVATManager = rptVATValuesFromSp.SetResultToRPTVATManager(dtRpt_VATSp, dtCLM_VatProceduralMarkingsSp);
            var getJPKV7MDeclarationsManager = jPKV7MDeclarationsManager.Process(Confirmation, P39, P49, P50, P52, P54, P540, P55, P56, P560, P57, P58, P59, P60, P61, P63, P64, P65, P66, P660, P67, P68, P69, Justification, PLVATDeclarationCommitment, PLVATDeclarationCode, PLVATDeclarationSchemaVersion, PLVATDeclarationSystem, PLVATDeclarationTaxCode, PLVATDeclarationVariant, PLVATFormVariant);
            if (setResultToRPTVATManager)
            {
                IJPKV7MHeader header = pLJPKVATHeaderViews.CreateHeader;
                IJPKV7MEntity1 entity1 = pLJPKVATHeaderViews.CreateEntity1;
                IJPKV7MDeclarations declarations = getJPKV7MDeclarationsManager;
                IList<IJPK7MSalesRegister> salesRegister = rptVATManager.GetJPK7MSalesRegister();
                IJPKV7MSalesControl salesControl = rptVATManager.GetJPKV7MSalesControl();
                IList<IJPKV7MPurchaseRegister> purchaseRegister = rptVATManager.GetJPKV7MPurchaseRegister();
                IJPKV7MPurchaseControl purchaseControl = rptVATManager.GetJPKV7MPurchaseControl();

                if ((rptVATManager.IsPopulatedJPK7MSalesRegister && rptVATManager.IsPopulatedJPKV7MSalesControl) || (rptVATManager.IsPopulatedJPKV7MPurchaseRegister && rptVATManager.IsPopulatedJPKV7MPurchaseControl))
                {
                    string tnsnamespace = "";
                    string xsinamespace = "";
                    string etdnamespace = "";

                    if (PLVATFormVariant == "2" && FeatureActiveRS9249 ==1)
                    {
                        tnsnamespace = tnsnamespace2;
                        xsinamespace = xsinamespace2;
                        etdnamespace = etdnamespace2;
                    }
                    else
                    {
                        tnsnamespace = tnsnamespace1;
                        xsinamespace = xsinamespace1;
                        etdnamespace = etdnamespace1;
                    }

                    writer.WriteStartElement(elementPrefix + rootElement);
                    writer.WriteAttributeString("xmlns:tns", tnsnamespace);
                    writer.WriteAttributeString("xmlns:xsi", xsinamespace);
                    writer.WriteAttributeString("xmlns:etd", etdnamespace);
                    WriteHeader(ref writer, header);
                    WriteEntity1(ref writer, entity1);
                    WriteDeclarations(ref writer, declarations, header);
                    writer.WriteStartElement(elementPrefix + "Ewidencja");
                    if (rptVATManager.IsPopulatedJPKV7MSalesControl)
                    {
                        WriteSalesRegister(ref writer, salesRegister, header.FormVariant);
                        WriteSalesControl(ref writer, salesControl);
                    }

                    if (rptVATManager.IsPopulatedJPKV7MPurchaseControl)
                    {
                        WritePurchaseRegister(ref writer, purchaseRegister, header.FormVariant);
                        WritePurchaseControl(ref writer, purchaseControl);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.Close();

                    result = XMLFileToServerManager.SaveXMLToServer(ref Infobar, LogicalFolder, Filename, writer.GetXMLString());
                    if (result == 0)
                    {
                        severity = 16;
                    }
                }
                else
                {
                    var msgJPKExportXMLIncompleteTaxParameterSetup = msgApp.MsgAppSp(null, "JPKExportXMLNoDataProcessed", null);
                    Infobar = msgJPKExportXMLIncompleteTaxParameterSetup.Infobar;
                    severity = msgJPKExportXMLIncompleteTaxParameterSetup.ReturnCode;
                }
            }
            return (severity, Infobar);
        }

        private bool IsJPKTaxParametersComplete(string PLVATSystemCode,
                    string PLVATStructureVersion,
                    string PLVATFormVariant,
                    string PLVATOfficeCode,
                    string PLVATDeclarationCode,
                    string PLVATDeclarationSystem,
                    string PLVATDeclarationTaxCode,
                    string PLVATDeclarationCommitment,
                    string PLVATDeclarationSchemaVersion,
                    string PLVATDeclarationVariant)
        {
            if (PLVATSystemCode == null) return false;
            if (PLVATStructureVersion == null) return false;
            if (PLVATFormVariant == null) return false;
            if (PLVATOfficeCode == null) return false;
            if (PLVATDeclarationCode == null) return false;
            if (PLVATDeclarationSystem == null) return false;
            if (PLVATDeclarationTaxCode == null) return false;
            if (PLVATDeclarationCommitment == null) return false;
            if (PLVATDeclarationSchemaVersion == null) return false;
            if (PLVATDeclarationVariant == null) return false;

            return true;
        }

        private bool IsJPKTaxParametersComplete(string PLVATSystemCode,
                    string PLVATStructureVersion,
                    string PLVATFormVariant,
                    string PLVATOfficeCode,
                    string PLVATDeclarationCode,
                    string PLVATDeclarationSystem,
                    string PLVATDeclarationTaxCode,
                    string PLVATDeclarationCommitment,
                    string PLVATDeclarationSchemaVersion,
                    string PLVATDeclarationVariant,
                    string PLVATPhone,
                    string PLVATEmailAddr)
        {
            if (PLVATSystemCode == null) return false;
            if (PLVATStructureVersion == null) return false;
            if (PLVATFormVariant == null) return false;
            if (PLVATOfficeCode == null) return false;
            if (PLVATDeclarationCode == null) return false;
            if (PLVATDeclarationSystem == null) return false;
            if (PLVATDeclarationTaxCode == null) return false;
            if (PLVATDeclarationCommitment == null) return false;
            if (PLVATDeclarationSchemaVersion == null) return false;
            if (PLVATDeclarationVariant == null) return false;
            if (PLVATPhone == null) return false;
            if (PLVATEmailAddr == null) return false;

            return true;
        }

        private void WriteHeader(ref IXmlTextWriterUtil writer, IJPKV7MHeader header)
        {
            writer.WriteStartElement(elementPrefix + "Naglowek");

            writer.WriteStartElement(elementPrefix + "KodFormularza");
            writer.WriteAttributeString("kodSystemowy", header.FormSystemCode);
            writer.WriteAttributeString("wersjaSchemy", header.FormSchemaVersion);
            writer.WriteString(header.FormCode);
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "WariantFormularza");
            writer.WriteString(header.FormVariant);
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "DataWytworzeniaJPK");
            writer.WriteString(header.JPKProductionDate.ToString(datetimeFormat, CultureInfo.InvariantCulture));
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "NazwaSystemu");
            writer.WriteString(header.SystemName);
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "CelZlozenia");
            writer.WriteAttributeString("poz", header.Item);
            writer.WriteString(header.OrderPurpose);
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "KodUrzedu");
            writer.WriteString(header.OfficeCode);
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "Rok");
            writer.WriteString(header.Year.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "Miesiac");
            writer.WriteString(header.Month.ToString());
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
        private void WriteEntity1(ref IXmlTextWriterUtil writer, IJPKV7MEntity1 entity1)
        {
            writer.WriteStartElement(elementPrefix + "Podmiot1");
            writer.WriteAttributeString("rola", entityrole);
            writer.WriteStartElement(elementPrefix + "OsobaNiefizyczna");

            writer.WriteStartElement(elementPrefix + "NIP");
            writer.WriteString(entity1.TaxId);
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "PelnaNazwa");
            writer.WriteString(entity1.Name);
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "Email");
            writer.WriteString(entity1.Email);
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "Telefon");
            writer.WriteString(entity1.Phone);
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void ValidateTagsAmount(ref IXmlTextWriterUtil writer, string tag, decimal? amount, bool IsCultureInfo) //, bool isRequired = false
        {
            string value = "";
            value = IsCultureInfo ? stringUtil.Format(amount, amountFormat, "en-US") : Math.Truncate((decimal)amount).ToString();
            writer.WriteStartElement(elementPrefix + tag);
            writer.WriteString(value);
            writer.WriteEndElement();
        }

        private void WriteDeclarations(ref IXmlTextWriterUtil writer, IJPKV7MDeclarations declarations, IJPKV7MHeader header)
        {
            writer.WriteStartElement(elementPrefix + "Deklaracja");

            writer.WriteStartElement(elementPrefix + "Naglowek");

            writer.WriteStartElement(elementPrefix + "KodFormularzaDekl");
            writer.WriteAttributeString("kodSystemowy", declarations.DeclarationSystemCode);
            writer.WriteAttributeString("kodPodatku", declarations.DeclarationTaxCode);
            writer.WriteAttributeString("rodzajZobowiazania", declarations.DeclarationCommitmentType);
            writer.WriteAttributeString("wersjaSchemy", declarations.DeclarationSchemaVersion);
            writer.WriteString(declarations.DeclarationFormCode);
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "WariantFormularzaDekl");
            writer.WriteString(declarations.VariantDeclarationForm);
            writer.WriteEndElement();

            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "PozycjeSzczegolowe");


            ValidateTagsAmount(ref writer, "P_10", declarations.P10, false);
            ValidateTagsAmount(ref writer, "P_11", declarations.P11, false);
            ValidateTagsAmount(ref writer, "P_12", declarations.P12, false);
            ValidateTagsAmount(ref writer, "P_13", declarations.P13, false);
            ValidateTagsAmount(ref writer, "P_14", declarations.P14, false);
            ValidateTagsAmount(ref writer, "P_15", declarations.P15, false);
            ValidateTagsAmount(ref writer, "P_16", declarations.P16, false);
            ValidateTagsAmount(ref writer, "P_17", declarations.P17, false);
            ValidateTagsAmount(ref writer, "P_18", declarations.P18, false);
            ValidateTagsAmount(ref writer, "P_19", declarations.P19, false);
            ValidateTagsAmount(ref writer, "P_20", declarations.P20, false);
            ValidateTagsAmount(ref writer, "P_21", declarations.P21, false);
            ValidateTagsAmount(ref writer, "P_22", declarations.P22, false);
            ValidateTagsAmount(ref writer, "P_23", declarations.P23, false);
            ValidateTagsAmount(ref writer, "P_24", declarations.P24, false);
            ValidateTagsAmount(ref writer, "P_25", declarations.P25, false);
            ValidateTagsAmount(ref writer, "P_26", declarations.P26, false);
            ValidateTagsAmount(ref writer, "P_27", declarations.P27, false);
            ValidateTagsAmount(ref writer, "P_28", declarations.P28, false);
            ValidateTagsAmount(ref writer, "P_29", declarations.P29, false);
            ValidateTagsAmount(ref writer, "P_30", declarations.P30, false);
            ValidateTagsAmount(ref writer, "P_31", declarations.P31, false);
            ValidateTagsAmount(ref writer, "P_32", declarations.P32, false);
            ValidateTagsAmount(ref writer, "P_33", declarations.P33, false);
            ValidateTagsAmount(ref writer, "P_34", declarations.P34, false);
            ValidateTagsAmount(ref writer, "P_35", declarations.P35, false);
            ValidateTagsAmount(ref writer, "P_36", declarations.P36, false);
            ValidateTagsAmount(ref writer, "P_37", declarations.P37, false);

            writer.WriteStartElement(elementPrefix + "P_38");
            writer.WriteString(Math.Truncate(declarations.P38).ToString()); 
            writer.WriteEndElement();

            ValidateTagsAmount(ref writer, "P_39", declarations.P39, false);
            ValidateTagsAmount(ref writer, "P_40", declarations.P40, false);
            ValidateTagsAmount(ref writer, "P_41", declarations.P41, false);
            ValidateTagsAmount(ref writer, "P_42", declarations.P42, false);
            ValidateTagsAmount(ref writer, "P_43", declarations.P43, false);
            ValidateTagsAmount(ref writer, "P_44", declarations.P44, false);
            ValidateTagsAmount(ref writer, "P_45", declarations.P45, false);
            ValidateTagsAmount(ref writer, "P_46", declarations.P46, false);
            ValidateTagsAmount(ref writer, "P_47", declarations.P47, false);
            ValidateTagsAmount(ref writer, "P_48", declarations.P48, false);
            ValidateTagsAmount(ref writer, "P_49", declarations.P49, false);
            ValidateTagsAmount(ref writer, "P_50", declarations.P50, false);

            writer.WriteStartElement(elementPrefix + "P_51");
            writer.WriteString(Math.Truncate(declarations.P51).ToString());
            writer.WriteEndElement();

            ValidateTagsAmount(ref writer, "P_52", declarations.P52, false);
            ValidateTagsAmount(ref writer, "P_53", declarations.P53, false);

            if (declarations.P54 > 0)
            {
                ValidateTagsAmount(ref writer, "P_54", declarations.P54, false);

                if (FeatureActiveRS9249 == 1 && Convert.ToInt32(header.FormVariant) == 2 && Convert.ToInt32(declarations.P540) == 1)
                {
                    ValidateTagsAmount(ref writer, "P_540", declarations.P540, false);
                }
                if (Convert.ToInt32(declarations.P55) == 1)
                {
                    ValidateTagsAmount(ref writer, "P_55", declarations.P55, false);
                }
                if (Convert.ToInt32(declarations.P56) == 1)
                {
                    ValidateTagsAmount(ref writer, "P_56", declarations.P56, false);
                }
                if (FeatureActiveRS9249 == 1 && Convert.ToInt32(header.FormVariant) == 2 && Convert.ToInt32(declarations.P560) == 1)
                {
                    ValidateTagsAmount(ref writer, "P_560", declarations.P560, false);
                }   
                if (Convert.ToInt32(declarations.P57) == 1)
                {
                    ValidateTagsAmount(ref writer, "P_57", declarations.P57, false);
                }
                if (Convert.ToInt32(declarations.P58) == 1)
                {
                    ValidateTagsAmount(ref writer, "P_58", declarations.P58, false);
                }
            }

            if (Convert.ToInt32(declarations.P59) == 1)
            {
                ValidateTagsAmount(ref writer, "P_59", declarations.P59, false);
                ValidateTagsAmount(ref writer, "P_60", declarations.P60, false);

                writer.WriteStartElement(elementPrefix + "P_61");
                writer.WriteString(declarations.P61);
                writer.WriteEndElement();
            }

            ValidateTagsAmount(ref writer, "P_62", declarations.P62, false);

            if (Convert.ToInt32(declarations.P63) == 1)
            {
                ValidateTagsAmount(ref writer, "P_63", declarations.P63, false);
            }
            if (Convert.ToInt32(declarations.P64) == 1)
            {
                ValidateTagsAmount(ref writer, "P_64", declarations.P64, false);
            }
            if (Convert.ToInt32(declarations.P65) == 1)
            {
                ValidateTagsAmount(ref writer, "P_65", declarations.P65, false);
            }
            if (Convert.ToInt32(declarations.P66) == 1)
            {
                ValidateTagsAmount(ref writer, "P_66", declarations.P66, false);
            }
            if (FeatureActiveRS9249 == 1 && Convert.ToInt32(header.FormVariant) == 2 && Convert.ToInt32(declarations.P660) == 1)
            {
                ValidateTagsAmount(ref writer, "P_660", declarations.P660, false);
            }
            if (Convert.ToInt32(declarations.P67) == 1)
            {
                writer.WriteStartElement(elementPrefix + "P_67");
                writer.WriteString("1");
                writer.WriteEndElement();
            }
            ValidateTagsAmount(ref writer, "P_68", declarations.P68, false);
            ValidateTagsAmount(ref writer, "P_69", declarations.P69, false);

            if (declarations.PORDZU != null && header.OrderPurpose == "2")
            {
                writer.WriteStartElement(elementPrefix + "P_ORDZU");
                writer.WriteString(declarations.PORDZU);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "Pouczenia");
            writer.WriteString(Convert.ToInt32(declarations.Confirmation).ToString());
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
        private void WriteSalesRegister(ref IXmlTextWriterUtil writer, IList<IJPK7MSalesRegister> salesRegister, string formVariant)
        {
            foreach (var item in salesRegister)
            {
                writer.WriteStartElement(elementPrefix + "SprzedazWiersz");

                writer.WriteStartElement(elementPrefix + "LpSprzedazy");
                writer.WriteString(item.SalesNumber);
                writer.WriteEndElement();

                bool hasCountryCode = !String.IsNullOrEmpty(item.CounterPartyNo) && Char.IsLetter(item.CounterPartyNo[0]) && Char.IsLetter(item.CounterPartyNo[1]);
                bool countryCodeValid = rptVATValuesFromSpCRUD.IsCountryCodeValid(item.CounterPartyNo?.Substring(0, 2));

                if (!string.IsNullOrEmpty(item.CountryOriginCodeTIN) || !(item.CounterPartyNo.ToString() == "BRAK"))
                {
                    writer.WriteStartElement(elementPrefix + "KodKrajuNadaniaTIN");
                    if (hasCountryCode && countryCodeValid)
                    {
                        writer.WriteString(item.CounterPartyNo.Substring(0,2));
                    }
                    else
                    {
                        writer.WriteString(item.CountryOriginCodeTIN);
                    }
                    writer.WriteEndElement();
                }

                writer.WriteStartElement(elementPrefix + "NrKontrahenta");
                if(FeatureActiveRS9249 == 1)
                {
                    if (string.IsNullOrEmpty(item.CounterPartyNo) || item.CounterPartyNo.ToString() == "BRAK")
                    {
                        writer.WriteString("BRAK");
                    }
                    else
                    {
                        if (hasCountryCode && countryCodeValid)
                        {
                            writer.WriteString(item.CounterPartyNo.Remove(0, 2));
                        }
                        else
                        {
                            writer.WriteString(item.CounterPartyNo);
                        }
                    }
                }
                else
                {
                    if (hasCountryCode && countryCodeValid)
                    {
                        writer.WriteString(item.CounterPartyNo.Remove(0, 2));
                    }
                    else
                    {
                        writer.WriteString(item.CounterPartyNo);
                    }
                }


                writer.WriteEndElement();

                writer.WriteStartElement(elementPrefix + "NazwaKontrahenta");
                writer.WriteString(item.ContractorsName);
                writer.WriteEndElement();
                writer.WriteStartElement(elementPrefix + "DowodSprzedazy");
                writer.WriteString(item.SalesEvidence);
                writer.WriteEndElement();
                writer.WriteStartElement(elementPrefix + "DataWystawienia");
                writer.WriteString(Convert.ToDateTime(item.IssueDate).ToString(dateFormat));
                writer.WriteEndElement();
                writer.WriteStartElement(elementPrefix + "DataSprzedazy");
                writer.WriteString(Convert.ToDateTime(item.SalesDate).ToString(dateFormat));
                writer.WriteEndElement();

                if (item.DocumentType != "")
                {
                    writer.WriteStartElement(elementPrefix + "TypDokumentu");
                    writer.WriteString(item.DocumentType);
                    writer.WriteEndElement();
                }

                if (item.GTU1)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_01");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.GTU2)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_02");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.GTU3)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_03");
                    writer.WriteString(Convert.ToInt32(item.GTU3).ToString());
                    writer.WriteEndElement();
                }
                if (item.GTU4)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_04");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.GTU5)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_05");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.GTU6)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_06");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.GTU7)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_07");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.GTU8)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_08");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.GTU9)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_09");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.GTU10)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_10");
                    writer.WriteString(Convert.ToInt32(item.GTU10).ToString());
                    writer.WriteEndElement();
                }
                if (item.GTU11)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_11");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.GTU12)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_12");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.GTU13)
                {
                    writer.WriteStartElement(elementPrefix + "GTU_13");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.WSTO_EE && FeatureActiveRS9249 == 1 && Convert.ToInt32(formVariant) == 2)
                {
                    writer.WriteStartElement(elementPrefix + "WSTO_EE");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.IED && FeatureActiveRS9249 == 1 && Convert.ToInt32(formVariant) == 2)
                {
                    writer.WriteStartElement(elementPrefix + "IED");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.SW && (FeatureActiveRS9249 != 1 || Convert.ToInt32(formVariant) != 2))
                {
                    writer.WriteStartElement(elementPrefix + "SW");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.EE && (FeatureActiveRS9249 != 1 || Convert.ToInt32(formVariant) != 2))
                {
                    writer.WriteStartElement(elementPrefix + "EE");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.TP)
                {
                    writer.WriteStartElement(elementPrefix + "TP");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.TTWNT)
                {
                    writer.WriteStartElement(elementPrefix + "TT_WNT");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.TTD)
                {
                    writer.WriteStartElement(elementPrefix + "TT_D");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.MRT)
                {
                    writer.WriteStartElement(elementPrefix + "MR_T");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.MRUZ)
                {
                    writer.WriteStartElement(elementPrefix + "MR_UZ");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.I42)
                {
                    writer.WriteStartElement(elementPrefix + "I_42");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.I63)
                {
                    writer.WriteStartElement(elementPrefix + "I_63");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.BSPV)
                {
                    writer.WriteStartElement(elementPrefix + "B_SPV");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.BSPVDOSTAWA)
                {
                    writer.WriteStartElement(elementPrefix + "B_SPV_DOSTAWA");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.BMPVPROWIZJA)
                {
                    writer.WriteStartElement(elementPrefix + "B_MPV_PROWIZJA");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.MPP && (FeatureActiveRS9249 != 1 || Convert.ToInt32(formVariant) != 2))
                {
                    writer.WriteStartElement(elementPrefix + "MPP");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.BaseCorrection)
                {
                    writer.WriteStartElement(elementPrefix + "KorektaPodstawyOpodt");
                    writer.WriteString("1");
                    writer.WriteEndElement();

                    if(item.DueDate != null && FeatureActiveRS9249 == 1 && Convert.ToInt32(formVariant) == 2)
                    {
                        writer.WriteStartElement(elementPrefix + "TerminPlatnosci");
                        writer.WriteString(Convert.ToDateTime(item.DueDate).ToString(dateFormat));
                        writer.WriteEndElement();
                    }
                }

                ValidateTagsAmount(ref writer, "K_10", item.K10, true);
                ValidateTagsAmount(ref writer, "K_11", item.K11, true);
                ValidateTagsAmount(ref writer, "K_12", item.K12, true);
                ValidateTagsAmount(ref writer, "K_13", item.K13, true);
                ValidateTagsAmount(ref writer, "K_14", item.K14, true);
                ValidateTagsAmount(ref writer, "K_15", item.K15, true);
                ValidateTagsAmount(ref writer, "K_16", item.K16, true);
                ValidateTagsAmount(ref writer, "K_17", item.K17, true);
                ValidateTagsAmount(ref writer, "K_18", item.K18, true);
                ValidateTagsAmount(ref writer, "K_19", item.K19, true);
                ValidateTagsAmount(ref writer, "K_20", item.K20, true);
                ValidateTagsAmount(ref writer, "K_21", item.K21, true);
                ValidateTagsAmount(ref writer, "K_22", item.K22, true);
                ValidateTagsAmount(ref writer, "K_23", item.K23, true);
                ValidateTagsAmount(ref writer, "K_24", item.K24, true);
                ValidateTagsAmount(ref writer, "K_25", item.K25, true);
                ValidateTagsAmount(ref writer, "K_26", item.K26, true);
                ValidateTagsAmount(ref writer, "K_27", item.K27, true);
                ValidateTagsAmount(ref writer, "K_28", item.K28, true);
                ValidateTagsAmount(ref writer, "K_29", item.K29, true);
                ValidateTagsAmount(ref writer, "K_30", item.K30, true);
                ValidateTagsAmount(ref writer, "K_31", item.K31, true);
                ValidateTagsAmount(ref writer, "K_32", item.K32, true);
                ValidateTagsAmount(ref writer, "K_33", item.K33, true);
                ValidateTagsAmount(ref writer, "K_34", item.K34, true);
                ValidateTagsAmount(ref writer, "K_35", item.K35, true);
                ValidateTagsAmount(ref writer, "K_36", item.K36, true);

                writer.WriteEndElement();

            }
        }
        private void WriteSalesControl(ref IXmlTextWriterUtil writer, IJPKV7MSalesControl salesControl)
        {

            writer.WriteStartElement(elementPrefix + "SprzedazCtrl");

            writer.WriteStartElement(elementPrefix + "LiczbaWierszySprzedazy");
            writer.WriteString(salesControl.SalesCount.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "PodatekNalezny");
            writer.WriteString(salesControl.TaxDues.ToString(amountFormat, CultureInfo.InvariantCulture));
            writer.WriteEndElement();

            writer.WriteEndElement();

        }
        private void WritePurchaseRegister(ref IXmlTextWriterUtil writer, IList<IJPKV7MPurchaseRegister> purchaseRegister, string formVariant)
        {

            foreach (var item in purchaseRegister)
            {
                writer.WriteStartElement(elementPrefix + "ZakupWiersz");
                writer.WriteStartElement(elementPrefix + "LpZakupu");
                writer.WriteString(item.PurchaseNumber.ToString());
                writer.WriteEndElement();

                bool hasCountryCode = !String.IsNullOrEmpty(item.SupplierNumber) && Char.IsLetter(item.SupplierNumber[0]) && Char.IsLetter(item.SupplierNumber[1]);
                bool countryCodeValid = rptVATValuesFromSpCRUD.IsCountryCodeValid(item.SupplierNumber?.Substring(0, 2));

                if (!string.IsNullOrEmpty(item.CountryOriginCodeTIN) || !(item.SupplierNumber.ToString() == "BRAK"))
                {
                    writer.WriteStartElement(elementPrefix + "KodKrajuNadaniaTIN");
                    if (hasCountryCode && countryCodeValid)
                    {
                        writer.WriteString(item.SupplierNumber.Substring(0, 2));
                    }
                    else
                    {
                        writer.WriteString(item.CountryOriginCodeTIN.ToString());
                    }
                    writer.WriteEndElement();
                }

                writer.WriteStartElement(elementPrefix + "NrDostawcy");
                if (FeatureActiveRS9249 == 1)
                {
                    if (string.IsNullOrEmpty(item.SupplierNumber) || item.SupplierNumber.ToString() == "BRAK")
                    {
                        writer.WriteString("BRAK");
                    }
                    else
                    {
                        if (hasCountryCode && countryCodeValid)
                        {
                            writer.WriteString(item.SupplierNumber.Remove(0, 2));
                        }
                        else
                        {
                            writer.WriteString(item.SupplierNumber);
                        }
                    }
                }
                else
                {
                    if (hasCountryCode && countryCodeValid)
                    {
                        writer.WriteString(item.SupplierNumber.ToString().Remove(0, 2));
                    }
                    else
                    {
                        writer.WriteString(item.SupplierNumber.ToString());
                    }
                }
                
                writer.WriteEndElement();

                writer.WriteStartElement(elementPrefix + "NazwaDostawcy");
                writer.WriteString(item.SupplierName.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement(elementPrefix + "DowodZakupu");
                writer.WriteString(item.PurchaseProof.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement(elementPrefix + "DataZakupu");
                writer.WriteString(item.PurchaseDate.ToString(dateFormat));
                writer.WriteEndElement();
                writer.WriteStartElement(elementPrefix + "DataWplywu");
                writer.WriteString(item.ReceiptDate.ToString(dateFormat));
                writer.WriteEndElement();
                if (item.PurchaseDocument.ToString() != "")
                {
                    writer.WriteStartElement(elementPrefix + "DokumentZakupu");
                    writer.WriteString(item.PurchaseDocument.ToString());
                    writer.WriteEndElement();
                }
                if (item.MPP && (FeatureActiveRS9249 != 1 || Convert.ToInt32(formVariant) != 2))
                {
                    writer.WriteStartElement(elementPrefix + "MPP");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }
                if (item.IMP)
                {
                    writer.WriteStartElement(elementPrefix + "IMP");
                    writer.WriteString("1");
                    writer.WriteEndElement();
                }

                ValidateTagsAmount(ref writer, "K_40", item.K40, true);
                ValidateTagsAmount(ref writer, "K_41", item.K41, true);
                ValidateTagsAmount(ref writer, "K_42", item.K42, true);
                ValidateTagsAmount(ref writer, "K_43", item.K43, true);
                ValidateTagsAmount(ref writer, "K_44", item.K44, true);
                ValidateTagsAmount(ref writer, "K_45", item.K45, true);
                ValidateTagsAmount(ref writer, "K_46", item.K46, true);
                ValidateTagsAmount(ref writer, "K_47", item.K47, true);

                writer.WriteEndElement();
            }

        }
        private void WritePurchaseControl(ref IXmlTextWriterUtil writer, IJPKV7MPurchaseControl purchaseControl)
        {
            writer.WriteStartElement(elementPrefix + "ZakupCtrl");

            writer.WriteStartElement(elementPrefix + "LiczbaWierszyZakupow");
            writer.WriteString(purchaseControl.PurchaseCount.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement(elementPrefix + "PodatekNaliczony");
            writer.WriteString(purchaseControl.InputTax.ToString(amountFormat, CultureInfo.InvariantCulture));
            writer.WriteEndElement();

            writer.WriteEndElement();
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
