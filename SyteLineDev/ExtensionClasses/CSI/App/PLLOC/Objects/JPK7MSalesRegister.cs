using PLLOC.Interfaces;
using System;
using System.Collections.Generic;

namespace PLLOC.Objects
{
    public class JPK7MSalesRegister : IJPK7MSalesRegister
    {
        public JPK7MSalesRegister(string salesNumber, string countryOriginCodeTIN, string counterPartyNo, string contractorsName, string salesEvidence, DateTime? issueDate, DateTime? salesDate, string documentType, bool gTU1, bool gTU2, bool gTU3, bool gTU4, bool gTU5, bool gTU6, bool gTU7, bool gTU8, bool gTU9, bool gTU10, bool gTU11, bool gTU12, bool gTU13, bool wSTO_EE, bool iED, bool sW, bool eE, bool tP, bool tTWNT, bool tTD, bool mRT, bool mRUZ, bool i42, bool i63, bool bSPV, bool bSPVDOSTAWA, bool bMPVPROWIZJA, bool mPP, bool baseCorrection, decimal k10, decimal k11, decimal k12, decimal k13, decimal k14, decimal k15, decimal k16, decimal k17, decimal k18, decimal k19, decimal k20, decimal k21, decimal k22, decimal k23, decimal k24, decimal k25, decimal k26, decimal k27, decimal k28, decimal k29, decimal k30, decimal k31, decimal k32, decimal k33, decimal k34, decimal k35, decimal k36, DateTime? dueDate)
        {
            SalesNumber = salesNumber;
            CountryOriginCodeTIN = countryOriginCodeTIN;
            CounterPartyNo = counterPartyNo;
            ContractorsName = contractorsName;
            SalesEvidence = salesEvidence;
            IssueDate = issueDate;
            SalesDate = salesDate;
            DocumentType = documentType;
            GTU1 = gTU1;
            GTU2 = gTU2;
            GTU3 = gTU3;
            GTU4 = gTU4;
            GTU5 = gTU5;
            GTU6 = gTU6;
            GTU7 = gTU7;
            GTU8 = gTU8;
            GTU9 = gTU9;
            GTU10 = gTU10;
            GTU11 = gTU11;
            GTU12 = gTU12;
            GTU13 = gTU13;
            WSTO_EE = wSTO_EE;
            IED = iED;
            SW = sW;
            EE = eE;
            TP = tP;
            TTWNT = tTWNT;
            TTD = tTD;
            MRT = mRT;
            MRUZ = mRUZ;
            I42 = i42;
            I63 = i63;
            BSPV = bSPV;
            BSPVDOSTAWA = bSPVDOSTAWA;
            BMPVPROWIZJA = bMPVPROWIZJA;
            MPP = mPP;
            BaseCorrection = baseCorrection;
            K10 = k10;
            K11 = k11;
            K12 = k12;
            K13 = k13;
            K14 = k14;
            K15 = k15;
            K16 = k16;
            K17 = k17;
            K18 = k18;
            K19 = k19;
            K20 = k20;
            K21 = k21;
            K22 = k22;
            K23 = k23;
            K24 = k24;
            K25 = k25;
            K26 = k26;
            K27 = k27;
            K28 = k28;
            K29 = k29;
            K30 = k30;
            K31 = k31;
            K32 = k32;
            K33 = k33;
            K34 = k34;
            K35 = k35;
            K36 = k36;
            DueDate = dueDate;
        }

        public string SalesNumber { get; }
        public string CountryOriginCodeTIN { get; }
        public string CounterPartyNo { get; }
        public string ContractorsName { get; }
        public string SalesEvidence { get; }
        public DateTime? IssueDate { get; }
        public DateTime? SalesDate { get; }
        public string DocumentType { get; }
        public bool GTU1 { get; }
        public bool GTU2 { get; }
        public bool GTU3 { get; }
        public bool GTU4 { get; }
        public bool GTU5 { get; }
        public bool GTU6 { get; }
        public bool GTU7 { get; }
        public bool GTU8 { get; }
        public bool GTU9 { get; }
        public bool GTU10 { get; }
        public bool GTU11 { get; }
        public bool GTU12 { get; }
        public bool GTU13 { get; }
        public bool WSTO_EE { get; }
        public bool IED { get; }
        public bool SW { get; }
        public bool EE { get; }
        public bool TP { get; }
        public bool TTWNT { get; }
        public bool TTD { get; }
        public bool MRT { get; }
        public bool MRUZ { get; }
        public bool I42 { get; }
        public bool I63 { get; }
        public bool BSPV { get; }
        public bool BSPVDOSTAWA { get; }
        public bool BMPVPROWIZJA { get; }
        public bool MPP { get; }
        public bool BaseCorrection { get; }
        public decimal K10 { get; }
        public decimal K11 { get; }
        public decimal K12 { get; }
        public decimal K13 { get; }
        public decimal K14 { get; }
        public decimal K15 { get; }
        public decimal K16 { get; }
        public decimal K17 { get; }
        public decimal K18 { get; }
        public decimal K19 { get; }
        public decimal K20 { get; }
        public decimal K21 { get; }
        public decimal K22 { get; }
        public decimal K23 { get; }
        public decimal K24 { get; }
        public decimal K25 { get; }
        public decimal K26 { get; }
        public decimal K27 { get; }
        public decimal K28 { get; }
        public decimal K29 { get; }
        public decimal K30 { get; }
        public decimal K31 { get; }
        public decimal K32 { get; }
        public decimal K33 { get; }
        public decimal K34 { get; }
        public decimal K35 { get; }
        public decimal K36 { get; }
        public DateTime? DueDate { get; }

    }
}