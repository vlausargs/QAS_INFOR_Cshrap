//PROJECT NAME: Logistics
//CLASS NAME: IAU_CLM_GetCoLineAndBlanket.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAU_CLM_GetCoLineAndBlanket
	{
		(ICollectionLoadResponse Data, int? ReturnCode) AU_CLM_GetCoLineAndBlanketSp(string CoNum);
	}
}

