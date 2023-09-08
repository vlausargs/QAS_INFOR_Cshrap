//PROJECT NAME: CSIEmployee
//CLASS NAME: ESSGetSupName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IESSGetSupName
	{
		(int? ReturnCode, string SupName) ESSGetSupNameSp(string EmpNum = null,
		string SupName = null);
	}
	
	public class ESSGetSupName : IESSGetSupName
	{
		readonly IApplicationDB appDB;
		
		public ESSGetSupName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SupName) ESSGetSupNameSp(string EmpNum = null,
		string SupName = null)
		{
			EmpNumType _EmpNum = EmpNum;
			EmpNameType _SupName = SupName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ESSGetSupNameSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupName", _SupName, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SupName = _SupName;
				
				return (Severity, SupName);
			}
		}
	}
}
