//PROJECT NAME: Material
//CLASS NAME: IUpdateItemCategoryHierarchy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IUpdateItemCategoryHierarchy
	{
		int? UpdateItemCategoryHierarchySp(int? Select,
		string ItemCategory,
		int? Rank,
		Guid? ParentRowPointer);
	}
}

