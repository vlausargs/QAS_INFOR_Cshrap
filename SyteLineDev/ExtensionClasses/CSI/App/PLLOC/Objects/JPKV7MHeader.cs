using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using PLLOC.Interfaces;

namespace PLLOC.Objects
{
    public class JPKV7MHeader : IJPKV7MHeader
    {
        public JPKV7MHeader(string formCode, string formSchemaVersion, string formSystemCode, string formVariant, string item, DateTime jPKProductionDate, int month, string officeCode, string orderPurpose, string systemName,  int year)
        {
            FormCode = formCode ?? throw new ArgumentNullException(nameof(formCode));
            FormSchemaVersion = formSchemaVersion ?? throw new ArgumentNullException(nameof(formSchemaVersion));
            FormSystemCode = formSystemCode ?? throw new ArgumentNullException(nameof(formSystemCode));
            FormVariant = formVariant ?? throw new ArgumentNullException(nameof(formVariant));
            Item = item ?? throw new ArgumentNullException(nameof(item));
            JPKProductionDate = jPKProductionDate;
            Month = month;
            OfficeCode = officeCode ?? throw new ArgumentNullException(nameof(officeCode));
            OrderPurpose = orderPurpose ?? throw new ArgumentNullException(nameof(orderPurpose));
            SystemName = systemName ?? throw new ArgumentNullException(nameof(systemName));
            Year = year;
        }


        public string FormCode { get; }
        public string FormSchemaVersion { get; }
        public string FormSystemCode { get; }
        public string FormVariant { get; }
        public string Item { get; }
        public DateTime JPKProductionDate { get; }
        public int Month { get; }
        public string OfficeCode { get; }
        public string OrderPurpose { get; }
        public string SystemName { get; }
        public int Year { get; }
    }
}
