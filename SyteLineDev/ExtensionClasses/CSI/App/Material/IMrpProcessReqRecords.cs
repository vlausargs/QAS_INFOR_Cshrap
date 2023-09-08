//PROJECT NAME: Material
//CLASS NAME: IMrpProcessReqRecords.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpProcessReqRecords
	{
		(int? ReturnCode,
			int? RecordCnt,
			string Infobar) MrpProcessReqRecordsSp(
			string PlannerCode,
			string Buyer,
			string Source,
			string Whse,
			decimal? UserId,
			int? RecordCnt,
			string Infobar);
	}
}

