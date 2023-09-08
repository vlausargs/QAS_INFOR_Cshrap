//PROJECT NAME: Data
//CLASS NAME: ICN_LedgerData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICN_LedgerData
	{
		ICollectionLoadResponse CN_LedgerDataFn();
	}
}

