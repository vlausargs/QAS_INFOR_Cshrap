//PROJECT NAME: Material
//CLASS NAME: IMrpCreateMpwRecord.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpCreateMpwRecord
	{
		(int? ReturnCode,
			string Infobar) MrpCreateMpwRecordSp(
			string Item,
			string RefTab,
			decimal? ReqdQty,
			DateTime? DueDate,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			int? RefSeq,
			string Whse,
			string MpwRecType,
			DateTime? ReleaseDate,
			decimal? UserId,
			string Infobar,
			string ItemVend = null,
			string FromSite = null,
			string FromWhse = null,
			int? MrpParmShrinkFlag = null);
	}
}

