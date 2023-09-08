//PROJECT NAME: Logistics
//CLASS NAME: ICLM_POBuilderPLNData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_POBuilderPLNData
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_POBuilderPLNDataSp(
			int? RecordCap,
			string Site,
			string SiteGroup,
			string ItemStarting,
			string ItemEnding,
			DateTime? StartingDueDate,
			DateTime? EndingDueDate,
			string Planner,
			string VendorCurrCode);
	}
}

