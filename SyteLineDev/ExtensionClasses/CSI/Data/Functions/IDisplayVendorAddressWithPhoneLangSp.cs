//PROJECT NAME: Data
//CLASS NAME: IDisplayVendorAddressWithPhoneLangSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IDisplayVendorAddressWithPhoneLang
    {
        string DisplayVendorAddressWithPhoneLangSp(
            string VendNum,
            string MessageLanguage,
            string Contact = null);
    }
}

