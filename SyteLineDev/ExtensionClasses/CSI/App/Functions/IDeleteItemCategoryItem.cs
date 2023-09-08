//PROJECT NAME: Data
//CLASS NAME: IDeleteItemCategoryItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDeleteItemCategoryItem
	{
		int? DeleteItemCategoryItemSp(
			Guid? DelRowPointer,
			string ItemCategory,
			string Item);
	}
}

