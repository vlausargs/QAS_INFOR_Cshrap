//PROJECT NAME: Production
//CLASS NAME: ApsSafetyStockNeeded.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSafetyStockNeeded : IApsSafetyStockNeeded
	{
		readonly IApplicationDB appDB;
		
		public ApsSafetyStockNeeded(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsSafetyStockNeededFn(
			string pItem)
		{
			ItemType _pItem = pItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsSafetyStockNeeded](@pItem)";
				
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
