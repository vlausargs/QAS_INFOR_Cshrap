//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SLCoitems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.Germany
{
	public interface IRpt_SLCoitems : IRpt_GOBDUMediaService
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLCoitemsSp(
			DateTime? TransDateBeg,
			DateTime? TransDateEnd,
			string SiteID);
	}
}

