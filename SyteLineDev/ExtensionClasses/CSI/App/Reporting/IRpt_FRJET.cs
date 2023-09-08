//PROJECT NAME: Reporting
//CLASS NAME: IRpt_FRJET.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_FRJET
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FRJETSp(int? PYear,
		DateTime? StartDate,
		DateTime? EndDate,
		string pSite = null);
	}
}

