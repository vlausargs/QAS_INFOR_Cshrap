//PROJECT NAME: Production
//CLASS NAME: BOMBulkImport_PopulateManufacturerData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class BOMBulkImport_PopulateManufacturerData : IBOMBulkImport_PopulateManufacturerData
	{
		readonly IApplicationDB appDB;
		
		public BOMBulkImport_PopulateManufacturerData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Error,
			string ErrorMsg) BOMBulkImport_PopulateManufacturerDataSp(
			string xmlFileName,
			int? Error,
			string ErrorMsg)
		{
			StringType _xmlFileName = xmlFileName;
			ListYesNoType _Error = Error;
			InfobarType _ErrorMsg = ErrorMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BOMBulkImport_PopulateManufacturerDataSp";
				
				appDB.AddCommandParameter(cmd, "xmlFileName", _xmlFileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Error", _Error, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Error = _Error;
				ErrorMsg = _ErrorMsg;
				
				return (Severity, Error, ErrorMsg);
			}
		}
	}
}
