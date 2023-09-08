//PROJECT NAME: Data
//CLASS NAME: ItemWhseQtyOnHand4.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemWhseQtyOnHand4 : IItemWhseQtyOnHand4
	{
		readonly IApplicationDB appDB;
		
		public ItemWhseQtyOnHand4(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ItemWhseQtyOnHand4Fn(
			string Item,
			string Whse)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemWhseQtyOnHand4](@Item, @Whse)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
