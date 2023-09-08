//PROJECT NAME: Material
//CLASS NAME: IActivateCatalog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IActivateCatalog
	{
		(int? ReturnCode, string Infobar) ActivateCatalogSp(string CatalogID,
		string Infobar);
	}
}

