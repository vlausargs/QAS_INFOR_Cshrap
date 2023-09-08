//PROJECT NAME: Logistics
//CLASS NAME: IProfileVendorStatementofAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IProfileVendorStatementofAccount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileVendorStatementofAccountSp(DateTime? CutOffDate = null,
		string StartVendNum = null,
		string EndVendNum = null);
	}
}

