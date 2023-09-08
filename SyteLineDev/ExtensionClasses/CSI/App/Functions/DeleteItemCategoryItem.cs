//PROJECT NAME: Data
//CLASS NAME: DeleteItemCategoryItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DeleteItemCategoryItem : IDeleteItemCategoryItem
	{
		readonly IApplicationDB appDB;
		
		public DeleteItemCategoryItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DeleteItemCategoryItemSp(
			Guid? DelRowPointer,
			string ItemCategory,
			string Item)
		{
			RowPointerType _DelRowPointer = DelRowPointer;
			ItemCategoryType _ItemCategory = ItemCategory;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteItemCategoryItemSp";
				
				appDB.AddCommandParameter(cmd, "DelRowPointer", _DelRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCategory", _ItemCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
