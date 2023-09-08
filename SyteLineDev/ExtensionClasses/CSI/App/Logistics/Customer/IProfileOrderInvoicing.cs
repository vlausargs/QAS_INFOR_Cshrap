//PROJECT NAME: Logistics
//CLASS NAME: IProfileOrderInvoicing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IProfileOrderInvoicing
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileOrderInvoicingSp(string StartInvNum = null,
		string EndInvNum = null,
		string StartOrderNum = null,
		string EndOrderNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartCustNum = null,
		string EndCustNum = null,
		string CalledFrom = "REPRINT",
		Guid? ProcessID = null);
	}
}

