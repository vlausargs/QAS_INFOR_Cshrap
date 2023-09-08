//PROJECT NAME: Data
//CLASS NAME: PurgeTmpTrackRows.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PurgeTmpTrackRows : IPurgeTmpTrackRows
	{
		readonly IApplicationDB appDB;
		
		public PurgeTmpTrackRows(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PurgeTmpTrackRowsSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeTmpTrackRowsSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
