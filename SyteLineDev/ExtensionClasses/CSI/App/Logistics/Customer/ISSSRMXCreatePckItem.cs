//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXCreatePckItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXCreatePckItem
	{
		(int? ReturnCode, string Infobar) SSSRMXCreatePckItemSp(string TPckCall,
		int? PackNum,
		string RefNum,
		string ShipCode,
		int? QtyPackages,
		decimal? Weight,
		DateTime? PackDate,
		string Whse,
		int? RefLine,
		int? RefRelease,
		string RefType,
		string Item,
		string UM,
		string description,
		decimal? qtyordered,
		decimal? qtytopack,
		decimal? qtytopackconv,
		string vendRef,
		string VendNum,
		Guid? RowPointer,
		string ProcessId,
		int? PackLine,
		string Infobar);
	}
}

