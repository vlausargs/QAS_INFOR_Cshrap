//PROJECT NAME: Data
//CLASS NAME: SalPct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SalPct : ISalPct
	{
		readonly IApplicationDB appDB;
		
		public SalPct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SalPctSp(
			string EmpinsEmpNum,
			string Infobar)
		{
			EmpNumType _EmpinsEmpNum = EmpinsEmpNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SalPctSp";
				
				appDB.AddCommandParameter(cmd, "EmpinsEmpNum", _EmpinsEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
