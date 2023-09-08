//PROJECT NAME: Production
//CLASS NAME: PmfGetOwnerTypeToken.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetOwnerTypeToken : IPmfGetOwnerTypeToken
	{
		readonly IApplicationDB appDB;
		
		public PmfGetOwnerTypeToken(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfGetOwnerTypeTokenSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetOwnerTypeTokenSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
