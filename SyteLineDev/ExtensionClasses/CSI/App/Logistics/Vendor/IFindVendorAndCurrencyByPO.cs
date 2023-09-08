//PROJECT NAME: Logistics
//CLASS NAME: IFindVendorAndCurrencyByPO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
    public interface IFindVendorAndCurrencyByPO
    {
            (int? ReturnCode,
            string VendNum,
        string CurrCode) FindVendorAndCurrencyByPOSp(
            string PoNum,
            string VendNum,
            string CurrCode);
    }
}

