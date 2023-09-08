using PLLOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Objects
{
    public class JPK7MSalesRegisterFactory : IJPK7MSalesRegisterFactory
    {
        public IJPK7MSalesRegister Create(string salesNumber, string countryOriginCodeTIN, string counterPartyNo, string contractorsName, string salesEvidence, DateTime? issueDate, DateTime? salesDate, string documentType, bool gTU1, bool gTU2, bool gTU3, bool gTU4, bool gTU5, bool gTU6, bool gTU7, bool gTU8, bool gTU9, bool gTU10, bool gTU11, bool gTU12, bool gTU13, bool wSTO_EE, bool iED, bool sW, bool eE, bool tP, bool tTWNT, bool tTD, bool mRT, bool mRUZ, bool i42, bool i63, bool bSPV, bool bSPVDOSTAWA, bool bMPVPROWIZJA, bool mPP, bool baseCorrection, decimal k10, decimal k11, decimal k12, decimal k13, decimal k14, decimal k15, decimal k16, decimal k17, decimal k18, decimal k19, decimal k20, decimal k21, decimal k22, decimal k23, decimal k24, decimal k25, decimal k26, decimal k27, decimal k28, decimal k29, decimal k30, decimal k31, decimal k32, decimal k33, decimal k34, decimal k35, decimal k36, DateTime? dueDate)
        {
            return new JPK7MSalesRegister(salesNumber, countryOriginCodeTIN, counterPartyNo, contractorsName, salesEvidence, issueDate, salesDate, documentType, gTU1, gTU2, gTU3, gTU4, gTU5, gTU6, gTU7, gTU8, gTU9, gTU10, gTU11, gTU12, gTU13, wSTO_EE, iED, sW, eE, tP, tTWNT, tTD, mRT, mRUZ, i42, i63, bSPV, bSPVDOSTAWA, bMPVPROWIZJA, mPP, baseCorrection, k10, k11, k12, k13, k14, k15, k16, k17, k18, k19, k20, k21, k22, k23, k24, k25, k26, k27, k28, k29, k30, k31, k32, k33, k34, k35, k36, dueDate);
        }
    }
}
