//PROJECT NAME: Production
//CLASS NAME: PmfFmAttrRollup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmAttrRollup : IPmfFmAttrRollup
	{
		readonly IApplicationDB appDB;
		
		public PmfFmAttrRollup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfFmAttrRollupSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmAttrRollupSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
