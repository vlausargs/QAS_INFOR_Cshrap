//PROJECT NAME: Finance
//CLASS NAME: ICLM_ExecutiveShipmentRevenue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_ExecutiveShipmentRevenue
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ExecutiveShipmentRevenueSp(
			string View,
			string SiteGroup,
			DateTime? DateStarting,
			DateTime? DateEnding,
			string FilterString = null);
	}
}

