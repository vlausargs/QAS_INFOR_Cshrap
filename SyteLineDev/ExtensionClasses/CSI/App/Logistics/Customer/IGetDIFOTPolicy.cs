//PROJECT NAME: Logistics
//CLASS NAME: IGetDIFOTPolicy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetDIFOTPolicy
	{
		(int? ReturnCode, decimal? shipped_over_ordered_qty_tolerance,
		decimal? shipped_under_ordered_qty_tolerance,
		int? days_shipped_after_due_date_tolerance,
		int? days_shipped_before_due_date_tolerance) GetDIFOTPolicySp(string Site = null,
		string PCoNum = null,
		int? PCoLine = null,
		int? PCoRelease = null,
		string PCustNum = null,
		int? PCustSeq = null,
		int? PHierarchy = null,
		decimal? shipped_over_ordered_qty_tolerance = null,
		decimal? shipped_under_ordered_qty_tolerance = null,
		int? days_shipped_after_due_date_tolerance = null,
		int? days_shipped_before_due_date_tolerance = null);
	}
}

