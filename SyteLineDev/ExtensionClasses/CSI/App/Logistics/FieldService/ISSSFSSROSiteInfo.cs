//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROSiteInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROSiteInfo
	{
		(int? ReturnCode,
			decimal? PQtyOnHand,
			decimal? PQtyRsvdCo,
			string PUM,
			int? PSuccess) SSSFSSROSiteInfoSP(
			string PSite = null,
			string PItem = null,
			int? ShowShortages = 1,
			DateTime? PSROStartDate = null,
			string PRefNum = null,
			int? PRefLineSuf = null,
			int? PRefRelease = null,
			decimal? PQtyOnHand = 0,
			decimal? PQtyRsvdCo = 0,
			string PUM = null,
			int? PSuccess = 1);
	}
}

