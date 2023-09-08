//PROJECT NAME: Production
//CLASS NAME: ApsSafetyStockNeeded2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSafetyStockNeeded2 : IApsSafetyStockNeeded2
	{
		readonly IApplicationDB appDB;
		
		public ApsSafetyStockNeeded2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsSafetyStockNeeded2Fn(
			string Item,
			string Whse)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsSafetyStockNeeded2](@Item, @Whse)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
