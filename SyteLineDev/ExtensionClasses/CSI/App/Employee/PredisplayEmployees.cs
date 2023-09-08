//PROJECT NAME: Employee
//CLASS NAME: PredisplayEmployees.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PredisplayEmployees : IPredisplayEmployees
	{
		readonly IApplicationDB appDB;
		
		
		public PredisplayEmployees(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PHourlyPerm,
		int? PSalaryPerm,
		int? PCheckSsnEnabled,
		int? Prenote) PredisplayEmployeesSp(int? PHourlyPerm,
		int? PSalaryPerm,
		int? PCheckSsnEnabled,
		int? Prenote = 1)
		{
			PrivilegeType _PHourlyPerm = PHourlyPerm;
			PrivilegeType _PSalaryPerm = PSalaryPerm;
			ListYesNoType _PCheckSsnEnabled = PCheckSsnEnabled;
			PrenoteType _Prenote = Prenote;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PredisplayEmployeesSp";
				
				appDB.AddCommandParameter(cmd, "PHourlyPerm", _PHourlyPerm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSalaryPerm", _PSalaryPerm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCheckSsnEnabled", _PCheckSsnEnabled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prenote", _Prenote, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PHourlyPerm = _PHourlyPerm;
				PSalaryPerm = _PSalaryPerm;
				PCheckSsnEnabled = _PCheckSsnEnabled;
				Prenote = _Prenote;
				
				return (Severity, PHourlyPerm, PSalaryPerm, PCheckSsnEnabled, Prenote);
			}
		}
	}
}
