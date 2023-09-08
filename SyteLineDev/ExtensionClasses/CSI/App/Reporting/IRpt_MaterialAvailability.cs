//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MaterialAvailability.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MaterialAvailability
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MaterialAvailabilitySp(string ExOptdfEst08Item = null,
		string ExOptdfEst08Job = null,
		int? ExOptdfEst08Suffix = null,
		string ExOptprPsNum = null,
		DateTime? ReleaseDueDate = null,
		decimal? ExOptdfEst08QtyReq = null,
		DateTime? ExOptdfEst08Date = null,
		int? ExOptacConsItemOh = null,
		int? ExOptszUseSafety = null,
		int? ExOptgoInclRelJobs = null,
		string TPsStat = null,
		int? ExOptgoInclOrdPo = null,
		int? ExOptszShowShortOnly = null,
		int? ExOptszSubFromOnhand = null,
		int? TDateSensitive = null,
		string ExOptdfEst08Whse = null,
		int? ExOptdfEst08DateOffset = null,
		int? DisplayHeader = null,
		string pSite = null,
		string BGUser = null);
	}
}

