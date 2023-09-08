//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXDispInvAdjPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXDispInvAdjPost
	{
		(int? ReturnCode,
			decimal? Cost,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar) SSSRMXDispInvAdjPostSp(
			string TrxType,
			string RmxType,
			DateTime? TransDate,
			Guid? DispCodeRowPointer,
			decimal? Qty,
			string Item,
			string Whse,
			string Loc,
			string Lot,
			string ReasonCode,
			string Stat,
			decimal? Cost,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar,
			string Workkey = null,
			string RmaNum = null,
			int? RmaLine = null,
			int? RMXTransNum = null,
			decimal? RMXSeq = null,
			string DocumentNum = null);
	}
}

