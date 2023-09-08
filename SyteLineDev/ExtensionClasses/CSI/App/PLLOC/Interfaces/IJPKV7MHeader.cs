using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IJPKV7MHeader
    {

        string FormCode { get; }
        string FormSchemaVersion { get; }
        string FormSystemCode { get; }
        string FormVariant { get; }
        string Item { get; }
        DateTime JPKProductionDate { get; }
        int Month { get; }
        string OfficeCode { get; }
        string OrderPurpose { get; }
        string SystemName { get; }
        int Year { get; }
    }
}
