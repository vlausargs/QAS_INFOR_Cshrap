//PROJECT NAME: Data
//CLASS NAME: IFKGenOne.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFKGenOne
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FKGenOneSp(
			string Table,
			int? Drop = 1,
			int? Create = 1);
	}
}

