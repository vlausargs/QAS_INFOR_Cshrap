//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SLArtrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.Germany
{
	public interface IRpt_SLArtrans : IRpt_GOBDUMediaService
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLArtransSp(
			DateTime? TransDateBeg,
			DateTime? TransDateEnd,
			string SiteID);
	}
}

