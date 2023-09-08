//PROJECT NAME: Data
//CLASS NAME: ItemAvailTotalQtyOnHand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemAvailTotalQtyOnHand : IItemAvailTotalQtyOnHand
	{
		readonly IApplicationDB appDB;
		
		public ItemAvailTotalQtyOnHand(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ItemAvailTotalQtyOnHandFn(
			string Item)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemAvailTotalQtyOnHand](@Item)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
