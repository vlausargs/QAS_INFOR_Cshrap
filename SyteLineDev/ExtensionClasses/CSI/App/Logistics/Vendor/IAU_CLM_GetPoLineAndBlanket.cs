//PROJECT NAME: Logistics
//CLASS NAME: IAU_CLM_GetPoLineAndBlanket.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAU_CLM_GetPoLineAndBlanket
	{
		(ICollectionLoadResponse Data, int? ReturnCode) AU_CLM_GetPoLineAndBlanketSp(string PoNum);
	}
}

