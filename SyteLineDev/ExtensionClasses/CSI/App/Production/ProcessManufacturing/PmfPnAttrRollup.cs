//PROJECT NAME: Production
//CLASS NAME: PmfPnAttrRollup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnAttrRollup : IPmfPnAttrRollup
	{
		readonly IApplicationDB appDB;
		
		public PmfPnAttrRollup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfPnAttrRollupSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnAttrRollupSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
