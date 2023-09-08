//PROJECT NAME: Data
//CLASS NAME: ItemECNTracked.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemECNTracked : IItemECNTracked
	{
		readonly IApplicationDB appDB;
		
		public ItemECNTracked(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ItemECNTrackedFn(
			string Item)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemECNTracked](@Item)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
