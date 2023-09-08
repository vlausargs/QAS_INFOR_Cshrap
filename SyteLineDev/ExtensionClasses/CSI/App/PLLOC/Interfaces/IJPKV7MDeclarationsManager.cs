using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IJPKV7MDeclarationsManager
    {
        IJPKV7MDeclarations Process(DateTime BeginTaxDate, DateTime EndTaxDate, byte? TaxJurTaxSystem = null, byte? ExOptszShowDetail = null, string TaxJurTaxJur = null, short? TaxDateStartingOffset = null, short? TaxDateEndingOffset = null, string ExOptgoJournalId = null, byte? DisplayHeader = null, string BGSessionId = null, int? TaskId = null, string pSite = null, string BGUser = null, string SortBy = null, byte? ExcludeNullLineNum = 0, byte? ExcludeJournalEntries = 0, string PLVATFormVariant = null, string Confirmation = null, decimal P39 = 0, decimal P49 = 0, decimal P50 = 0, decimal P52 = 0, decimal P54 = 0,
                 byte P540 = (byte)0, byte P55 = (byte)0, byte P56 = (byte)0, byte P560 = (byte)0, byte P57 = (byte)0, byte P58 = (byte)0, byte P59 = (byte)0, decimal P60 = 0, string P61 = null, byte P63 = (byte)0,
                 byte P64 = (byte)0, byte P65 = (byte)0, byte P66 = (byte)0, byte P660 = (byte)0, byte P67 = (byte)0, decimal P68 = 0, decimal P69 = 0, string PORDZU = null);
        IJPKV7MDeclarations Process(string Confirmation = null, decimal P39 = 0, decimal P49 = 0, decimal P50 = 0, decimal P52 = 0, decimal P54 = 0, byte P540 = (byte)0, byte P55 = (byte)0, byte P56 = (byte)0, byte P560 = (byte)0, byte P57 = (byte)0, byte P58 = (byte)0, byte P59 = (byte)0, decimal P60 = 0, string P61 = null, byte P63 = (byte)0, byte P64 = (byte)0, byte P65 = (byte)0, byte P66 = (byte)0, byte P660 = (byte)0, byte P67 = (byte)0, decimal P68 = 0, decimal P69 = 0, string PORDZU = null
            , string declarationCommitmentType = "", string declarationFormCode = "", string declarationSchemaVersion = "", string declarationSystemCode = "", string declarationTaxCode = "", string variantDeclarationForm = "", string pLVATFormVariant = "");
    }
}
