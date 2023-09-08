//PROJECT NAME: Data
//CLASS NAME: InitModuleTLC_SYTELINELABRTRAK_MS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleTLC_SYTELINELABRTRAK_MS : IInitModuleTLC_SYTELINELABRTRAK_MS
	{
		readonly IApplicationDB appDB;
		
		public InitModuleTLC_SYTELINELABRTRAK_MS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleTLC_SYTELINELABRTRAK_MSSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleTLC_SYTELINELABRTRAK_MSSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
