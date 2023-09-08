//PROJECT NAME: Production
//CLASS NAME: PmfPnProdTranInitUi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnProdTranInitUi : IPmfPnProdTranInitUi
	{
		readonly IApplicationDB appDB;
		
		public PmfPnProdTranInitUi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfPnProdTranInitUiSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnProdTranInitUiSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
