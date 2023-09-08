//PROJECT NAME: Material
//CLASS NAME: UpdateItemCategoryItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class UpdateItemCategoryItem : IUpdateItemCategoryItem
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateItemCategoryItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdateItemCategoryItemSp(int? Select,
		string Item,
		Guid? TreeRowPointer)
		{
			ListYesNoType _Select = Select;
			ItemType _Item = Item;
			RowPointerType _TreeRowPointer = TreeRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateItemCategoryItemSp";
				
				appDB.AddCommandParameter(cmd, "Select", _Select, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TreeRowPointer", _TreeRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
