//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ItemFeatureGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ItemFeatureGroup
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemFeatureGroupSp(string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ABCCode = null,
		int? PageBreak = null,
		int? DisplayHeader = 1,
		string pSite = null);
	}
}

