//PROJECT NAME: Material
//CLASS NAME: ICLM_GetCurrentSearchItemCategories.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_GetCurrentSearchItemCategories
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCurrentSearchItemCategoriesSp(int? ChildCategoriesOnly,
		Guid? RowPointer,
		int? RecordCap,
		string FilterString);
	}
}

