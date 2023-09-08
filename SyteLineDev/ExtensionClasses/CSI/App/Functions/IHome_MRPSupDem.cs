//PROJECT NAME: Data
//CLASS NAME: IHome_MRPSupDem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHome_MRPSupDem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_MRPSupDemSp(
			int? DetailDisplay = 0,
			int? UseFullyTransactedOrders = 0,
			int? PExcludePLNs = 0,
			string Item = null,
			int? RowCount = 200);
	}
}

