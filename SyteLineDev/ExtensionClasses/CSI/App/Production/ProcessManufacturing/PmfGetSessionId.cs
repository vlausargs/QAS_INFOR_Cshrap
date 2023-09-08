//PROJECT NAME: Production
//CLASS NAME: PmfGetSessionId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetSessionId : IPmfGetSessionId
	{
		readonly IApplicationDB appDB;
		
		public PmfGetSessionId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfGetSessionIdSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetSessionIdSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
