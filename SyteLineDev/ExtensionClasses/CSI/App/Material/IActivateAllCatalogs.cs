//PROJECT NAME: Material
//CLASS NAME: IActivateAllCatalogs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IActivateAllCatalogs
	{
		(int? ReturnCode, string Infobar) ActivateAllCatalogsSp(string Infobar);
	}
}

