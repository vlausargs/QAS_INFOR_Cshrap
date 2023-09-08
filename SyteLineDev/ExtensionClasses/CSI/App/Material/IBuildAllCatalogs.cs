//PROJECT NAME: Material
//CLASS NAME: IBuildAllCatalogs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IBuildAllCatalogs
	{
		(int? ReturnCode, string Infobar) BuildAllCatalogsSp(string Status,
		string Infobar);
	}
}

