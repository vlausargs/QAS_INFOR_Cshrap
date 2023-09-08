//PROJECT NAME: Production
//CLASS NAME: BOMBulkImport_Process.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class BOMBulkImport_Process : IBOMBulkImport_Process
	{
		readonly IApplicationDB appDB;
		
		
		public BOMBulkImport_Process(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BOMBulkImport_ProcessSp(string xmlFileName,
		string xmlData)
		{
			OSLocationType _xmlFileName = xmlFileName;
			StringType _xmlData = xmlData;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BOMBulkImport_ProcessSp";
				
				appDB.AddCommandParameter(cmd, "xmlFileName", _xmlFileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "xmlData", _xmlData, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
