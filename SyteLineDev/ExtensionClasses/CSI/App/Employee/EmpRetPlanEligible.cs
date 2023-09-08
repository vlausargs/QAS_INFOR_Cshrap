//PROJECT NAME: Employee
//CLASS NAME: EmpRetPlanEligible.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class EmpRetPlanEligible : IEmpRetPlanEligible
	{
		readonly IApplicationDB appDB;
		
		
		public EmpRetPlanEligible(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) EmpRetPlanEligibleSp(string PDeCode,
		string PEmpType,
		string Infobar)
		{
			DeCodeType _PDeCode = PDeCode;
			EmpTypeType _PEmpType = PEmpType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EmpRetPlanEligibleSp";
				
				appDB.AddCommandParameter(cmd, "PDeCode", _PDeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpType", _PEmpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
