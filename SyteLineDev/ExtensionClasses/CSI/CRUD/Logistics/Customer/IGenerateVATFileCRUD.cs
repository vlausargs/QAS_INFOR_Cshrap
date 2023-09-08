//PROJECT NAME: Logistics
//CLASS NAME: IGenerateVATFile.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IGenerateVATFileCRUD
    {
        (int? ReturnCode, string VATExportLogicalFolder, string FileName, string FileContent, string Infobar) AltExtGen_GenerateVATFileSp(string AltExtGenSp, string InvoiceList, string FileType, string pLanguage, string VATExportLogicalFolder = null, string FileName = null, string FileContent = null, string Infobar = null);
        ICollectionLoadResponse Arinv1Select(string InvNum);
        void Arinv1Update(ICollectionLoadResponse arinv1LoadResponse);
        ICollectionLoadResponse ArinvSelect(string InvNum, int? TaxSystem, string TaxMode);
        string BANK_HdrasbhLoad();
        string CoparmsLoad();
        void InvoiceInsert(ICollectionLoadResponse InvoiceLoadResponse);
        ICollectionLoadResponse InvoiceSelect(string InvoiceList);
        int? Inv_ItemLoad(string InvNum);
        string LanguageidsLoad(string pLanguage);
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        ICollectionLoadResponse Optional_Module1Select();
        bool Optional_ModuleForExists();
        (int? TaxSystem, string TaxMode) Tax_System1Load();
        (int? TaxSystem, string TaxMode) Tax_SystemLoad();
        string Tv_ALTGEN1Load();
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        bool Tv_ALTGENForExists();
        ICollectionLoadResponse Tv_Invoice1Select();
        bool Tv_Invoice2ForExists(string FileType);
        ICollectionLoadResponse Tv_Invoiceasinv1Select(int? TaxSystem);
        bool Tv_InvoiceForExists(string FileType);
    }
}