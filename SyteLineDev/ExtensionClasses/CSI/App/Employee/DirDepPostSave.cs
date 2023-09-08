//PROJECT NAME: Employee
//CLASS NAME: DirDepPostSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IDirDepPostSave
	{
		(int? ReturnCode, string Infobar) DirDepPostSaveSp(string PEmpNum,
		string Infobar);
	}
	
	public class DirDepPostSave : IDirDepPostSave
	{
		readonly IApplicationDB appDB;
		
		public DirDepPostSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DirDepPostSaveSp(string PEmpNum,
		string Infobar)
		{
			EmpNumType _PEmpNum = PEmpNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DirDepPostSaveSp";
				
				appDB.AddCommandParameter(cmd, "PEmpNum", _PEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
