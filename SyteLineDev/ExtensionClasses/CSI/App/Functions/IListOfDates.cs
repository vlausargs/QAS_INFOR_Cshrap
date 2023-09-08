//PROJECT NAME: Data
//CLASS NAME: IListOfDates.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IListOfDates
	{
		ICollectionLoadResponse ListOfDatesFn();
	}
}

