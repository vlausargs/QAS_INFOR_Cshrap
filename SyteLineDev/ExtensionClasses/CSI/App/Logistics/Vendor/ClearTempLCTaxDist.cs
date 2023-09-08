//PROJECT NAME: Logistics
//CLASS NAME: ClearTempLCTaxDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ClearTempLCTaxDist : IClearTempLCTaxDist
	{
		readonly IApplicationDB appDB;
		
		
		public ClearTempLCTaxDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ClearTempLCTaxDistSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ClearTempLCTaxDistSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
