//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSApsResyncAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSApsResyncAll : IEXTSSSFSApsResyncAll
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSApsResyncAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EXTSSSFSApsResyncAllSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSApsResyncAllSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
