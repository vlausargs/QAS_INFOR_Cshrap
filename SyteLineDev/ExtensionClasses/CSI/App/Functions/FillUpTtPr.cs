//PROJECT NAME: Data
//CLASS NAME: FillUpTtPr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FillUpTtPr : IFillUpTtPr
	{
		readonly IApplicationDB appDB;
		
		public FillUpTtPr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string t_plans) FillUpTtPrSp(
			string emp_num,
			decimal? empr_con,
			string t_plans)
		{
			EmpNumType _emp_num = emp_num;
			PrAmountType _empr_con = empr_con;
			Infobar _t_plans = t_plans;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FillUpTtPrSp";
				
				appDB.AddCommandParameter(cmd, "emp_num", _emp_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "empr_con", _empr_con, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_plans", _t_plans, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				t_plans = _t_plans;
				
				return (Severity, t_plans);
			}
		}
	}
}
