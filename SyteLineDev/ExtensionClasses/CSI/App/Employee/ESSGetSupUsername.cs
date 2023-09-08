//PROJECT NAME: CSIEmployee
//CLASS NAME: ESSGetSupUsername.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IESSGetSupUsername
	{
		(int? ReturnCode, string SupUsername) ESSGetSupUsernameSp(string EmpNum = null,
		string SupUsername = null);
	}
	
	public class ESSGetSupUsername : IESSGetSupUsername
	{
		readonly IApplicationDB appDB;
		
		public ESSGetSupUsername(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SupUsername) ESSGetSupUsernameSp(string EmpNum = null,
		string SupUsername = null)
		{
			EmpNumType _EmpNum = EmpNum;
			UsernameType _SupUsername = SupUsername;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ESSGetSupUsernameSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupUsername", _SupUsername, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SupUsername = _SupUsername;
				
				return (Severity, SupUsername);
			}
		}
	}
}
