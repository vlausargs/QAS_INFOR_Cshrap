//PROJECT NAME: Material
//CLASS NAME: ICLM_EmptyStockroomLocs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_EmptyStockroomLocs
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_EmptyStockroomLocsSp(string FilterString = null,
		string PSiteGroup = null);
	}
}

