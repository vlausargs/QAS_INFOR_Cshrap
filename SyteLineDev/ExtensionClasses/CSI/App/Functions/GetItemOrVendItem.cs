//PROJECT NAME: Data
//CLASS NAME: GetItemOrVendItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetItemOrVendItem : IGetItemOrVendItem
	{
		readonly IApplicationDB appDB;
		
		public GetItemOrVendItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetItemOrVendItemFn(
			string VendItem,
			string Item)
		{
			ItemType _VendItem = VendItem;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetItemOrVendItem](@VendItem, @Item)";
				
				appDB.AddCommandParameter(cmd, "VendItem", _VendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
