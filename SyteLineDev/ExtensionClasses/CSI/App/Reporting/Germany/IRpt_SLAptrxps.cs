//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SLAptrxps.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.Germany
{
	public interface IRpt_SLAptrxps : IRpt_GOBDUMediaService
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLAptrxpsSp(
			DateTime? TransDateBeg,
			DateTime? TransDateEnd,
			string SiteID);
	}
}

