//PROJECT NAME: Data
//CLASS NAME: APP_TriggerIupCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class APP_TriggerIupCode : IAPP_TriggerIupCode
	{
		readonly IApplicationDB appDB;
		
		public APP_TriggerIupCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? APP_TriggerIupCodeSp(
			string TableName)
		{
			StringType _TableName = TableName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APP_TriggerIupCodeSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
