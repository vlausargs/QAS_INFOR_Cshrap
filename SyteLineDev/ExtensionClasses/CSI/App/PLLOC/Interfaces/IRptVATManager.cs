using PLLOC.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IRptVATManager
    {
        void AddJPKV7MPurchaseRegister(IJPKV7MPurchaseRegister _jPKV7MPurchaseRegister);
        IList<IJPKV7MPurchaseRegister> GetJPKV7MPurchaseRegister();
        void SetJPKV7MSalesControl(IJPKV7MSalesControl jPKV7MSalesControl);
        IJPKV7MSalesControl GetJPKV7MSalesControl();
        void AddJPK7MSalesRegister(IJPK7MSalesRegister jPK7MSalesRegister);
        IList<IJPK7MSalesRegister> GetJPK7MSalesRegister();
        void SetJPKV7MPurchaseControl(IJPKV7MPurchaseControl jPKV7MPurchaseControl);
        IJPKV7MPurchaseControl GetJPKV7MPurchaseControl();
        IJPKV7MPurchaseRegister CreateJPKV7MPurchaseRegister(string countryOriginCodeTIN, bool iMP, decimal k40, decimal k41, decimal k42, decimal k43, decimal k44, decimal k45, decimal k46, decimal k47, bool mPP, DateTime purchaseDate, string purchaseDocument, string purchaseNumber, string purchaseProof, DateTime receiptDate, string supplierName, string supplierNumber);
        IJPK7MSalesRegister CreateJPK7MSalesRegister(string salesNumber, string countryOriginCodeTIN, string counterPartyNo, string contractorsName, string salesEvidence, DateTime? issueDate, DateTime? salesDate, string documentType, bool gTU1, bool gTU2, bool gTU3, bool gTU4, bool gTU5, bool gTU6, bool gTU7, bool gTU8, bool gTU9, bool gTU10, bool gTU11, bool gTU12, bool gTU13, bool wSTO_EE, bool iED, bool sW, bool eE, bool tP, bool tTWNT, bool tTD, bool mRT, bool mRUZ, bool i42, bool i63, bool bSPV, bool bSPVDOSTAWA, bool bMPVPROWIZJA, bool mPP, bool baseCorrection, decimal k10, decimal k11, decimal k12, decimal k13, decimal k14, decimal k15, decimal k16, decimal k17, decimal k18, decimal k19, decimal k20, decimal k21, decimal k22, decimal k23, decimal k24, decimal k25, decimal k26, decimal k27, decimal k28, decimal k29, decimal k30, decimal k31, decimal k32, decimal k33, decimal k34, decimal k35, decimal k36, DateTime? dueDate);
        IJPKV7MPurchaseControl CreateJPKV7MPurchaseControl(int purchaseCount = 0, decimal inputTax = 0);
        IJPKV7MSalesControl CreateJPKV7MSalesControl(int salesCount = 0, decimal taxDues = 0);

        bool IsPopulatedJPKV7MPurchaseRegister { get; }
        bool IsPopulatedJPK7MSalesRegister { get; }
        bool IsPopulatedJPKV7MPurchaseControl { get; }
        bool IsPopulatedJPKV7MSalesControl { get; }
    }
}
