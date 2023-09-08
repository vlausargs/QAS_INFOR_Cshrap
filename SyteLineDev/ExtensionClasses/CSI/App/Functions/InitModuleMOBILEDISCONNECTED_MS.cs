//PROJECT NAME: Data
//CLASS NAME: InitModuleMOBILEDISCONNECTED_MS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleMOBILEDISCONNECTED_MS : IInitModuleMOBILEDISCONNECTED_MS
	{
		readonly IApplicationDB appDB;
		
		public InitModuleMOBILEDISCONNECTED_MS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleMOBILEDISCONNECTED_MSSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleMOBILEDISCONNECTED_MSSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
