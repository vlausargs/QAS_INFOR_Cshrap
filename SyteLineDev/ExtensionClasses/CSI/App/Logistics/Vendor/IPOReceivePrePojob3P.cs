//PROJECT NAME: Logistics
//CLASS NAME: IPOReceivePrePojob3P.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPOReceivePrePojob3P
	{
		(int? ReturnCode, decimal? TComplete,
		decimal? TMove,
		string Infobar) POReceivePrePojob3PSp(string PoItemRefNum,
		int? PoItemRefLineSuf,
		int? PoItemRefRelease,
		string PoItem,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		int? DRReturn,
		decimal? QtyToReceiveConv,
		decimal? TComplete,
		decimal? TMove,
		string Infobar);
	}
}

