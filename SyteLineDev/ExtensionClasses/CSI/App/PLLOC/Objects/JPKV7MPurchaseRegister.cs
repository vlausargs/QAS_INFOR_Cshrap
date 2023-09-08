using System;
using System.Collections.Generic;
using System.Text;
using PLLOC.Interfaces;

namespace PLLOC.Objects
{
    public class JPKV7MPurchaseRegister : IJPKV7MPurchaseRegister
    {
        public JPKV7MPurchaseRegister(string countryOriginCodeTIN, bool iMP, decimal k40, decimal k41, decimal k42, decimal k43, decimal k44, decimal k45, decimal k46, decimal k47, bool mPP, DateTime purchaseDate, string purchaseDocument, string purchaseNumber, string purchaseProof, DateTime receiptDate, string supplierName, string supplierNumber)
        {
            CountryOriginCodeTIN = countryOriginCodeTIN ?? throw new ArgumentNullException(nameof(countryOriginCodeTIN));
            IMP = iMP;
            K40 = k40;
            K41 = k41;
            K42 = k42;
            K43 = k43;
            K44 = k44;
            K45 = k45;
            K46 = k46;
            K47 = k47;
            MPP = mPP;
            PurchaseDate = purchaseDate;
            PurchaseDocument = purchaseDocument ?? throw new ArgumentNullException(nameof(purchaseDocument));
            PurchaseNumber = purchaseNumber ?? throw new ArgumentNullException(nameof(purchaseNumber));
            PurchaseProof = purchaseProof ?? throw new ArgumentNullException(nameof(purchaseProof));
            ReceiptDate = receiptDate;
            SupplierName = supplierName ?? throw new ArgumentNullException(nameof(supplierName));
            SupplierNumber = supplierNumber ?? throw new ArgumentNullException(nameof(supplierNumber));
        }

        public string CountryOriginCodeTIN { get; }
        public bool IMP { get; }
        public decimal K40 { get; }
        public decimal K41 { get; }
        public decimal K42 { get; }
        public decimal K43 { get; }
        public decimal K44 { get; }
        public decimal K45 { get; }
        public decimal K46 { get; }
        public decimal K47 { get; }
        public bool MPP { get; }
        public DateTime PurchaseDate { get; }
        public string PurchaseDocument { get; }
        public string PurchaseNumber { get; }
        public string PurchaseProof { get; }
        public DateTime ReceiptDate { get; }
        public string SupplierName { get; }
        public string SupplierNumber { get; }
    }
}
