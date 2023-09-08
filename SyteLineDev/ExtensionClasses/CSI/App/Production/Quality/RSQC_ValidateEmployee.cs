//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateEmploy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateEmploy : IRSQC_ValidateEmploy
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_ValidateEmploy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Name,
		string Infobar) RSQC_ValidateEmployee(int? ValidateOk,
		string EmployeeNum,
		string Name,
		string Infobar)
		{
			ListYesNoType _ValidateOk = ValidateOk;
			EmpNumType _EmployeeNum = EmployeeNum;
			NameType _Name = Name;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_ValidateEmployee";
				
				appDB.AddCommandParameter(cmd, "ValidateOk", _ValidateOk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeNum", _EmployeeNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Name = _Name;
				Infobar = _Infobar;
				
				return (Severity, Name, Infobar);
			}
		}
	}
}
