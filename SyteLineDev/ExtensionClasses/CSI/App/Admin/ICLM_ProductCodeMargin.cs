//PROJECT NAME: Admin
//CLASS NAME: ICLM_ProductCodeMargin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_ProductCodeMargin
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ProductCodeMarginSp(
			string ProductCode = null,
			int? StartYear = null,
			int? EndYear = null,
			int? StartPeriod = null,
			int? EndPeriod = null,
			int? PageNum = null,
			int? EntriesPerPage = null,
			string SiteRef = null);
	}
}

