//PROJECT NAME: Data
//CLASS NAME: IDeleteItemCategoryHierarchy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDeleteItemCategoryHierarchy
	{
		int? DeleteItemCategoryHierarchySp(
			Guid? DelRowPointer);
	}
}

