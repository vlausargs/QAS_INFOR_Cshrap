using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IJPKV7MPurchaseRegisterFactory
    {
        IJPKV7MPurchaseRegister Create(string countryOriginCodeTIN, bool iMP, decimal k40, decimal k41, decimal k42, decimal k43, decimal k44, decimal k45, decimal k46, decimal k47, bool mPP, DateTime purchaseDate, string purchaseDocument, string purchaseNumber, string purchaseProof, DateTime receiptDate, string supplierName, string supplierNumber);
    }
}
