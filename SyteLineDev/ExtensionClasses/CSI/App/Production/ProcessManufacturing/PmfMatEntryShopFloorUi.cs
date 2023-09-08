//PROJECT NAME: Production
//CLASS NAME: PmfMatEntryShopFloorUi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfMatEntryShopFloorUi : IPmfMatEntryShopFloorUi
	{
		readonly IApplicationDB appDB;
		
		public PmfMatEntryShopFloorUi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfMatEntryShopFloorUiSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfMatEntryShopFloorUiSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
