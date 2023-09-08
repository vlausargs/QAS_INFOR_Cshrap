//PROJECT NAME: Data
//CLASS NAME: IParseSROList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IParseSROList
	{
		ICollectionLoadResponse ParseSROListFn(
			string List);
	}
}

