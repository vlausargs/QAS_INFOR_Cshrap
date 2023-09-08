//PROJECT NAME: Codes
//CLASS NAME: ICLM_GetSiteSelection.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_GetSiteSelection
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetSiteSelectionSp(string FilterGroupSelection = null,
		string FilterUnClickSite = null,
		string FilterDeleteSite = null,
		string FilterIntranetName = null,
		string FilterSourceSite = null);
	}
}

