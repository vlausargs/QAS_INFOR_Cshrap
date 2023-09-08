//PROJECT NAME: Data
//CLASS NAME: InitModuleMOBILEDISCONNECTED.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleMOBILEDISCONNECTED : IInitModuleMOBILEDISCONNECTED
	{
		readonly IApplicationDB appDB;
		
		public InitModuleMOBILEDISCONNECTED(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleMOBILEDISCONNECTEDSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleMOBILEDISCONNECTEDSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
