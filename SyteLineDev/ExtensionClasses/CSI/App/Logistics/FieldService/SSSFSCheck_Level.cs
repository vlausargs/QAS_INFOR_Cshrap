//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCheck_Level.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSCheck_Level : ISSSFSCheck_Level
	{
		readonly IApplicationDB appDB;
		
		public SSSFSCheck_Level(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? p_has_holds) SSSFSCheck_LevelSp(
			string p_level,
			string p_sro_num,
			int? p_sro_line,
			int? p_sro_oper,
			int? beg_sro_oper,
			int? end_sro_oper,
			DateTime? beg_trans_date,
			DateTime? end_trans_date,
			int? p_has_holds)
		{
			StringType _p_level = p_level;
			FSSRONumType _p_sro_num = p_sro_num;
			FSSROLineType _p_sro_line = p_sro_line;
			FSSROOperType _p_sro_oper = p_sro_oper;
			FSSROOperType _beg_sro_oper = beg_sro_oper;
			FSSROOperType _end_sro_oper = end_sro_oper;
			DateType _beg_trans_date = beg_trans_date;
			DateType _end_trans_date = end_trans_date;
			ListYesNoType _p_has_holds = p_has_holds;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSCheck_LevelSp";
				
				appDB.AddCommandParameter(cmd, "p_level", _p_level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_sro_num", _p_sro_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_sro_line", _p_sro_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_sro_oper", _p_sro_oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_sro_oper", _beg_sro_oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_sro_oper", _end_sro_oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_trans_date", _beg_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_trans_date", _end_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_has_holds", _p_has_holds, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				p_has_holds = _p_has_holds;
				
				return (Severity, p_has_holds);
			}
		}
	}
}
