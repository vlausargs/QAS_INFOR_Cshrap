//PROJECT NAME: Data
//CLASS NAME: ICLM_InvalidDueDateExternalSiteOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_InvalidDueDateExternalSiteOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_InvalidDueDateExternalSiteOrdersSp(
			string OrderType,
			string Status,
			string StartOrderNum,
			string EndOrderNum,
			int? StartLine,
			int? EndLine,
			int? StartRelease,
			int? EndRelease,
			string StartCustomer,
			string EndCustomer,
			DateTime? StartOrderDate,
			DateTime? EndOrderDate,
			DateTime? StartReleaseDate,
			DateTime? EndReleaseDate,
			DateTime? StartDueDate,
			DateTime? EndDueDate,
			int? IsForward,
			string OrigSite = null);
	}
}

