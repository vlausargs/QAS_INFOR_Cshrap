//PROJECT NAME: Data
//CLASS NAME: InitDataSHIFT000.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitDataSHIFT000 : IInitDataSHIFT000
	{
		readonly IApplicationDB appDB;
		
		public InitDataSHIFT000(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitDataSHIFT000Sp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitDataSHIFT000Sp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
