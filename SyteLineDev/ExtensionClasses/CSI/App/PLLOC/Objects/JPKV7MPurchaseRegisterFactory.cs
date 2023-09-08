using PLLOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Objects
{
    public class JPKV7MPurchaseRegisterFactory : IJPKV7MPurchaseRegisterFactory
    {
        public IJPKV7MPurchaseRegister Create(string countryOriginCodeTIN, bool iMP, decimal k40, decimal k41, decimal k42, decimal k43, decimal k44, decimal k45, decimal k46, decimal k47, bool mPP, DateTime purchaseDate, string purchaseDocument, string purchaseNumber, string purchaseProof, DateTime receiptDate, string supplierName, string supplierNumber)
        {
            return new JPKV7MPurchaseRegister(countryOriginCodeTIN, iMP,  k40,  k41,  k42,  k43,  k44,  k45,  k46,  k47,  mPP,  purchaseDate,  purchaseDocument,  purchaseNumber,  purchaseProof,  receiptDate,  supplierName,  supplierNumber);
        }
    }
}
