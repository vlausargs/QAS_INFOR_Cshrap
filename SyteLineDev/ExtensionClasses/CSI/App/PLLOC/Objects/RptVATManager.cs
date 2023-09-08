using System;
using System.Collections.Generic;
using System.Text;
using PLLOC.Interfaces;

namespace PLLOC.Objects
{
    public class RptVATManager : IRptVATManager
    {
        readonly IRptVAT rptVAT;
        readonly IJPKV7MPurchaseRegisterFactory jPKV7MPurchaseRegisterFactory;
        readonly IJPK7MSalesRegisterFactory jPK7MSalesRegisterFactory;
        readonly IJPKV7MPurchaseControlFactory jPKV7MPurchaseControlFactory;
        readonly IJPKV7MSalesControlFactory jPKV7MSalesControlFactory;
        bool isPopulatedJPKV7MPurchaseRegister = false;
        bool isPopulatedJPK7MSalesRegister = false;
        bool isPopulatedJPKV7MSalesControl = false;
        bool isPopulatedJPKV7MPurchaseControl = false;

        bool IRptVATManager.IsPopulatedJPKV7MPurchaseRegister => this.isPopulatedJPKV7MPurchaseRegister;
        bool IRptVATManager.IsPopulatedJPK7MSalesRegister => this.isPopulatedJPK7MSalesRegister;

        bool IRptVATManager.IsPopulatedJPKV7MPurchaseControl => this.isPopulatedJPKV7MPurchaseControl;

        bool IRptVATManager.IsPopulatedJPKV7MSalesControl => this.isPopulatedJPKV7MSalesControl;

        public RptVATManager(IRptVAT rptVAT, IJPKV7MPurchaseRegisterFactory jPKV7MPurchaseRegisterFactory, IJPK7MSalesRegisterFactory jPK7MSalesRegisterFactory, IJPKV7MPurchaseControlFactory jPKV7MPurchaseControlFactory, IJPKV7MSalesControlFactory jPKV7MSalesControlFactory)
        {
            this.rptVAT = rptVAT;
            this.jPKV7MPurchaseRegisterFactory = jPKV7MPurchaseRegisterFactory;
            this.jPK7MSalesRegisterFactory = jPK7MSalesRegisterFactory;
            this.jPKV7MPurchaseControlFactory = jPKV7MPurchaseControlFactory;
            this.jPKV7MSalesControlFactory = jPKV7MSalesControlFactory;
        }

        void IRptVATManager.AddJPKV7MPurchaseRegister(IJPKV7MPurchaseRegister _jPKV7MPurchaseRegister)
        {
            rptVAT.JPKV7MPurchaseRegisters.Add(_jPKV7MPurchaseRegister);
            isPopulatedJPKV7MPurchaseRegister = true;
        }
        IList<IJPKV7MPurchaseRegister> IRptVATManager.GetJPKV7MPurchaseRegister()
        {
            return rptVAT.JPKV7MPurchaseRegisters;
        }

        void IRptVATManager.SetJPKV7MSalesControl(IJPKV7MSalesControl jPKV7MSalesControl)
        {
            rptVAT.JPKV7MSalesControl = jPKV7MSalesControl;
            isPopulatedJPKV7MSalesControl = true;
        }

        IJPKV7MSalesControl IRptVATManager.GetJPKV7MSalesControl()
        {
            return rptVAT.JPKV7MSalesControl;
        }

        void IRptVATManager.AddJPK7MSalesRegister(IJPK7MSalesRegister jPK7MSalesRegister)
        {
            rptVAT.JPK7MSalesRegisters.Add(jPK7MSalesRegister);
            isPopulatedJPK7MSalesRegister = true;
        }

        IList<IJPK7MSalesRegister> IRptVATManager.GetJPK7MSalesRegister()
        {
            return rptVAT.JPK7MSalesRegisters;
        }

        void IRptVATManager.SetJPKV7MPurchaseControl(IJPKV7MPurchaseControl jPKV7MPurchaseControl)
        {
            rptVAT.JPKV7MPurchaseControl = jPKV7MPurchaseControl;
            isPopulatedJPKV7MPurchaseControl = true;
        }

        IJPKV7MPurchaseControl IRptVATManager.GetJPKV7MPurchaseControl()
        {
            return rptVAT.JPKV7MPurchaseControl;
        }

        IJPKV7MPurchaseRegister IRptVATManager.CreateJPKV7MPurchaseRegister(string countryOriginCodeTIN, bool iMP, decimal k40, decimal k41, decimal k42, decimal k43, decimal k44, decimal k45, decimal k46, decimal k47, bool mPP, DateTime purchaseDate, string purchaseDocument, string purchaseNumber, string purchaseProof, DateTime receiptDate, string supplierName, string supplierNumber)
        {
            return jPKV7MPurchaseRegisterFactory.Create(countryOriginCodeTIN, iMP, k40, k41, k42, k43, k44, k45, k46, k47, mPP, purchaseDate, purchaseDocument, purchaseNumber, purchaseProof, receiptDate, supplierName, supplierNumber);
        }

        IJPK7MSalesRegister IRptVATManager.CreateJPK7MSalesRegister(string salesNumber, string countryOriginCodeTIN, string counterPartyNo, string contractorsName, string salesEvidence, DateTime? issueDate, DateTime? salesDate, string documentType, bool gTU1, bool gTU2, bool gTU3, bool gTU4, bool gTU5, bool gTU6, bool gTU7, bool gTU8, bool gTU9, bool gTU10, bool gTU11, bool gTU12, bool gTU13, bool wSTO_EE, bool iED, bool sW, bool eE, bool tP, bool tTWNT, bool tTD, bool mRT, bool mRUZ, bool i42, bool i63, bool bSPV, bool bSPVDOSTAWA, bool bMPVPROWIZJA, bool mPP, bool baseCorrection, decimal k10, decimal k11, decimal k12, decimal k13, decimal k14, decimal k15, decimal k16, decimal k17, decimal k18, decimal k19, decimal k20, decimal k21, decimal k22, decimal k23, decimal k24, decimal k25, decimal k26, decimal k27, decimal k28, decimal k29, decimal k30, decimal k31, decimal k32, decimal k33, decimal k34, decimal k35, decimal k36, DateTime? dueDate)
        {
            return jPK7MSalesRegisterFactory.Create(salesNumber, countryOriginCodeTIN, counterPartyNo, contractorsName, salesEvidence, issueDate, salesDate, documentType, gTU1, gTU2, gTU3, gTU4, gTU5, gTU6, gTU7, gTU8, gTU9, gTU10, gTU11, gTU12, gTU13, wSTO_EE, iED, sW, eE, tP, tTWNT, tTD, mRT, mRUZ, i42, i63, bSPV, bSPVDOSTAWA, bMPVPROWIZJA, mPP, baseCorrection, k10, k11, k12, k13, k14, k15, k16, k17, k18, k19, k20, k21, k22, k23, k24, k25, k26, k27, k28, k29, k30, k31, k32, k33, k34, k35, k36, dueDate);
        }

        IJPKV7MPurchaseControl IRptVATManager.CreateJPKV7MPurchaseControl(int purchaseCount, decimal inputTax)
        {
            return jPKV7MPurchaseControlFactory.Create(purchaseCount, inputTax);
        }

        IJPKV7MSalesControl IRptVATManager.CreateJPKV7MSalesControl(int salesCount, decimal taxDues)
        {
            return jPKV7MSalesControlFactory.Create(salesCount, taxDues);
        }
    }
}
