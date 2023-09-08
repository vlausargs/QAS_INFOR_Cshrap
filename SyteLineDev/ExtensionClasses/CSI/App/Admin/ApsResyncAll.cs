//PROJECT NAME: Admin
//CLASS NAME: ApsResyncAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class ApsResyncAll : IApsResyncAll
	{
		IApplicationDB appDB;
		
		
		public ApsResyncAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsResyncAllSp(int? TaskNumber = null)
		{
			TaskNumType _TaskNumber = TaskNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsResyncAllSp";
				
				appDB.AddCommandParameter(cmd, "TaskNumber", _TaskNumber, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
