using Mongoose.IDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.PLLOC;
using Mongoose.IDO.Protocol;
using CSI.MG;
using CSI.Data.SQL;
using Microsoft.Extensions.DependencyInjection;
using PLLOC.Interfaces;

namespace CSI.MG.PLLOC
{
    [IDOExtensionClass("PLVATDeclarations")]
    public class PLVATDeclarations : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int? GeneratePLJPKV7MXML(ref string Infobar,
                    DateTime BeginTaxDate,
                    DateTime EndTaxDate,
                    string LogicalFolder,
                    string Filename,
                    string SubmissionMode,
                    string Confirmation,
                    decimal VATDeclarationP39,
                    decimal VATDeclarationP49,
                    decimal VATDeclarationP50,
                    decimal VATDeclarationP52,
                    decimal VATDeclarationP54,
                    byte VATDeclarationP540,
                    byte VATDeclarationP55,
                    byte VATDeclarationP56,
                    byte VATDeclarationP560,
                    byte VATDeclarationP57,
                    byte VATDeclarationP58,
                    byte VATDeclarationP59,
                    decimal VATDeclarationP60,
                    string VATDeclarationP61,
                    byte VATDeclarationP63,
                    byte VATDeclarationP64,
                    byte VATDeclarationP65,
                    byte VATDeclarationP66,
                    byte VATDeclarationP660,
                    byte VATDeclarationP67,
                    decimal VATDeclarationP68,
                    decimal VATDeclarationP69,
                    string VATDeclarationJustification,
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
                    string TaxRegNum = null,
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
                    byte? ExcludeJournalEntries = (byte)0
            )
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var iGeneratePLJPKV7MXML = this.GetService<IGeneratePLJPKV7MXML>();

                var result = iGeneratePLJPKV7MXML.Process(Infobar, 
                    BeginTaxDate,
                    EndTaxDate,
                    LogicalFolder, 
                    Filename,
                    SubmissionMode,
                    Confirmation,
                    VATDeclarationP39,
                    VATDeclarationP49,
                    VATDeclarationP50,
                    VATDeclarationP52,
                    VATDeclarationP54,
                    VATDeclarationP540,
                    VATDeclarationP55,
                    VATDeclarationP56,
                    VATDeclarationP560,
                    VATDeclarationP57,
                    VATDeclarationP58,
                    VATDeclarationP59,
                    VATDeclarationP60,
                    VATDeclarationP61,
                    VATDeclarationP63,
                    VATDeclarationP64,
                    VATDeclarationP65,
                    VATDeclarationP66,
                    VATDeclarationP660,
                    VATDeclarationP67,
                    VATDeclarationP68,
                    VATDeclarationP69,
                    VATDeclarationJustification,
                    PLVATSystemCode,
                    PLVATStructureVersion,
                    PLVATFormVariant,
                    PLVATOfficeCode,
                    PLVATDeclarationCode,
                    PLVATDeclarationSystem,
                    PLVATDeclarationTaxCode,
                    PLVATDeclarationCommitment,
                    PLVATDeclarationSchemaVersion,
                    PLVATDeclarationVariant,
                    PLVATPhone,
                    PLVATEmailAddr,
                    TaxJurTaxSystem,
                    ExOptszShowDetail,
                    TaxJurTaxJur,
                    TaxDateStartingOffset,
                    TaxDateEndingOffset,
                    ExOptgoJournalId,
                    DisplayHeader,
                    BGSessionId,
                    TaskId,
                    pSite,
                    BGUser,
                    SortBy,
                    ExcludenullLineNum,
                    ExcludeJournalEntries,
                    TaxRegNum);
                Infobar = result.Infobar; 
                return result.Severity;
            }
        }

        [IDOMethod(MethodFlags.None)]
        public void GetPLVATPDeclarationValues(DateTime BeginTaxDate, DateTime EndTaxDate, ref decimal? P10, ref decimal? P11,
             ref decimal? P12, ref decimal? P13, ref decimal? P14, ref decimal? P15, ref decimal? P16, ref decimal? P17, ref decimal? P18,
             ref decimal? P19, ref decimal? P20, ref decimal? P21, ref decimal? P22, ref decimal? P23, ref decimal? P24, ref decimal? P25,
             ref decimal? P26, ref decimal? P27, ref decimal? P28, ref decimal? P29, ref decimal? P30, ref decimal? P31, ref decimal? P32,
             ref decimal? P33, ref decimal? P34, ref decimal? P35, ref decimal? P36, ref decimal? P37, ref decimal? P38, ref decimal? P40,
             ref decimal? P41, ref decimal? P42, ref decimal? P43, ref decimal? P44, ref decimal? P45, ref decimal? P46, ref decimal? P47,
             ref decimal? P48, ref decimal? P51, ref decimal? P53, ref decimal? P62, byte? TaxJurTaxSystem, byte? ExOptszShowDetail,
             string TaxJurTaxJur, short? TaxDateStartingOffset, short? TaxDateEndingOffset, string ExOptgoJournalId, byte? DisplayHeader, string BGSessionId, int? TaskId, string pSite,
             string BGUser, string SortBy, byte? ExcludeNullLineNum, byte? ExcludeJournalEntries, string PLVATFormVariant)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var iGetJPKVATPDeclarationValues = this.GetService<IJPKV7MDeclarationsManager>();

                var jPKV7MDeclarations = iGetJPKVATPDeclarationValues.Process(BeginTaxDate, EndTaxDate, TaxJurTaxSystem,
                    ExOptszShowDetail,
                    TaxJurTaxJur,
                    TaxDateEndingOffset,
                    TaxDateEndingOffset,
                    ExOptgoJournalId,
                    DisplayHeader,
                    BGSessionId,
                    TaskId,
                    pSite,
                    BGUser,
                    SortBy,
                    ExcludeNullLineNum,
                    ExcludeJournalEntries,
                    PLVATFormVariant);

                P10 = jPKV7MDeclarations.P10; P11 = jPKV7MDeclarations.P11;
                P12 = jPKV7MDeclarations.P12; P13 = jPKV7MDeclarations.P13;
                P14 = jPKV7MDeclarations.P14; P15 = jPKV7MDeclarations.P15;
                P16 = jPKV7MDeclarations.P16; P17 = jPKV7MDeclarations.P17;
                P18 = jPKV7MDeclarations.P18; P19 = jPKV7MDeclarations.P19;
                P20 = jPKV7MDeclarations.P20; P21 = jPKV7MDeclarations.P21;
                P22 = jPKV7MDeclarations.P22; P23 = jPKV7MDeclarations.P23;
                P24 = jPKV7MDeclarations.P24; P25 = jPKV7MDeclarations.P25;
                P26 = jPKV7MDeclarations.P26; P27 = jPKV7MDeclarations.P27;
                P28 = jPKV7MDeclarations.P28; P29 = jPKV7MDeclarations.P29;
                P30 = jPKV7MDeclarations.P30; P31 = jPKV7MDeclarations.P31;
                P32 = jPKV7MDeclarations.P32; P33 = jPKV7MDeclarations.P33;
                P34 = jPKV7MDeclarations.P34; P35 = jPKV7MDeclarations.P35;
                P36 = jPKV7MDeclarations.P36; P37 = jPKV7MDeclarations.P37;
                P38 = jPKV7MDeclarations.P38; P40 = jPKV7MDeclarations.P40;
                P41 = jPKV7MDeclarations.P41; P42 = jPKV7MDeclarations.P42;
                P43 = jPKV7MDeclarations.P43; P44 = jPKV7MDeclarations.P44;
                P45 = jPKV7MDeclarations.P45; P46 = jPKV7MDeclarations.P46;
                P47 = jPKV7MDeclarations.P47; P48 = jPKV7MDeclarations.P48;
                P51 = jPKV7MDeclarations.P51; P53 = jPKV7MDeclarations.P53;
                P62 = jPKV7MDeclarations.P62;
            }
        }
    }
}
