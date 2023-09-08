//PROJECT NAME: Production
//CLASS NAME: BOMBulkImport_LoadXMLData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class BOMBulkImport_LoadXMLData : IBOMBulkImport_LoadXMLData
	{
		readonly IApplicationDB appDB;
		
		public BOMBulkImport_LoadXMLData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BOMBulkImport_LoadXMLDataSp(
			string xmlFileName,
			string xmlData)
		{
			StringType _xmlFileName = xmlFileName;
			StringType _xmlData = xmlData;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BOMBulkImport_LoadXMLDataSp";
				
				appDB.AddCommandParameter(cmd, "xmlFileName", _xmlFileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "xmlData", _xmlData, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
