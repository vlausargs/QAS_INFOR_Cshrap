//PROJECT NAME: Material
//CLASS NAME: ICLM_GetCurrentSearchItemCategoryHierarchies.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_GetCurrentSearchItemCategoryHierarchies
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCurrentSearchItemCategoryHierarchiesSp(string Criteria,
		string CriterionTypes,
		int? LocaleID,
		Guid? SessionId,
		Guid? CatalogRowPointer);
	}
}

