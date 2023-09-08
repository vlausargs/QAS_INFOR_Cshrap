//PROJECT NAME: Data
//CLASS NAME: ItemWhseQtyOnHand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemWhseQtyOnHand : IItemWhseQtyOnHand
	{
		readonly IApplicationDB appDB;
		
		public ItemWhseQtyOnHand(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ItemWhseQtyOnHandFn(
			string Item)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemWhseQtyOnHand](@Item)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
