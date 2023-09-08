using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IJPKV7MPurchaseRegister
    {
        string CountryOriginCodeTIN { get; }
        bool IMP { get; }
        decimal K40 { get; }
        decimal K41 { get; }
        decimal K42 { get; }
        decimal K43 { get; }
        decimal K44 { get; }
        decimal K45 { get; }
        decimal K46 { get; }
        decimal K47 { get; }
        bool MPP { get; }
        DateTime PurchaseDate { get; }
        string PurchaseDocument { get; }
        string PurchaseNumber { get; }
        string PurchaseProof { get; }
        DateTime ReceiptDate { get; }
        string SupplierName { get; }
        string SupplierNumber { get; }
    }
}
