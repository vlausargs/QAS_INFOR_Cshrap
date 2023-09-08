//PROJECT NAME: Data
//CLASS NAME: IFK_all.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFK_all
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FK_allSp();
	}
}

