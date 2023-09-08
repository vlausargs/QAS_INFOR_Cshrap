//PROJECT NAME: Production
//CLASS NAME: PmfFmGetUet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmGetUet : IPmfFmGetUet
	{
		readonly IApplicationDB appDB;
		
		public PmfFmGetUet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfFmGetUetSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmGetUetSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
