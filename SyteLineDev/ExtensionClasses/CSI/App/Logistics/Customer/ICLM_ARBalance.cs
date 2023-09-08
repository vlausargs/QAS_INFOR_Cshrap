//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ARBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_ARBalance
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode,
		string Infobar) CLM_ARBalanceSp(
			int? FiscalYear,
			int? Period,
			string SiteGroup,
			string FilterString = null,
			string Infobar = null);
	}
}

