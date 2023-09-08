//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ResourceGroupDispatchList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ResourceGroupDispatchList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceGroupDispatchListSp(string ResourceGroupType = null,
		string ResourceStarting = null,
		string ResourceEnding = null,
		string ResourceGroupStarting = null,
		string ResourceGroupEnding = null,
		string ResourceTypeStarting = null,
		string ResourceTypeEnding = null,
		DateTime? ScheduleDateStarting = null,
		DateTime? ScheduleDateEnding = null,
		int? ScheduleDateStartingOffset = null,
		int? ScheduleDateEndingOffset = null,
		int? ShowDateTime = 1,
		int? DisplayHeader = 1,
		string pSite = null);
	}
}

