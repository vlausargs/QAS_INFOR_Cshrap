//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROMatlRequirementBuildTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROMatlRequirementBuildTT
	{
		(int? ReturnCode,
			decimal? PTotalQtyOnHand,
			decimal? PTotalQtyRsvdco) SSSFSSROMatlRequirementBuildTTSP(
			string PCCurrentSiteGroup = null,
			string PCurrentSiteList = null,
			string PDefaultSite = null,
			string PItem = null,
			int? PShowShortages = 1,
			DateTime? PSROStartDate = null,
			string PRefNum = null,
			int? PRefLineSuf = null,
			int? PRefRelease = null,
			decimal? PTotalQtyOnHand = null,
			decimal? PTotalQtyRsvdco = null);
	}
}

