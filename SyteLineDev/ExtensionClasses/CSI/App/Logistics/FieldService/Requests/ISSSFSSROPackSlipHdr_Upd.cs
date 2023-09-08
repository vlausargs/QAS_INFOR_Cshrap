//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROPackSlipHdr_Upd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROPackSlipHdr_Upd
	{
		(int? ReturnCode, int? PackNum) SSSFSSROPackSlipHdr_UpdSp(Guid? RowPointer,
		int? Selected,
		int? PackNum,
		string Whse,
		DateTime? PackDate,
		string CustNum,
		string DropType,
		string DropPartnerID,
		string DropCustNum,
		string DropUsrNum,
		string DropShipNo,
		int? DropCustSeq,
		int? DropUsrSeq,
		decimal? Weight,
		string ShipCode,
		int? QtyPackages);
	}
}

