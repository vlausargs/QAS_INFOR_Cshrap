//PROJECT NAME: Logistics
//CLASS NAME: IRmaReplLoadDefaults.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaReplLoadDefaults
	{
		(int? ReturnCode, string PItem,
		string RCustItem,
		string RItemDesc,
		string RItemUM,
		decimal? RUnitPrice,
		int? RItemSerTrack,
		int? IncludeTaxInPrice,
		string Infobar) RmaReplLoadDefaultsSp(string PRmaNum,
		int? PRmaLine,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		string PItem,
		decimal? PQtyToReturnConv,
		string PPricecode,
		string RCustItem,
		string RItemDesc,
		string RItemUM,
		decimal? RUnitPrice,
		int? RItemSerTrack,
		int? IncludeTaxInPrice,
		string Infobar);
	}
}

