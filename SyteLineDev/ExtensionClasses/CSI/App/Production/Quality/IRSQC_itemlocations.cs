//PROJECT NAME: Production
//CLASS NAME: IRSQC_itemlocations.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_itemlocations
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_itemlocationsSp(
			string BegItem = null,
			string EndItem = null,
			string ProdCode = null);
	}
}

