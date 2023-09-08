//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CARaSParts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CARaSParts
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CARaSPartsSp(string ItemStarting = null,
		string ItemEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

