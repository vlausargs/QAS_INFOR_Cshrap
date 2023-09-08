using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IJPK7MSalesRegisterFactory
    {
        IJPK7MSalesRegister Create(string salesNumber = null, string countryOriginCodeTIN = null, string counterPartyNo = null, string contractorsName = null, string salesEvidence = null, DateTime? issueDate = null, DateTime? salesDate = null, string documentType = null, bool gTU1 = false, bool gTU2 = false, bool gTU3 = false, bool gTU4 = false, bool gTU5 = false, bool gTU6 = false, bool gTU7 = false, bool gTU8 = false, bool gTU9 = false, bool gTU10 = false, bool gTU11 = false, bool gTU12 = false, bool gTU13 = false, bool wSTO_EE = false, bool iED = false, bool sW = false, bool eE = false, bool tP = false, bool tTWNT = false, bool tTD = false, bool mRT = false, bool mRUZ = false, bool i42 = false, bool i63 = false, bool bSPV = false, bool bSPVDOSTAWA = false, bool bMPVPROWIZJA = false, bool mPP = false, bool baseCorrection = false, decimal k10 = 0, decimal k11 = 0, decimal k12 = 0, decimal k13 = 0, decimal k14 = 0, decimal k15 = 0, decimal k16 = 0, decimal k17 = 0, decimal k18 = 0, decimal k19 = 0, decimal k20 = 0, decimal k21 = 0, decimal k22 = 0, decimal k23 = 0, decimal k24 = 0, decimal k25 = 0, decimal k26 = 0, decimal k27 = 0, decimal k28 = 0, decimal k29 = 0, decimal k30 = 0, decimal k31 = 0, decimal k32 = 0, decimal k33 = 0, decimal k34 = 0, decimal k35 = 0, decimal k36 = 0, DateTime? dueDate = null);
    }
}
