//PROJECT NAME: Logistics
//CLASS NAME: IGenerateVATFile.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IGenerateVATFile
    {
        (int? ReturnCode,
        string VATExportLogicalFolder,
        string FileName,
        string FileContent,
        string Infobar) GenerateVATFileSp(
            string InvoiceList,
            string FileType,
            string pLanguage,
            string VATExportLogicalFolder = null,
            string FileName = null,
            string FileContent = null,
            string Infobar = null);
    }
}
