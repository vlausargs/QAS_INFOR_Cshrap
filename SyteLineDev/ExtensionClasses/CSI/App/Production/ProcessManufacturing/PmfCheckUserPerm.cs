//PROJECT NAME: Production
//CLASS NAME: PmfCheckUserPerm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfCheckUserPerm : IPmfCheckUserPerm
	{
		readonly IApplicationDB appDB;
		
		public PmfCheckUserPerm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfCheckUserPermSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfCheckUserPermSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
