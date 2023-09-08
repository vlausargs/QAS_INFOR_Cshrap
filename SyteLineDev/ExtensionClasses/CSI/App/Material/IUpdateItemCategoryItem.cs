//PROJECT NAME: Material
//CLASS NAME: IUpdateItemCategoryItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IUpdateItemCategoryItem
	{
		int? UpdateItemCategoryItemSp(int? Select,
		string Item,
		Guid? TreeRowPointer);
	}
}

