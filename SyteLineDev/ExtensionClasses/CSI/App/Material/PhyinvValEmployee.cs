//PROJECT NAME: Material
//CLASS NAME: PhyinvValEmployee.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PhyinvValEmployee : IPhyinvValEmployee
	{
		readonly IApplicationDB appDB;
		
		
		public PhyinvValEmployee(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PhyinvValEmployeeSp(string Employee,
		string Validate,
		int? MType,
		string Infobar)
		{
			EmpNumType _Employee = Employee;
			PhyInvValCounterType _Validate = Validate;
			IntType _MType = MType;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PhyinvValEmployeeSp";
				
				appDB.AddCommandParameter(cmd, "Employee", _Employee, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Validate", _Validate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MType", _MType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
