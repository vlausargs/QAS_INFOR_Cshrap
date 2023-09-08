//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSProcessLevel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSProcessLevel
	{
		(int? ReturnCode,
			int? Seq,
			string Infobar) SSSFSProcessLevelSp(
			string SerNum,
			string SerItem,
			int? tlevel,
			int? level,
			int? compid,
			DateTime? t_date,
			int? t_inc_warr,
			int? Seq,
			string Infobar);
	}
}

