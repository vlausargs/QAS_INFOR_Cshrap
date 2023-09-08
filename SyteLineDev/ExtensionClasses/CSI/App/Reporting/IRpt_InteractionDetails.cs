//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InteractionDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_InteractionDetails
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InteractionDetailsSp(
			string InteractionType = "C",
			decimal? InteractionID = null,
			int? ShowInternal = 0,
			int? ShowExternal = 0,
			string pSite = null);
	}
}

