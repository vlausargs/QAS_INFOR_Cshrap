//PROJECT NAME: Production
//CLASS NAME: PmfGetOwnerToken.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetOwnerToken : IPmfGetOwnerToken
	{
		readonly IApplicationDB appDB;
		
		public PmfGetOwnerToken(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfGetOwnerTokenSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetOwnerTokenSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
