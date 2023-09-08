//PROJECT NAME: Data
//CLASS NAME: IGetSiteDateTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetSiteDateTable
	{
		ICollectionLoadResponse GetSiteDateTableFn();
	}
}

