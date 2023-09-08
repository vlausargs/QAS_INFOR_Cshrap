//PROJECT NAME: Logistics
//CLASS NAME: IProfileAPDraftPrintingPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IProfileAPDraftPrintingPosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileAPDraftPrintingPostingSp(Guid? ProcessID = null,
		string BankCode = null,
		string StartVendNum = null,
		string EndVendNum = null,
		DateTime? StartDueDate = null,
		DateTime? EndDueDate = null,
		string StartVendName = null,
		string EndVendName = null);
	}
}

