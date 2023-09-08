//PROJECT NAME: Material
//CLASS NAME: IBuildCatalogItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IBuildCatalogItems
	{
		(int? ReturnCode, string Infobar) BuildCatalogItemsSp(Guid? CatalogRowPointer,
		string Infobar);
	}
}

