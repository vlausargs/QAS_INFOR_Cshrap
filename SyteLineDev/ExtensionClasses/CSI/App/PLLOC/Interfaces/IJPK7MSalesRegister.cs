using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IJPK7MSalesRegister
    {
        bool BaseCorrection { get; }
        bool BMPVPROWIZJA { get; }
        bool BSPV { get; }
        bool BSPVDOSTAWA { get; }
        string ContractorsName { get; }
        string CounterPartyNo { get; }
        string CountryOriginCodeTIN { get; }
        string DocumentType { get; }
        bool EE { get; }
        bool GTU1 { get; }
        bool GTU10 { get; }
        bool GTU11 { get; }
        bool GTU12 { get; }
        bool GTU13 { get; }
        bool GTU2 { get; }
        bool GTU3 { get; }
        bool GTU4 { get; }
        bool GTU5 { get; }
        bool GTU6 { get; }
        bool GTU7 { get; }
        bool GTU8 { get; }
        bool GTU9 { get; }
        bool I42 { get; }
        bool I63 { get; }
        DateTime? IssueDate { get; }
        decimal K10 { get; }
        decimal K11 { get; }
        decimal K12 { get; }
        decimal K13 { get; }
        decimal K14 { get; }
        decimal K15 { get; }
        decimal K16 { get; }
        decimal K17 { get; }
        decimal K18 { get; }
        decimal K19 { get; }
        decimal K20 { get; }
        decimal K21 { get; }
        decimal K22 { get; }
        decimal K23 { get; }
        decimal K24 { get; }
        decimal K25 { get; }
        decimal K26 { get; }
        decimal K27 { get; }
        decimal K28 { get; }
        decimal K29 { get; }
        decimal K30 { get; }
        decimal K31 { get; }
        decimal K32 { get; }
        decimal K33 { get; }
        decimal K34 { get; }
        decimal K35 { get; }
        decimal K36 { get; }
        bool MPP { get; }
        bool MRT { get; }
        bool MRUZ { get; }
        DateTime? SalesDate { get; }
        string SalesEvidence { get; }
        string SalesNumber { get; }
        bool SW { get; }
        bool TP { get; }
        bool TTD { get; }
        bool TTWNT { get; }
        bool WSTO_EE { get; }
        bool IED { get; }
        DateTime? DueDate { get; }
    }
}
