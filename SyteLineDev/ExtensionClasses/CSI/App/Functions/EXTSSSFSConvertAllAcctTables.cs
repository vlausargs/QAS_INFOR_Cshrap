//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSConvertAllAcctTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSConvertAllAcctTables : IEXTSSSFSConvertAllAcctTables
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSConvertAllAcctTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EXTSSSFSConvertAllAcctTablesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSConvertAllAcctTablesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
