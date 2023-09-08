//PROJECT NAME: Production
//CLASS NAME: PmfItemUpdateCurrent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfItemUpdateCurrent : IPmfItemUpdateCurrent
	{
		readonly IApplicationDB appDB;
		
		public PmfItemUpdateCurrent(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfItemUpdateCurrentSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfItemUpdateCurrentSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
