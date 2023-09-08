//PROJECT NAME: Data
//CLASS NAME: DeleteTableMessages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DeleteTableMessages : IDeleteTableMessages
	{
		readonly IApplicationDB appDB;
		
		public DeleteTableMessages(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DeleteTableMessagesSp(
			string TableName)
		{
			StringType _TableName = TableName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteTableMessagesSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
