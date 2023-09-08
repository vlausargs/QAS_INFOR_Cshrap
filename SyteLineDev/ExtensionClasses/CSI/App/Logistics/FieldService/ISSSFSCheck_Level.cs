//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSCheck_Level.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSCheck_Level
	{
		(int? ReturnCode,
			int? p_has_holds) SSSFSCheck_LevelSp(
			string p_level,
			string p_sro_num,
			int? p_sro_line,
			int? p_sro_oper,
			int? beg_sro_oper,
			int? end_sro_oper,
			DateTime? beg_trans_date,
			DateTime? end_trans_date,
			int? p_has_holds);
	}
}

