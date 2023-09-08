//PROJECT NAME: Reporting
//CLASS NAME: IRpt_Pegging.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_Pegging
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PeggingSp(string ItemStarting = null,
		string ItemEnding = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

