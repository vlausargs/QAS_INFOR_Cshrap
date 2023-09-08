//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConsoleCreateInc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSConsoleCreateInc
	{
		(int? ReturnCode, string IncNum,
		string Infobar,
		string UM) SSSFSConsoleCreateIncSp(string SSR,
		string Site,
		string Owner,
		string WorkSite,
		string PriorCode,
		string StatCode,
		string CustNum,
		int? CustSeq,
		string UsrNum,
		int? UsrSeq,
		string SerNum,
		string Item,
		string Contact,
		string Email,
		string Phone,
		string GenReason,
		string SpecReason,
		string IncNotes,
		string ReasonNotes,
		string IncNum,
		string Infobar,
		string CustItem,
		string UM = null,
		string Description = null,
		int? GPSOnline = 0,
		decimal? Latitude = null,
		decimal? Longitude = null,
		DateTime? GPSLocDate = null);
	}
}

