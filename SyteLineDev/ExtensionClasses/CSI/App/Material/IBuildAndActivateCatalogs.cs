//PROJECT NAME: Material
//CLASS NAME: IBuildAndActivateCatalogs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IBuildAndActivateCatalogs
	{
		(int? ReturnCode, string Infobar) BuildAndActivateCatalogsSp(int? RebuildAllPendingCatalogs,
		int? ActivateAllPendingCatalogs,
		int? RebuildAllActiveCatalogs,
		string Infobar);
	}
}

