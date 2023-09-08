//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSMultiDayScheduleLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSMultiDayScheduleLoad
	{
		(int? ReturnCode, string Infobar) SSSFSMultiDayScheduleLoadSp(Guid? SessionID,
		DateTime? SchedDate,
		decimal? Hrs,
		string Description,
		string RefType,
		string RefNum,
		int? RefLine,
		int? RefRel,
		int? RefSeq,
		string PartnerId,
		string SubId,
		string ApptType,
		string ApptStat,
		decimal? MinHours,
		decimal? MaxHours,
		int? Method,
		string NoteDesc,
		string NoteContent,
		string ScheduleID,
		string Infobar);
	}
}

