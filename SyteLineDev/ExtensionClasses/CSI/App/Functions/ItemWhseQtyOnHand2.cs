//PROJECT NAME: Data
//CLASS NAME: ItemWhseQtyOnHand2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemWhseQtyOnHand2 : IItemWhseQtyOnHand2
	{
		readonly IApplicationDB appDB;
		
		public ItemWhseQtyOnHand2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ItemWhseQtyOnHand2Fn(
			string Item)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemWhseQtyOnHand2](@Item)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
