//PROJECT NAME: Material
//CLASS NAME: UpdateItemCategoryHierarchy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class UpdateItemCategoryHierarchy : IUpdateItemCategoryHierarchy
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateItemCategoryHierarchy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdateItemCategoryHierarchySp(int? Select,
		string ItemCategory,
		int? Rank,
		Guid? ParentRowPointer)
		{
			ListYesNoType _Select = Select;
			ItemCategoryType _ItemCategory = ItemCategory;
			ItemCategoryHierarchyRankType _Rank = Rank;
			RowPointerType _ParentRowPointer = ParentRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateItemCategoryHierarchySp";
				
				appDB.AddCommandParameter(cmd, "Select", _Select, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCategory", _ItemCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rank", _Rank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentRowPointer", _ParentRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
