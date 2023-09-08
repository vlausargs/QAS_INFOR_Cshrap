//PROJECT NAME: Data
//CLASS NAME: IAppCreateSearchCatalog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAppCreateSearchCatalog
	{
		(int? ReturnCode,
			string Infobar) AppCreateSearchCatalogSp(
			string Infobar);
	}
}

