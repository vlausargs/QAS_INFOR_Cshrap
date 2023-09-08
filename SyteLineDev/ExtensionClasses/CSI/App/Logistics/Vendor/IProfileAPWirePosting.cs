//PROJECT NAME: Logistics
//CLASS NAME: IProfileAPWirePosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IProfileAPWirePosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileAPWirePostingSp(Guid? ProcessID = null,
		string BankCode = null,
		string StartVendNum = null,
		string EndVendNum = null,
		DateTime? StartPayDate = null,
		DateTime? EndPayDate = null,
		string StartVendName = null,
		string EndVendName = null);
	}
}

