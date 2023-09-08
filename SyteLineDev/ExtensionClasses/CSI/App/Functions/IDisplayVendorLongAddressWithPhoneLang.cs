//PROJECT NAME: Data
//CLASS NAME: IDisplayVendorLongAddressWithPhoneLang.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayVendorLongAddressWithPhoneLang
	{
		(int? ReturnCode,
			string LongAddr) DisplayVendorLongAddressWithPhoneLangSp(
			string VendNum,
			string MessageLanguage,
			string Contact = null,
			string LongAddr = null);
	}
}

