//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedDispatchPartnerSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedDispatchPartnerSave
	{
		(int? ReturnCode, string Infobar) SSSFSSchedDispatchPartnerSaveSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? RefSeq,
		string PartnerId,
		DateTime? SchedDate,
		string ApptType,
		string ApptStat,
		string ApptDesc,
		decimal? ApptHrs,
		string NotesContent,
		string Infobar);
	}
}

