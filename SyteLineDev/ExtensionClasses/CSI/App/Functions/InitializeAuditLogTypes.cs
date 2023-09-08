//PROJECT NAME: Data
//CLASS NAME: InitializeAuditLogTypes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitializeAuditLogTypes : IInitializeAuditLogTypes
	{
		readonly IApplicationDB appDB;
		
		public InitializeAuditLogTypes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitializeAuditLogTypesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitializeAuditLogTypesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
