//PROJECT NAME: Logistics
//CLASS NAME: ISchedUpdateApptDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedUpdateApptDetail
	{
		(int? ReturnCode, string Infobar) SchedUpdateApptDetailSp(Guid? RowPointer,
		DateTime? RecordDate,
		int? StatCodeChanged = 0,
		string StatCode = null,
		string PartnerID = null,
		int? GPSOnline = 0,
		decimal? Latitude = null,
		decimal? Longitude = null,
		DateTime? GPSLocDate = null,
		int? NotesChanged = 0,
		string Notes = null,
		string Infobar = null);
	}
}

