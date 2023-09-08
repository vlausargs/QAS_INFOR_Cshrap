//PROJECT NAME: Data
//CLASS NAME: InsertTtPrRecord.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InsertTtPrRecord : IInsertTtPrRecord
	{
		readonly IApplicationDB appDB;
		
		public InsertTtPrRecord(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string t_plans) InsertTtPrRecordSp(
			string emp_num,
			string de_code,
			decimal? amt_delta,
			string t_plans)
		{
			EmpNumType _emp_num = emp_num;
			DeCodeType _de_code = de_code;
			PrAmountType _amt_delta = amt_delta;
			Infobar _t_plans = t_plans;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertTtPrRecordSp";
				
				appDB.AddCommandParameter(cmd, "emp_num", _emp_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "de_code", _de_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "amt_delta", _amt_delta, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_plans", _t_plans, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				t_plans = _t_plans;
				
				return (Severity, t_plans);
			}
		}
	}
}
