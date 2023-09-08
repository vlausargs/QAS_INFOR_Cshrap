//PROJECT NAME: Data
//CLASS NAME: IVendorBuyerDefault.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVendorBuyerDefault
	{
		(int? ReturnCode,
			string Buyer,
			string Infobar) VendorBuyerDefaultSp(
			string PVendNum,
			string Buyer,
			string Infobar);
	}
}

