//PROJECT NAME: Material
//CLASS NAME: IsItemNotInInventory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class IsItemNotInInventory : IIsItemNotInInventory
	{
		readonly IApplicationDB appDB;
		
		
		public IsItemNotInInventory(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ItemNotInInventory) IsItemNotInInventorySp(string Item,
		int? ItemNotInInventory)
		{
			ItemType _Item = Item;
			ListYesNoType _ItemNotInInventory = ItemNotInInventory;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsItemNotInInventorySp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemNotInInventory", _ItemNotInInventory, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemNotInInventory = _ItemNotInInventory;
				
				return (Severity, ItemNotInInventory);
			}
		}
	}
}
