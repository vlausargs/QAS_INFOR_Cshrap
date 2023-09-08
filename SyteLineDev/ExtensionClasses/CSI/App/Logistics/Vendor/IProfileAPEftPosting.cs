//PROJECT NAME: Logistics
//CLASS NAME: IProfileAPEftPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IProfileAPEftPosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileAPEftPostingSp(Guid? ProcessID = null,
		string BankCode = null,
		string StartVendNum = null,
		string EndVendNum = null,
		DateTime? StartPayDate = null,
		DateTime? EndPayDate = null,
		string StartVendName = null,
		string EndVendName = null);
	}
}

