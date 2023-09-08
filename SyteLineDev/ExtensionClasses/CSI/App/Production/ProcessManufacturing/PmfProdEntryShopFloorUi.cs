//PROJECT NAME: Production
//CLASS NAME: PmfProdEntryShopFloorUi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfProdEntryShopFloorUi : IPmfProdEntryShopFloorUi
	{
		readonly IApplicationDB appDB;
		
		public PmfProdEntryShopFloorUi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfProdEntryShopFloorUiSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfProdEntryShopFloorUiSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
