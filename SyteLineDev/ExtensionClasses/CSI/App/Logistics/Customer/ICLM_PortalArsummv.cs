//PROJECT NAME: Logistics
//CLASS NAME: ICLM_PortalArsummv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_PortalArsummv
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PortalArsummvSp(string PCustNum,
		int? PCurrentSite,
		int? PSubordinate,
		int? PActive,
		string PDisplayType,
		DateTime? PFromDate,
		DateTime? PToDate);
	}
}

