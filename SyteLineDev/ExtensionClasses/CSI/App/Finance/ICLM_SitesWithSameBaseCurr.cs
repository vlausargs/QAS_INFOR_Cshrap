//PROJECT NAME: Finance
//CLASS NAME: ICLM_SitesWithSameBaseCurr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_SitesWithSameBaseCurr
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_SitesWithSameBaseCurrSp();
	}
}

