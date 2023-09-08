//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSPopulateAllNextKeys.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSPopulateAllNextKeys : IEXTSSSFSPopulateAllNextKeys
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSPopulateAllNextKeys(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EXTSSSFSPopulateAllNextKeysSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSPopulateAllNextKeysSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
